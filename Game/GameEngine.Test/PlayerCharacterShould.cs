using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameEngine;

namespace GameEngine.Test
{
    [TestClass]
    public class PlayerCharacterShould
    {
        [TestMethod]
        [TestCategory("Player Defaults")]
        public void BeInexperiencedWhenNew()
        {
            var playerCharacter = new PlayerCharacter();

            Assert.IsTrue(playerCharacter.IsNoob);
        }

        [TestMethod]
        [TestCategory("Player Defaults")]
        public void NotHaveNickNameByDefault()
        {
            var playerCharacter = new PlayerCharacter();

            Assert.IsNull(playerCharacter.Nickname);
        }

        [TestMethod]
        [TestCategory("Player Defaults")]
        public void StartWithDefaultHealth()
        {
            var playerCharacter = new PlayerCharacter();
            Assert.AreEqual(100,playerCharacter.Health);
        }

        //Step 1
        public static IEnumerable<object[]> Damages
        {
            get
            {
                return new List<object[]>
                {
                    new object[]{1,99},
                    new object[]{0,100},
                    new object[]{100,1},
                    new object[]{101,1},
                    new object[]{50,50}
                };
            }
        }

        //Step 2
        public static IEnumerable<object[]> GetDamages()
        {
            return new List<object[]>
            {
                new object[]{1,99},
                new object[]{0,100},
                new object[]{100,1},
                new object[]{101,1},
                new object[]{50,50}
            };
        }

        [DataTestMethod]
        //[DataRow(1,99)]
        //[DataRow(0,100)]
        //[DataRow(100,1)]
        //[DataRow(101,1)]
        //[DataRow(50,50)]

       // [DynamicData(nameof(Damages))]
        //[DynamicData(nameof(GetDamages),DynamicDataSourceType.Method)]
        [DynamicData(nameof(GetDamages),typeof(DamageData), DynamicDataSourceType.Method)]
        [TestCategory("Player Health")]
        public void TakeDamage(int damage,int expectedHealth)
        {
            var playerCharacter = new PlayerCharacter();
            playerCharacter.TakeDamage(damage);
            Assert.AreEqual(expectedHealth,playerCharacter.Health);
        }

        [TestMethod]
        [TestCategory("Player Health")]
        public void TakeDamage_NotEqual()
        {
            var playerCharacter = new PlayerCharacter();
            playerCharacter.TakeDamage(1);
            Assert.AreNotEqual(100, playerCharacter.Health);
        }
        [TestMethod]
        [TestCategory("Player Health")]
        public void IncreaseHealthAfterSleeping()
        {
            var playerCharacter = new PlayerCharacter();
            playerCharacter.Sleep();
            Assert.IsTrue(playerCharacter.Health >= 101 && playerCharacter.Health <= 200);
        }

        [TestMethod]
        public void CalculateFullName()
        {
            var playerCharacter = new PlayerCharacter();
            playerCharacter.FirstName = "Sandip";
            playerCharacter.LastName = "Patil";

            Assert.AreEqual("Sandip Patil", playerCharacter.FullName);
        }
        [TestMethod]
        public void CalculateFullNameUpperCase()
        {
            var playerCharacter = new PlayerCharacter();
            playerCharacter.FirstName = "Sandip";
            playerCharacter.LastName = "Patil";

            Assert.AreEqual("SANDIP PATIL", playerCharacter.FullName, true);
        }
        [TestMethod]
        public void HaveFullNameStartingWithFirstName()
        {
            var playerCharacter = new PlayerCharacter();
            playerCharacter.FirstName = "Sandip";

            //Assert.IsTrue(playerCharacter.FullName.StartsWith("Sandip"));
            StringAssert.StartsWith(playerCharacter.FullName,"Sandip");
        }

        [TestMethod]
        public void HaveFullNameStartingWithLastName()
        {
            var playerCharacter = new PlayerCharacter();
            playerCharacter.LastName = "Patil";

            //Assert.IsTrue(playerCharacter.FullName.StartsWith("Sandip"));
            StringAssert.EndsWith(playerCharacter.FullName, "Patil");
        }

        [TestMethod]
        public void CalculateFullName_SubstringAsserExample()
        {
            var playerCharacter = new PlayerCharacter();
            playerCharacter.FirstName = "Sandip";
            playerCharacter.LastName = "Patil";

            StringAssert.Contains(playerCharacter.FullName,"ip Pa");
        }

        [TestMethod]
        public void CalculateFullNameWithTitleCase()
        {
            var playerCharacter = new PlayerCharacter();
            playerCharacter.FirstName = "Sandip";
            playerCharacter.LastName = "Patil";

            StringAssert.Matches(playerCharacter.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            //StringAssert.DoesNotMatch(playerCharacter.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [TestMethod]
        public void HaveALongBow()
        {
            var playerCharacter = new PlayerCharacter();
            CollectionAssert.Contains(playerCharacter.Weapons,"Long Bow");
        }

        [TestMethod]
        public void NotHaveAStaffOfWonder()
        {
            var playerCharacter = new PlayerCharacter();
            CollectionAssert.DoesNotContain(playerCharacter.Weapons, "Staff Of Wonder");
        }
        [TestMethod]
        public void HaveAllExpectedWeapons()
        {
            var playerCharacter = new PlayerCharacter();

            var expectedWeapoons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            CollectionAssert.AreEqual(expectedWeapoons,playerCharacter.Weapons);
        }
        [TestMethod]
        public void HaveAllExpectedWeapons_AnyOrder()
        {
            var playerCharacter = new PlayerCharacter();

            var expectedWeapoons = new[]
            {
                "Short Bow",
                "Long Bow",
                "Short Sword"
            };

            CollectionAssert.AreEquivalent(expectedWeapoons, playerCharacter.Weapons);
        }
        [TestMethod]
        public void HaveNoDuplicateWepons()
        {
            var playerCharacter = new PlayerCharacter();
           // playerCharacter.Weapons.Add("Short Bow");

            CollectionAssert.AllItemsAreUnique(playerCharacter.Weapons);
        }

        [TestMethod]
        public void HaveAtLeastOneKindOfSword()
        {
            var playerCharacter = new PlayerCharacter();
            Assert.IsTrue(playerCharacter.Weapons.Any(w => w.Contains("Sword")));
        }

        [TestMethod]
        public void HaveNoEmptyDefaultWepons()
        {
            var playerCharacter = new PlayerCharacter();
            Assert.IsFalse(playerCharacter.Weapons.Any(w => string.IsNullOrWhiteSpace(w)));
        }
    }
}
