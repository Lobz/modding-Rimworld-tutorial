
# Lesson 5: Specific compatibility with other mods

Most mods are compatible with each other simply by virtue of not interacting with the same code. If I make a mod that alters muffalos, and another that creates cornbread, they will be compatible simply because they have nothing in common. Sometimes, though, you have to make your mod check for if other mods are installed and act accordingly.

For example, in my mod [Craftable Bedrolls](http://github.com/Lobz/CraftableBedrolls) I wanted to add specific compatibility to Polyamoury Beds. Since I was making all bedrolls craftable, I needed to check for the specific bedrolls added by Polyamory Beds to patch them in the same way as I patched the Core bedrolls.

Usually if you want your mod to edit something made by other mods (or DLCs), but still work when those mods/DLCs aren't present, you can use the [PatchOperationFindMod](https://rimworldwiki.com/wiki/Modding_Tutorials/PatchOperations#PatchOperationFindMod) in your Patches .xml files.

This is an Example from Craftable Bedrolls:

```xml
<Operation Class="PatchOperationFindMod">
    <mods>
        <li>Polyamory Beds (Vanilla Edition)</li> <!-- name of the mod I'm looking for -->
    </mods>
    <match Class="PatchOperationSequence"> <!-- if a matching mod is found, make a sequence of patches -->
        <success>Always</success>

        <operations> <!-- sequence of operations. Use the `li` tags to define individual operations -->
            <li Class="PatchOperationAdd"> <!-- adding workToMake tag to triple bedrolls -->
                <xpath>Defs/ThingDef[defName="BedrollTriple"]/statBases</xpath>
                <value>
                    <WorkToMake>1600</WorkToMake>
                </value>
            </li>

            <li Class="PatchOperationAdd"> <!-- adding workToMake tag to quadruple bedrolls -->
                <xpath>Defs/ThingDef[defName="BedrollQuad"]/statBases</xpath>
                <value>
                    <WorkToMake>2100</WorkToMake>
                </value>
            </li>
        </operations>
    </match>
</Operation>
```

`PatchOperationFindMod` is a bit annoying to work with because you can't nest `<Operation>` tags, so you have to have to put the `PatchOperation` class directly on the `<match>` tag. 