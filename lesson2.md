# Lesson 2: Change some Thing

The essence of modding is **mod**ifying your game, and a lot of that is changing the stats of objects, materials, creatures, etc, or giving some thing on the game the traits that other things already have, etc etc etc. You can get really far in modding your game with just that.

Say you want some plant to grow slower, or faster, or give a larger or smaller harvest; or you want to rebalance a weapon's damage, or the stats of some kind of leather; or you want to make muffalos super easy to tame and give much more wool and lay chicken eggs in their spare time. As long as what you are doing doesn't introduce completely new logic to the game, all you will need is a little bit of XML.

## Requirements

You're gonna need to be able to:

- Create folders

- Edit .xml files

- "Find in files", that is, search for one word inside all of the files in a folder. This is gonna be essential for finding where the things you want to mod are defined.

Since we're gonna start messing with Ludeon's code, you might want to have on hand a text editor that also does Syntax Highlighting (that is, it colors the xml all pretty-like to make it easier to read, with tags in one color and content in another). At this point, you might as well install an IDE. I honestly recommend Visual Studio Code, since it's very simple and extendable and free. But eh, everyone uses something different, and I myself have used a dozen different setups over the years. One advantage of using a tool like this is that you can do all three things I mentioned above in the same window.

But if you want to keep using notepad that's fine too.

## Steps

1. Decide what you want to change in the game. For example: I want to make muffalos give much more wool and lay chicken eggs in their spare time.

2. Setup you mod as in [Lesson 1](lesson1.md). Change the mod name, id and description to match your purpose. Example of the `About.xml`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<ModMetaData>
    <name>Egg-laying wooly muffalos</name> <!-- The name of your mod in the mod list -->
    <author>Oz</author>
    <supportedVersions> <!-- the version(s) your mod supports -->
        <li>1.1</li>
        <li>1.2</li>
        <li>1.3</li>
    </supportedVersions>
    <packageId>oz.egglayingwoolymuffalos</packageId> <!-- a unique identifier for your mod. Must contain only a-z and periods, no spaces. -->
    <description>
This mod makes muffalos produce much more wool and lay chiken eggs. I totally created it just for the lolz.
    </description>
</ModMetaData>
```

3. Now, we're gonna look for the thing we want to modify. Open the Rimworld folder, and inside that, open the Data folder. This folder is like the Mods folder, but for official content made by Ludeon. Inside you will find a Core folder, and folders for any DLCs you have. Unless you want to change something DLC-exclusive, the thing you're looking for is in Core. Notice that each of these is exactly like a mod folder, with an `About.xml` and a `Preview.png` image and a few other things.

4. Inside Core, open the Defs folder. This is the folder you use when defining new things. Since this is core, it has an ungodly ammount of subfolders and files defining every single aspect of the Rim. I you want, feel free to spend time exploring the files and marveling at the sheer ammount of stuff defined in them. Look for tags such as `<label>` and `<description>` to understand what is being defined, and everything else to understand what are the actual traits and stats of those things. Realize that every single thing defined in those files can be changed.

**Note:** if you're having trouble understanding the Defs because of the XML language, you can take a break to read the [Introduction to XML](https://www.w3schools.com/XML/default.asp) by W3Schools.

5. Find the Def of the thing you want to change. This is where a "find in files" tool comes in handy. Example: I want to change the muffallos, so I'll look for `muffalo`. The word appears in a lot of different files, but I want the main Def for muffalo, so I'll look for `<label>muffalo</label>`. Huh. It turns out that there are two Defs labeled muffalo. That's ok. I'll keep both open for now.

6. Find the tags of the traits you want to change. Example: looking through the tags I quickly find one called `<woolAmount>`. I want to change the value from 120 to 240.

7. If you just want to change a numerical value like wool amount, you can skip this. But, if you want to make a bigger change, first look for the Def of something else that has the traits you want to add to the thing. Example: I want muffalos to lay eggs, so I'll look up the Def for chickens and find anything for eggs.

8. Now back in your mod folder, create a subfolder called `Patches`. This folder will contain code that modifies things that already exist in the game. Inside it, create a new .xml file. You can call it what you want. Example: I created the file `muffalo.xml`.

9. Into your new xml file, paste the following code:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Patch>

</Patch>
```

The actual code will go in between the opening and closing `Patch` tags.

10. Open the list for PatchOperations in the modding tutorials page: https://rimworldwiki.com/wiki/Modding_Tutorials/PatchOperations

11. Figure out what kind of change you need to perform on the Defs. Each kind of patch operation changes the xml nodes in a different way (note: a node is composed by the opening tag, the closing tag, and everything in between. Some nodes contain other nodes.). Most things can be done with Add, Remove or Replace. Example: to double the ammount of wool a muffalo produces, I want to *replace* `<woolAmount>120</woolAmount>` with `<woolAmount>240</woolAmount>`. To add the ability to lay eggs, though, I'm gonna need to *add* a lot of lines of code, that I will copy directly from the chicken Def.

12. Copy the example code for your selected patch operation inside the `Patch` node of your .xml file, like so:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Patch>

    <Operation Class="PatchOperationReplace">
        <xpath>/Defs/ExampleDef[defName="Example"]/exampleNode</xpath>
        <value>
            <anotherExample>An alternate node</anotherExample>
        </value>
    </Operation>

</Patch>
```
13. PatchOperations have two main nodes: the `xpath` and the `value`. The `xpath` node indicates what node you will be affecting, and the `value` contains the code to be added. First, we need to figure out the `xpath`. This means figuring out the parent-nodes from the node you want to change, and put them in order, as if they were a sequence of folders inside folders in a file system. For example: in the beggining of the muffalo's Def I saw the first tag was `<ThingDef ParentName="AnimalThingBase>`. This is a Def for a Thing, or a ThingDef, so I have to put it in the `<xpath>`. The `defName` is on the first line of the Def, and it will allow the program to find the exact Def we want. Then, we need to give the path to the node we want: `woolAmount` is inside a node tagged `li`, inside a node called `comp`. Most nodes are inside other nodes, and you can identify that by paying attention to the order of opening and closing tags, and to the indentation (the ammount of space before a line -- more spaces mean more nested nodes). My `xpath` for `woolAmount` looks like this:

```xml
    <xpath>/Defs/ThingDef[defName="Muffalo"]/comps/li/woolAmount</xpath> <!-- this identifies which node you will be changing -->
```

If you're having trouble with **xml pathing**, here are excellent resources:

- [Xpath generator](https://xmltoolbox.appspot.com/xpath_generator.html) from XmlToolBox. Here, you can just paste the whole Def you're trying to affect, and click on the node you want, and it will give you a path to that node. Just remember to change the selector of ThingDef to DefName rather than ParentName or whatever the Xpath generator will use by default.

- [A quick tutorial of xpathing and patching](https://ludeon.com/forums/index.php?topic=32785.0) by minimurgle on the Forum

- [XPath Tutorial](https://www.w3schools.com/xml/xpath_intro.asp) on the W3Schools website

13. Next, we need to change the `value`. This is the new code you are adding to the Def. In my case, I want a new `woolAmount` node, so my value is this:

```xml
    <woolAmount>240</woolAmount>
```

13. All things added together, the whole Patch file looks like this:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Patch>

    <Operation Class="PatchOperationReplace">
        <xpath>/Defs/ThingDef[defName="Muffalo"]/comps/li/woolAmount</xpath> <!-- this identifies which node you will be changing -->
        <value> <!-- anything inside the value node will be added to the Def -->
            <woolAmount>240</woolAmount>
        </value>
    </Operation>

</Patch>
```

14. It's done! Save your file, enter Rimworld. Activate development mode in the Options so you can see bug reports if it fails. In the Mods window, deactivate all other unrelated mods, activate your mod, and check if it's working! You can start a scenario with the things you changed to make it easier to check. Congratulations! You made your first functional mod!!

15. To finish up our example: I wanted to not only change the wool ammount, but *also* make the Muffalos lay eggs. To do this I'll add another patch operation to my muffalo.xml. This one will be a PatchOperatioAdd. I'll copy it directly from the chicken. In the Chicken Def, the egg-laying code is like this:
```xml
    <comps>
      <li Class="CompProperties_EggLayer">
        <eggUnfertilizedDef>EggChickenUnfertilized</eggUnfertilizedDef>
        <eggFertilizedDef>EggChickenFertilized</eggFertilizedDef>
        <eggFertilizationCountMax>1</eggFertilizationCountMax>
        <eggLayIntervalDays>1</eggLayIntervalDays>
        <eggCountRange>1</eggCountRange>
      </li>
    </comps>
```
I already have a `comps` node in the muffalo Def, so I can just add the contents to it, like so:

```xml

<Operation Class="PatchOperationAdd">
    <xpath>/Defs/ThingDef[defName="Muffalo"]/comps</xpath> <!-- path to the comps node -->
    <value> <!-- adding only the line for the egglayer properties -->
      <li Class="CompProperties_EggLayer">
        <eggUnfertilizedDef>EggChickenUnfertilized</eggUnfertilizedDef>
        <eggFertilizedDef>EggChickenFertilized</eggFertilizedDef>
        <eggFertilizationCountMax>1</eggFertilizationCountMax>
        <eggLayIntervalDays>1</eggLayIntervalDays>
        <eggCountRange>1</eggCountRange>
      </li>
    </value>
</Operation>
```

I'll add this code to my `muffalo.xml` right below the other patch operation, so now it looks like this:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Patch>

    <Operation Class="PatchOperationReplace">
        <xpath>/Defs/ThingDef[defName="Muffalo"]/comps/li/woolAmount</xpath> <!-- this identifies which node you will be changing -->
        <value> <!-- anything inside the value node will be added to the Def -->
            <woolAmount>240</woolAmount>
        </value>
    </Operation>

    <Operation Class="PatchOperationAdd">
        <xpath>/Defs/ThingDef[defName="Muffalo"]/comps</xpath>
        <value>
        <li Class="CompProperties_EggLayer">
            <eggUnfertilizedDef>EggChickenUnfertilized</eggUnfertilizedDef>
            <eggFertilizedDef>EggChickenFertilized</eggFertilizedDef>
            <eggFertilizationCountMax>1</eggFertilizationCountMax>
            <eggLayIntervalDays>1</eggLayIntervalDays>
            <eggCountRange>1</eggCountRange>
        </li>
        </value>
    </Operation>

</Patch>
```

Let's see what this does!

I loaded a game with starting muffalos using Scenario Editor and.... Yup! My muffalos now lay chicken eggs! That can hatch actual chicks! Amazing! You can really do whatever strikes your fancy with mods, lol.
Check out the source for this example in [EggLayingMuffalos](EggLayingMuffalos).

That was it for this lesson. Next, we should learn [how to create new Defs to add entirely new things to the game](lesson3.md)!
