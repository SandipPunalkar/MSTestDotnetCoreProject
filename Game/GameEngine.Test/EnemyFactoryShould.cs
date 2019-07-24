using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Test
{
    [TestClass]
    public class EnemyFactoryShould
    {
        [TestMethod]
        public void NotAllowNullName()
        {
            var enemyFactory = new EnemyFactory();

            Assert.ThrowsException<ArgumentNullException>(() => enemyFactory.Create(null));
        }

        [TestMethod]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            var enemyFactory = new EnemyFactory();

            EnemyCreationException enemyCreationException = Assert.ThrowsException<EnemyCreationException>(() => enemyFactory.Create("Zombie",true));
            Assert.AreEqual("Zombie",enemyCreationException.RequestedEnemyName);
        }

        [TestMethod]
        public void CreateNormalEnemyByDefault()
        {
            var enemyFactory = new EnemyFactory();
            var enemy = enemyFactory.Create("Zombie");

            Assert.IsInstanceOfType(enemy,typeof(NormalEnemy));
        }

        [TestMethod]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            var enemyFactory = new EnemyFactory();
            var enemy = enemyFactory.Create("Zombie");

            Assert.IsNotInstanceOfType(enemy, typeof(NormalEnemy));
        }
        [TestMethod]
        public void CreateBossEnemy()
        {
            var enemyFactory = new EnemyFactory();
            var enemy = enemyFactory.Create("Zombie King");

            Assert.IsNotInstanceOfType(enemy, typeof(BossEnemy));
        }

        [TestMethod]
        public void CreateSeparateInstances()
        {
            var enemyFactory = new EnemyFactory();
            var enemy = enemyFactory.Create("Zombie");
            var enemy2 = enemyFactory.Create("Zombie");

            Assert.AreNotSame(enemy,enemy2);
        }

    }
}