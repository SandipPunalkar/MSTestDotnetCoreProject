using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Test
{
    [TestClass]
    public class Assembly
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Console.WriteLine("AssemblyInit");
        }

        [AssemblyCleanup]
        public static void AssemblyClean()
        {
            Console.WriteLine("AssemblyClean");
        }
    }
}