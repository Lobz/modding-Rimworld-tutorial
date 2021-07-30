# Lesson 6: your very first DLL mod

This lesson will be another "hello, world" type of tutorial, but this time, we will be creating a DLL.

## What is a DLL

DLL mods are mods that add completely new functionality to the game by adding a **Dynamically Loaded Library** (DLL). A .dll library file is a binary file, that is: a piece of code written in very efficient code that your computer can execute, but that humans wouldn't be able to read. A library file is similar to an executable file, except that it can't be executed on its own: it needs to be called by a different program. An executable file, such as a .exe in Windows, can access .dll libraries while they run. 

Libraries are a way to make programs modular: the same library can be used by many different programs, and you can add functionality to a program by adding libraries, withour messing with the core code of the program. That is exactly what a DLL mod does.

Of course, this only works because Tynan made Rimworld to accept and incorporate those libraries. Many games are not made to be moddable, and so adding new DLLs to them does nothing because their code never calls on them.

Writing code for a DLL mod is not that different from writing code for a pure XML mod. The big difference is that you will have to un-compile the Rimworld source before you can read it, and then youré gonna have to compile your own code for it to work.

## What is compiling

Being a binary file means that a DLL is a *compiled* library. Similarly, an executable file such as RimworldWin64.exe