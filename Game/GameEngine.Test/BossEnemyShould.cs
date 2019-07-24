using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Test
{
    [TestClass]
    public class BossEnemyShould
    {
        private static BossEnemy bossEnemy = null;

       [ClassInitialize]
        public static void CreateInstanceInit(TestContext context)
        {
             bossEnemy = new BossEnemy();
        }
        [TestMethod]
        public void HaveCorrectSpecialAttackPower()
        {
           // var bossEnemy = new BossEnemy();
            Assert.AreEqual(166.6, bossEnemy.SpecialAttackPower,0.07);
        }

        [ClassCleanup]
        public static void CreateInstanceClean()
        {
            bossEnemy = null;
        }

    }
}