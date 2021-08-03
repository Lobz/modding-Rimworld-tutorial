# Lesson 6: a theorical introduction to DLL mods

The tutorial for making a DLL mod was getting cluttered with too much theory, so I decided to separate the theorical parts in this lesson.

## When to make a DLL mod

You can make an infinite variety of things with only Defs and Patches, but there are still limits. With XML, you can only mix and match functionality that already exists in some part of the game. You need a more powerful tool when you want to add some completely new mechanic that doesn't exist anywhere in the game.

You want to create a fire-breathing dragon? You can make a big predator that looks like a dragon with only xml, but you will need a DLL that adds the flame breath code, and to make the animal control this ranged weapon.

DLL mods are mods that add completely new functionality to the game by adding a **Dynamic-Link Library** (DLL).
Just because you have to create a DLL doesn't mean your mod is complicated. Simple examples of mods that would have to be DLL mods (unless a game update adds something similar):

- A bear that hibernates in winter

- A squirrel that buries and plants seeds

- In fact, any mod that adds new types of behaviour to animals or people

- A mod that makes campfires warm people around them even when outside

- In fact, pretty much anything that changes how temperature works

- Or that adds another global condition, such as humidity, or air quality

- A mod that makes trees appear in clumps, rather than scattered through the whole map equally

## What is a DLL

 A .dll library file is a binary file, that is: a piece of very efficient code that your computer can execute, but that humans wouldn't be able to read. A library file is similar to an executable file, except that it can't be executed on its own: it needs to be called by a different program. An executable file, such as a .exe in Windows, can access .dll libraries while it runs.

 They are called "libraries" after the idea of a place where you can store all the books you need and use them as reference as needed. A library can store many useful things that you can access in an organized fashion.

Libraries are a way to make programs modular: the same library can be used by many different programs, and you can add functionality to a program by adding libraries, withour messing with the core code of the program. That is exactly what a DLL mod does.

Of course, this only works because Ludeon made Rimworld to accept and incorporate those libraries. Many games are not made to be moddable, and so adding new DLLs to them does nothing because their code never calls on them.

Writing code for a DLL mod is not that different from writing code for a pure XML mod. The big difference is that you will have to un-compile the Rimworld source before you can read it, and then you're gonna have to compile your own code for it to work.

You can find in-depth information on DLLs in [Wikipedia](https://en.wikipedia.org/wiki/Dynamic-link_library).

## What is compiling

Being a binary file means that a DLL is a *compiled* library. Similarly, a binary executable file such as RimworldWin64.exe is a *compiled* program. This means that their code was written in a compiled programming language such as C, C++, Java, or C#, that was then read by a program called a compiler and turned into machine-code.

This is different from programing in *interpreted* programming languages or scripting languages, such as PHP, JavaScript or Python, in which the code is executed while it is read, with no prior assembly.
The XML files in your mod (and in Core) also fall under this category, since they are interpreted by Rimworld as it runs.

The main advantage of compiling is that it makes the program extremely efficient. The compiler does the work of translating the code to machine-code at compiling-time, so that the program doesn't have to do it at run-time. Also, modern compilers have many built-in optimizations to make the most efficient machine-code. Back in the day, when computers were less powerful and compilers less efficient, complex games had to be programmed directly in Assembly (a type of machine-code). Nowadays, we rely on powerful languages and compilers to make games that run smoothly but don't take so much work to code.

As usual, you can learn a lot abour compilers and different programming concepts in [Wikipedia](https://en.wikipedia.org/wiki/Compiler).

Rimworld is coded in C# (pronounced "C-Sharp"), a languaged created by Microsoft. You can read more about in in [Wikipedia](https://en.wikipedia.org/wiki/C_Sharp_(programming_language)). To make mods interact smoothly with the core Rimworld libraries, we need to code in C# as well.

In the next lesson, we will [build a minimal DLL mod using basic tools](lesson7.md).