# Lesson 4: Compatibility with different versions

This will be a very short tutorial, but I believe it's needed because it comes up a lot and the way it works is not very intuitive.

You want to make your mod compatible with different versions because lots of people are still using older versions of Rimworld (usually because they want to keep using some mods that have never updated, or because they aren't confident that their saved games will survive the update. So when you update your mod to a new version, you want to keep compatibility with the previous version, so people can keep using it while they don't update their game.

The reccomended way to do that goes like this:

1. Start with a functional mod working in at least one version, and a list of versions you want it to be compatible with. For this example, suppose you have a mod working in version 1.2, and you want to update it to 1.3, and also make it back-compatible with 1.0 and 1.1.

2. First thing is testing your mods in different versions. For that you will need to download different versions of the game, and test your mod with each one. This part is a bit boring with long wait times, but there's no way around it.
I don't know about other platforms, but on steam you can select different versions by right-clicking your game and going to Preferences>Betas and selecting the appropriate version.
If your mod works on each version, you don't have to do anything. Let's assume the mod breaks in at least one version. For sake of didatics, suppose your mod works in version 1.1 and 1.2, but gives an error in 1.0 and another error in 1.3.

3. Select the lowest numbered version in which your mod works. In your mod folder, create a folder names after this folder.
Example: if your mod works in 1.1, but not 1.0, create a folder called `1.1`. I'm gonna call that the working version folder.

4. Figure out the files you will have to edit to solve the errors, and move them into this version folder, *maintaining the folder structure* inside. Example: I detected the error in the file `Defs/Meals/Cornbread.xml`, so I'll create `Defs` and `Foods` folders so I can move my .xml file to `1.1/Defs/Meals/Cornbread.xml`. You can choose to copy whole folders into the version folder, if you prefer, but I think it's neater to move only the files that will be altered. Definetly don't move any image or sound files unless you absolutely need to. Remember to test you mod again after you do this.
**Note**: you will probably have to come back to this step a few times while you make your fix for other versions, to add more files as you figure out you need to edit them.

5. Let's first work on updating to higher versions. Moving up the versions list, select the first version where your mod doesn't work, and create a folder named after that version. Example: if your mod works in 1.2 but not in 1.3, create a folder called `1.3`.

6. Copy all the contents from the working version folder into the higher version folder. Now, when you open the game in higher versions, the game will read the files inside this folder.

7. Install the higher version and edit the files inside the appropriate version folder to make it work in this version. For the example, I will merely change the description of the item, to make it clear the mod has changed.
**Note**: If you realize you need to change something that is not on the version folders, you have to add it to the version folders, as in step 4. Since you now have more than one version folder, remeber to add each file to *all* the folders.

8. Test your mod again! When it's working on the updated version, we can move on.

9. Now for back-compatibility: select the lowest-numbered version in your desired versions list, and create a folder named after that. Example: create a folder called `1.0`. When you open the game in this version, it will skip over the higher-numbered folders and read code from this version.

10. Repeat steps 6-8, but now for the lower version folder.

11. You're done! Celebrate and share your mod!

A note on how this works: each version of Rimworld looks for files inside each version folder, in descending order, starting at their own version number (so they ignore higher version folders, but read from lower version folders). If there are multiple files with the same name, they keep the file from the highest-numbered folder. I the example I gave, you don't need a separate folder for 1.2 because 1.1 and 1.2 will use the same folder, called `1.1`.

Moreover, common files used by all versions can remain on the root folders (outside specific version folders) or can be moved to a folder called `Common`, as you prefer. These files are read by all versions, as long as there isn't another file with the same name inside the specific version folders.

You can read more about that in this guide by Tynan: https://docs.google.com/document/d/e/2PACX-1vSOOrF961tiBuNBIr8YpUvCWYScU-Wer3h3zaoMrw_jc8CCjMjlMzNCAfZZHTI2ibJ7iUZ9_CK45IhP/pub

That's it for this lesson. Not for compatibility with other mods!
