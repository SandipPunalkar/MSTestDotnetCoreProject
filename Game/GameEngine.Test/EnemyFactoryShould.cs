using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Test
{
    [TestClass]
    [TestCategory("Enemy Creation")]
    public class EnemyFactoryShould
    {
        private EnemyFactory enemyFactory;
        [TestInitialize]
        public void TestInitialize()
        {
            enemyFactory = new EnemyFactory();
        }

      
        [TestMethod]
        public void NotAllowNullName()
        {
            //Console.WriteLine("Creating enemyFactory");
            //var enemyFactory = new EnemyFactory();

            //Console.WriteLine("Calling create method");
            Assert.ThrowsException<ArgumentNullException>(() => enemyFactory.Create(null));
        }

        [TestMethod]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            EnemyCreationException enemyCreationException = Assert.ThrowsException<EnemyCreationException>(() => enemyFactory.Create("Zombie",true));
            Assert.AreEqual("Zombie",enemyCreationException.RequestedEnemyName);
        }

        [TestMethod]
        public void CreateNormalEnemyByDefault()
        {
            var enemy = enemyFactory.Create("Zombie");

            Assert.IsInstanceOfType(enemy,typeof(NormalEnemy));
        }

        [TestMethod]
        [Ignore]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            var enemy = enemyFactory.Create("Zombie");

            Assert.IsNotInstanceOfType(enemy, typeof(NormalEnemy));
        }
        [TestMethod]
        public void CreateBossEnemy()
        {
            var enemy = enemyFactory.Create("Zombie King");

            Assert.IsNotInstanceOfType(enemy, typeof(BossEnemy));
        }

        [TestMethod]
        public void CreateSeparateInstances()
        {
            var enemy = enemyFactory.Create("Zombie");
            var enemy2 = enemyFactory.Create("Zombie");

            Assert.AreNotSame(enemy,enemy2);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            enemyFactory = null;
        }
    }
}