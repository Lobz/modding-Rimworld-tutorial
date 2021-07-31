# Lesson 6: your very first DLL mod

This lesson will be another "hello, world" type of tutorial, but this time, we will be creating a DLL.

## When to make a DLL mod

You can make an infinite variety of things with only Defs and Patches, but there are still limits. With XML, you can only mix and match functionality that already exists in some part of the game. You need a more powerful tool when you want to add some completely new mechanic that doesn't exist anywhere in the game.

You want to create a fire-breathing dragon? You can *probably* patch it up with some lines from the Defs of animals, some from flame-throwers, and maybe a few from monsters that have ranged attacks like some mechanoids. But you want it to hoard gold in a cave? Well... ok I guess if you make the dragon into a raider... but no, I don't think raiders can be set to steal specific things... and you definetly can't make a gold hoard in your map, but you can make like a quest map for it... Hmm, it would be tricky and probably clunky... At this point you might be better off coding the behaviour yourself.

Just because you have to create a DLL doesn't mean your mod is complicated. Other, simpler examples of mods that would have to be DLL mods (unless a game update adds something similar):

- A bear that hibernates in winter

- A squirrel that buries and plants seeds

- In fact, any mod that adds new types of behaviour to animals or people

- A mod that makes campfires warm people around them even when outside

- In fact, pretty much anything that changes how temperature works

- Or that adds another global condition, such as humidity, or air quality

- A mod that makes trees appear in clumps, rather than scattered through the whole map equally

## What is a DLL

DLL mods are mods that add completely new functionality to the game by adding a **Dynamic-Link Library** (DLL). A .dll library file is a binary file, that is: a piece of very efficient code that your computer can execute, but that humans wouldn't be able to read. A library file is similar to an executable file, except that it can't be executed on its own: it needs to be called by a different program. An executable file, such as a .exe in Windows, can access .dll libraries while it runs. 

Libraries are a way to make programs modular: the same library can be used by many different programs, and you can add functionality to a program by adding libraries, withour messing with the core code of the program. That is exactly what a DLL mod does.

Of course, this only works because Tynan made Rimworld to accept and incorporate those libraries. Many games are not made to be moddable, and so adding new DLLs to them does nothing because their code never calls on them.

Writing code for a DLL mod is not that different from writing code for a pure XML mod. The big difference is that you will have to un-compile the Rimworld source before you can read it, and then you're gonna have to compile your own code for it to work.

You can find in-depth information on DLLs in [Wikipedia](https://en.wikipedia.org/wiki/Dynamic-link_library).

## What is compiling

Being a binary file means that a DLL is a *compiled* library. Similarly, a binary executable file such as RimworldWin64.exe is a *compiled* program. This means that their code was written in a compiled programming language such as C, C++, Java, or C#, that was then read by a program called a compiler and turned into machine-code.

This is different from programing in *interpreted* programming languages or scripting languages, such as PHP, JavaScript or Python, in which the code is executed while it is read, with no prior assembly.
The XML files in your mod (and in Core) also fall under this category, since they are interpreted by Rimworld as it runs.

The main advantage of compiling is that it makes the program extremely efficient. The compiler does the work of translating the code to machine-code at compiling-time, so that the program doesn't have to do it at run-time. Also, modern compilers have many built-in optimizations to make the most efficient machine-code. Back in the day, when computers were less powerful and compilers less efficient, complex games had to be programmed directly in Assembly (a type of machine-code). Nowadays, we rely on powerful languages and compilers to make games that run smoothly but don't take so much work to code. 

Rimworld is coded in C# (pronounced "C-Sharp"), a languaged created by Microsoft. You can read more about in in [Wikipedia](https://en.wikipedia.org/wiki/C_Sharp_(programming_language)). To make mods interact smoothly with the core Rimworld libraries, we need to code in C# as well.

## You will need

It must have become clear that only a text editor will not be enough anymore. Usually at this point the tutorials will tell you to install Microsoft Visual Studio, but that is not really required. Instead, what you *actually* need is:

- A text editor (any text editor will do)

- The .NET Software Development Kit (which includes the C# compiler)

- A terminal (aka prompt) (you can find a good text editor with built-in terminal)

You can download the .NET SDK from [the official website](https://dotnet.microsoft.com/download).
Make sure you're downloading the SDK and not just the Runtime! 

## Steps

1. Set up your mod folder just as in [Lesson 1](lesson1.md). Make sure this folder is in the Mods folder in the RimWorld base folder, as we will be relying on the relative paths from there.

2. In your mod folder, create a new folder called `Source`. This will contain you C# code.

3. Inside `Source`, create a text file with the extension `.csproj`.
This stands for C-Sharp Project, and will contain basic instructions for the compiler.
Although it has a different extension, the content of this file is XML.

4. Paste this inside your .csproj file:

```xml
<?xml version="1.0" encoding="utf-8"?>

<Project>

  <PropertyGroup> <!-- basic project properties -->
    <AssemblyName>HelloWorld</AssemblyName> <!-- name of the generated DLL -->
    <OutputPath>../Assemblies/</OutputPath> <!-- path to the generated DLL -->
    <OutputType>Library</OutputType>        <!-- make a DLL, rather than a EXE -->

    <DebugType>none</DebugType>             <!-- avoid making extra debug files -->
  </PropertyGroup>

  <ItemGroup> <!-- other libraries that will be used in the mod -->
    <Reference Include="Assembly-CSharp">
      <HintPath>../../../RimWorldWin64_Data/Managed/Assembly-CSharp.dll</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="UnityEngine">
      <HintPath>../../../RimWorldWin64_Data/Managed/UnityEngine.dll</HintPath>
      <Private>False</Private>
    </Reference>
  </ItemGroup>

  <ItemGroup> <!-- this will include all .cs files to be compiled -->
    <Compile Include="*.cs" />
  </ItemGroup>

  <!-- attention: path below may be different on your computer -->
  <Import Project="C:\Program Files\dotnet\sdk\5.0.302\Microsoft.CSharp.targets" />
</Project>

```

This xml file is clunky, but you need everything in there.
I spend a LOT of time coming up with the minimal .csproj file that creates a functional mod.
If you use Visual Studio to create this file, it will create something gigantic.

5. Find your dotnet folder in your file system (probably under Program Files). Check if the path to the file `Microsoft.CSharp.targets` is correct. You may have to change the version number in the path.

5. If you're not on a 64 bit Windows installation, then where you read `RimWorldWin64_Data` in the paths to DLLs, you have to substitute for the name of your actual RimWorld data directory. Please check if this folder actually exists in the RimWorld folder.

6. Still inside `Source`, create a file with the extension `.cs`. This is a C# code file.

7. I'm gonna use the same code as the one from the [wiki tutorial](https://rimworldwiki.com/wiki/Modding_Tutorials/Hello_World). Paste it in your `.cs` file:

```cs
using RimWorld;
using Verse;

namespace HelloWorld
{
    [StaticConstructorOnStartup]
    public static class HelloWorld
    {
        static HelloWorld() //our constructor
        {
            Log.Message("Hello World!"); //Outputs "Hello World!" to the dev console.
        }
    }
}
```

If you never worked in a similar language before, it might be a bit difficult to explain what's going on here, but I'll try. The first two lines are saying we will be using things that come from these two namespaces. The namespaces contain parts of the codes from the RimWorld libraries that we will want to access from our mod. In this specific example, we are using `StaticConstructorOnStartup`, which is defined on `Verse`.

In turn, our mod defines its own namespace. If a future code ever wants to reference it, it will have to start with `using HelloWorld`.

Explaining what a class is is a bit much for the moment, so I'll just say that a static class functions as a way to organize methods that form a set. A constructor is a method with the same name as the class, that in this case, because of `StaticConstructorOnStartup`, will be called when RimWorld starts.

The code inside the constructor is what really matters - everything else is just layers of encapsulation, for the sake of order and to avoid bugs and conflicts. This is important in large, complicated projects, such as a complex game with countless mod extensions.

Anyway, when RimWorld starts, it will call upon the constructor, which will execute this command:

```cs
    Log.Message("Hello World!");
```

Which will, predictably, log a message saying "Hello World!".

Ok, we have our project file and our code, but now we need to assemble it into a DLL. This is where we will need a terminal and the compiler.

8. Open a terminal inside your `Source` folder (or open a terminal and navigate to your source folder using the `cd` command)

9. In your terminal, run: 

```
dotnet build
```

10. When you press Enter, you should see a message in your terminal, saying you compiled successfully without errors. If you do get errors, please let me know so I can make this tutorial error-proof!

11. Check if your mod folder now has a folder called `Assemblies`, containing the file `HelloWorld.dll`.

12. The compiler probably has created a folder called `obj` inside your `Source` folder. These are temporary files used during compilation. You can ignore it or delete it.

13. Compiled succesfully? Time to test! Open Rimworld, and activate your mod!

14. When RimWorld restarts, open the development log console, and check if the message "Hello World!" appears there. That's it! Congratulations, your very first DLL mod is working!

That's it for this lesson. Maybe next lesson we can make a DLL mod that actually does something?

