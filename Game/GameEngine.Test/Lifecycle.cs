using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Test
{
    [TestClass]
    public class Lifecycle
    {
        [TestInitialize]
        public void LifecycleInit()
        {
            Console.WriteLine("TestInitialize lifecycle");
        }

        [TestCleanup]
        public void LifecycleClean()
        {
            Console.WriteLine("TestCleanup lifecycle");
        }

        [ClassInitialize]
        public static void LifecycleClassInit(TestContext context)
        {
            Console.WriteLine("ClassInitialize lifecycle");
        }

        [ClassCleanup]
        public static void LifecycleClassClean(TestContext context)
        {
            Console.WriteLine("ClassCleanup lifecycle");
        }


        [TestMethod]
        public void TestA()
        {
            Console.WriteLine("Test A starting");
        }
        [TestMethod]
        public void TestB()
        {
            Console.WriteLine("Test B starting");
        }
    }
}