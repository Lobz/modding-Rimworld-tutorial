# Lesson 3: Create new things

## Requirements

The requirements are the same as of Part 2

## Steps

1. Create the basic mod structure from Part 1 (yes, each tutorial will start the same way).

2. Decide what you want to create, and then think of something similar to that that already exists in the game. Example: let's create a new type of meal called Cornbread. Cornbread is similar to a simple meal, except it's made of corn and has different stats. 
We're gonna think of cornbread as a modifyied simple meal.

3. As in Part 2, search inside `Rimworld/Data/Core/Defs` for the thing you're gonna work from. Also look up any ingredients or workstations that might be affected. Example: searching for `simple meal` reveals both a Def for simple meal and a recipe for cooking simple meals. We will need both of them to be able to cook these meals. I looked up `raw corn` for the ingredient and `campfire` for the cooking station.

4. In your mod folder, create a folder called `Defs`, and inside it, a .xml file. Copy the following code into your file:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<Defs>

</Defs>
```

5. Inside the file, in between the opening and closing `Defs` tags, copy the Defs you are using as base, and change the names, labels and descriptions. Example:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<Defs>

    <RecipeDef ParentName="CookMealBase">
        <defName>CookCornbread</defName>
        <label>bake cornbread</label>
        <description>Bake a cornbread from raw corn.</description>
        <jobString>Baking cornbread.</jobString>
        <workSpeedStat>CookSpeed</workSpeedStat>
        <requiredGiverWorkType>Cooking</requiredGiverWorkType>
        <effectWorking>Cook</effectWorking>
        <soundWorking>Recipe_CookMeal</soundWorking>
        <allowMixingIngredients>true</allowMixingIngredients>
        <ingredientValueGetterClass>IngredientValueGetter_Nutrition</ingredientValueGetterClass>
        <ingredients>
            <li>
                <filter>
                    <categories>
                        <li>FoodRaw</li>
                    </categories>
                </filter>
            <count>0.5</count>
            </li>
        </ingredients>
        <products>
            <MealSimple>1</MealSimple>
        </products>
        <workSkill>Cooking</workSkill>
    </RecipeDef>

    <ThingDef ParentName="MealCooked">
        <defName>Cornbread</defName>
        <label>cornbread</label>
        <description>A delicious bread made of corn.</description>
        <graphicData>
            <texPath>Things/Item/Meal/Simple</texPath>
            <graphicClass>Graphic_StackCount</graphicClass>
        </graphicData>
        <statBases>
            <MarketValue>15</MarketValue>
            <WorkToMake>300</WorkToMake>
            <Nutrition>0.9</Nutrition>
        </statBases>
        <ingestible>
            <preferability>MealSimple</preferability>
            <ingestEffect>EatVegetarian</ingestEffect>
            <ingestSound>Meal_Eat</ingestSound>
        </ingestible>
    </ThingDef>

</Defs>
```

6. Sometimes you're gonna have to figure out more complex changes in your Defs for them to work how you want. In this example, I needed to change the ingredients from a category to a specific Thing, so I looked up Mods that did similar things, to come up with this solution:

```xml
        <ingredients>
            <li>
                <filter>
                    <ThingDef>
                        <li>RawCorn</li>
                    </ThingDef>
                </filter>
            <count>0.5</count>
            </li>
        </ingredients>
```

It was also necessary to change the products of the recipe:

```xml
        <products>
            <Cornbread>1</Cornbread>
        </products>
```

7. At this point, turn on development mode on Rimwolrd and test your mod by opening it in a scenario with the element you are creating. It should appear as an option in the scenario editor, and it should work, but often you will see details to be corrected. In our example, we can quickly notice two issues: the graphics are the same as the simple meal, and the bill for making cornbread doesn't appear in the campfire!

8. It's time to add custom graphics! (Skip to 11 if you don't need graphics) In your mod folder, create a folder called `Texture`, and inside it, a folder for the thing you are creating. You can also create as many subfolders as you want, for organization. Example: inside of `Textures`, we create a folder called `Things`, and then a folder called `Cornbread` inside of `Things`.

9. Inside the graphics folder for each thing, add your images. Images need to be .png with a transparent background, and if they are to fit in a single tile they must be 64x64 pixels. In case of stackable items, you can add graphic for single item, small stack and large stack using filenames ending in "_a.png", "_b.png", etc. Look up mods similar to yours to find hints on how to add other types of graphics!

10. Now that you have graphics, point the `graphicData` in your Defs towards the folder with the images, like so:

```xml
        <graphicData>
            <texPath>Things/Cornbread</texPath> <!-- path inside the Textures folder -->
            <graphicClass>Graphic_StackCount</graphicClass> <!-- this is for stackable items-->
        </graphicData>
```

11. Often you will need to patch up some other Def to work with your mod. In our example, we need to add the recipe to cornbread to the Campfire list of recipes. Like in Part 2, create a `Patches` folder, and a xml file containing patch operations.

```xml

```

12. Time to test it again! Change your defs and patches until they are doing what you want them to do, and then you can use your mod, post it on the forum, or publish it on Steam from the Mods window in Rimworld!

That's it for this lesson. If you want to browse the code for mods that add things to the game, you can find dozens of them on github.com, for example, many of the Vanilla Expanded mods.
In fact, if you want to make and publish your own mods, I highly recommend setting up a github and uploading them. Just as you can learn tons by reading and reusing code from other mods, maybe other people will also use your code as a reference to make their own mods.

Next lesson will take a detour into how to make your mods compatible with several versions of Rimworld, and after that, we will look into how to male mods compatible with other mods, when you are altering the same things, or when you want to build up on other mods' work.