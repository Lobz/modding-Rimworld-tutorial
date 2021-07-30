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
