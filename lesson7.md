# Lesson 7: Your very first DLL mod

This will be another Hello, World type of lesson. If you want to have a bit of theorical overview about DLL mods, check out [the previous lesson](lesson6.md).

## Requirements

Because of the need to compile the C# code into a DLL, we need a couple more tools than in the XML-only mods. Usually at this point the tutorials will tell you to install Microsoft Visual Studio, but that is not really required. Instead, what you *actually* need is:

- A text editor (any text editor will do)

- A C# compiler

- A terminal (aka prompt) (you can find a good text editor with built-in terminal)

## How to install and setup a C# compiler

This part is not easy to figure out on your own, so I'll walk you through it.

1. First, you can download the csc (C# Compiler) from the Mono Project [here](https://www.mono-project.com/download/stable/).

2. In order to use the csc, you need to add it to your PATH environmental variable. This will make it easily accessible from the terminal.
Look for environmental variables in your system settings, and add the path to the bin folder in your mono installation to the PATH.
In Windows, the path you need to add will be something like this:

```
C:\Program Files\Mono\bin
```

3. To test if the installation was successfull, open a terminal and type `csc`. Press Enter to run the command. If the command worked, you will see something like this:

```
Microsoft (R) Visual C# Compiler version 3.6.0-4.20224.5 (ec77c100)
Copyright (C) Microsoft Corporation. All rights reserved.

warning CS2008: No source files specified.
error CS1562: Outputs without source must have the /out option specified
```

4. Of course, csc will complain you haven't given it any files to compile, so let's give it what it wants. Create a file called `hello.cs`. This is a C# code file.

5. Paste this inside the file:

```cs
using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.WriteLine ("Hello Mono World");
    }
}
```

6. Make sure your terminal is open in the same folder as your file, then run this command:

```
csc hello.cs
```

7. Now you should have a file named `hello.exe`. You can run this file with the command `mono hello.exe`, or, if you're on windows, simply `hello.exe`. It should output the phrase "Hello Mono World" on the terminal.

## Make the mod

Now that you have your working compiler, time to make your mod.

1. Set up your mod folder just as in [Lesson 1](lesson1.md). Make sure this folder is in the Mods folder in the RimWorld base folder, as we will be relying on the relative paths from there.

2. In your mod folder, create a new folder called `Source`. This will contain you C# code.

3. Create another folder called `Assemblies`. This will contain the compiled DLL.

3. Inside `Source`, create a file called `hello.cs`. This is a C# code file.

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

8. Open a terminal inside your mod folder (or open a terminal and navigate to your mod folder using the `cd` command)

9. In your terminal, run: 

```
csc -t:library -out:Assemblies/library.dll -r:"../../RimWorldWin64_Data/Managed/Assembly-CSharp.dll" Source/*.cs
```

This should have compiled your file into a library, and stored it into a file called `library.dll` inside your `Assemblies` folder. The `-t` option tells csc to create a DLL rather than an EXE, the `-out` folder tells it what file to create, and the `-r` option is to add references to the RimWorld DLLs. Lastly, `*.cs` mean we will be compiling all C# files in this folder.

You can learn more about how to use csc from the command-line in [this very helpful tutorial](https://docs.microsoft.com/en-us/previous-versions/ms379563(v=vs.80)).

10. To avoid having to type this whole command every time, we will store it in batch file (in Windows) or bash file (in Linux/Unix). In your mod folder, create a file called `compile.bat` (or `compile.sh` in Linux/Unix) and paste the command inside it. Test if it's working by running the file with the command `compile.bat` (or `bash compile.sh` in Linux/Unix).

12. The compiler probably has created a folder called `obj` inside your mod folder. These are temporary files used during compilation. You can ignore it or delete it.

13. Compiled succesfully? Time to test! Open Rimworld, and activate your mod!

14. When RimWorld restarts, open the development log console, and check if the message "Hello World!" appears there. That's it! Congratulations, your very first DLL mod is working!

That's it for this lesson. Maybe next lesson we can make a DLL mod that actually does something?
