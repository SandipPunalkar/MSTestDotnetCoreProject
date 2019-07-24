using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Test
{
    [TestClass]
    public class BossEnemyShould
    {
        [TestMethod]
        public void HaveCorrectSpecialAttackPower()
        {
            var bossEnemy = new BossEnemy();
            Assert.AreEqual(166.6, bossEnemy.SpecialAttackPower,0.07);
        }
       
    }
}