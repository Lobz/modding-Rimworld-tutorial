# Lesson 1: Your very first mod

Every mod starts the same way: with a mod folder, a description file, and a preview image.

This very basic tutorial will teach you to set up your first mod, and feel the elation of having your mod show up in the mods window inside the game.

## Requirements

Making a mod doesn't require any special programs! All you will need is to be able to:

- create folders

- edit .xml files

XML files are plain text files like TXT files, so any text editor at all will do.
We want to get started right away, so use whatever you have on hand! Notepad is just fine!

## Steps

1. Find your RimWorld's base folder. If you have it on Steam, you can find it by right-clicking the game's name in your library and selecting Manage>Browse local files

2. In the Rimworld folder, open the Mods folder

3. Make a new folder with your mod's name. I'll call mine "HelloWorld" This is your mod's folder! Open it.

4. Inside your mod folder, create new folder called `About` (mind the case).

5. Choose a .png image file for your mod preview image. Copy this file into the `About` folder, and rename it to `Preview.png`. 

6. Inside the `About` folder, create a new text file called `About.xml`. Mind the extension! If you use windows you might need to set an option to "show file extensions" on your file explorer. I've heard some people create a file called `About.txt` and then change the extension later on. That's fine, as long as you don't forget. Now let's talk about the contents of this file.

7. Copy the following code into your `About.xml` file:

```xml
<?xml version="1.0" encoding="utf-8"?>
<ModMetaData>
    <name>Hello, Modding World!</name> <!-- The name of your mod in the mod list -->
    <author>John Doe</author>
    <supportedVersions> <!-- the version(s) your mod supports -->
        <li>1.1</li>
        <li>1.2</li>
        <li>1.3</li>
    </supportedVersions>
    <packageId>johndoe.helloworld</packageId> <!-- a unique identifier for your mod. Must contain only a-z and periods, no spaces. -->
    <description>
Congratulations, you just set up your very first mod!

It does actually modify anything yet, but it's still cool.
    </description>
</ModMetaData>
```

8. Now, open Rimworld and see the new mod, called "Hello, Modding World!", show up in the mod list. Click it to see the preview image, name, description, etc. You can launch a game with this mod on if you want.

9. Change things up in the `About.xml` file to get a feel for it. Usually you're gonna want to change the name, author name, packageId, and description. You might have to reload the game to see the changes appear in the mod list. If you never saw a .xml file before, here's the basic idea: anything inside < these > is called a tag, and is a code word, and actual content goes between an opening tag and a closing tag (marked by a "/"), like this:

```xml
<tag>Actual content</tag>
<anotherTag>Another content</anotherTag>
```

Basically, you can change anything that goes between an opening tag and the corresponding closing tag.

That's it for this lesson! You learned to make the elements that *every single Rimworld mod* has, but from here on, you would have to do different things depending on what you want your mod to *do*.
The [next part](lesson2.md) will be about changing some trait of some thing on the game, using the mechanics the game already have.