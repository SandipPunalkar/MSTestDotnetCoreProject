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
        private PlayerCharacter playerCharacter;

        [TestInitialize]
        public void TestInitialize()
        {
            playerCharacter = new PlayerCharacter {FirstName = "Sandip", LastName = "Patil"};
        }

        [TestMethod]
        [TestCategory("Player Defaults")]
        public void BeInexperiencedWhenNew()
        {
            Assert.IsTrue(playerCharacter.IsNoob);
        }

        [TestMethod]
        [TestCategory("Player Defaults")]
        public void NotHaveNickNameByDefault()
        {
            Assert.IsNull(playerCharacter.Nickname);
        }

        [TestMethod]
        [TestCategory("Player Defaults")]
        public void StartWithDefaultHealth()
        {
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
        //[DynamicData(nameof(GetDamages),typeof(DamageData), DynamicDataSourceType.Method)]
        [DynamicData(nameof(ExternalHealthDamageTestData.TestData),typeof(ExternalHealthDamageTestData))]
        [TestCategory("Player Health")]
        public void TakeDamage(int damage,int expectedHealth)
        { 
            playerCharacter.TakeDamage(damage);
            Assert.AreEqual(expectedHealth,playerCharacter.Health);
        }

        [TestMethod]
        [TestCategory("Player Health")]
        public void TakeDamage_NotEqual()
        {
            playerCharacter.TakeDamage(1);
            Assert.AreNotEqual(100, playerCharacter.Health);
        }
        [TestMethod]
        [TestCategory("Player Health")]
        public void IncreaseHealthAfterSleeping()
        {
            playerCharacter.Sleep();
            //Assert.IsTrue(playerCharacter.Health >= 101 && playerCharacter.Health <= 200);

            //Custom Assert
            Assert.That.IsRange(playerCharacter.Health,101,200);
        }

        [TestMethod]
        public void CalculateFullName()
        {
            Assert.AreEqual("Sandip Patil", playerCharacter.FullName);
        }
        [TestMethod]
        public void CalculateFullNameUpperCase()
        {
            Assert.AreEqual("SANDIP PATIL", playerCharacter.FullName, true);
        }
        [TestMethod]
        public void HaveFullNameStartingWithFirstName()
        {
            playerCharacter.FirstName = "Sandip";

            //Assert.IsTrue(playerCharacter.FullName.StartsWith("Sandip"));
            StringAssert.StartsWith(playerCharacter.FullName,"Sandip");
        }

        [TestMethod]
        public void HaveFullNameStartingWithLastName()
        {
            playerCharacter.LastName = "Patil";

            //Assert.IsTrue(playerCharacter.FullName.StartsWith("Sandip"));
            StringAssert.EndsWith(playerCharacter.FullName, "Patil");
        }

        [TestMethod]
        public void CalculateFullName_SubstringAsserExample()
        {
            StringAssert.Contains(playerCharacter.FullName,"ip Pa");
        }

        [TestMethod]
        public void CalculateFullNameWithTitleCase()
        {
            StringAssert.Matches(playerCharacter.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            //StringAssert.DoesNotMatch(playerCharacter.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [TestMethod]
        public void HaveALongBow()
        {
            CollectionAssert.Contains(playerCharacter.Weapons,"Long Bow");
        }

        [TestMethod]
        public void NotHaveAStaffOfWonder()
        {
            CollectionAssert.DoesNotContain(playerCharacter.Weapons, "Staff Of Wonder");
        }
        [TestMethod]
        public void HaveAllExpectedWeapons()
        {
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
            // playerCharacter.Weapons.Add("Short Bow");

            CollectionAssert.AllItemsAreUnique(playerCharacter.Weapons);
        }

        [TestMethod]
        public void HaveAtLeastOneKindOfSword()
        {
            //Assert.IsTrue(playerCharacter.Weapons.Any(w => w.Contains("Sword")));

            //Custom collection assert
            CollectionAssert.That.AtLeastOneItemSatisfies(playerCharacter.Weapons,w => w.Contains("Sword"));
        }

        [TestMethod]
        public void HaveNoEmptyDefaultWeapons()
        {
            //Assert.IsFalse(playerCharacter.Weapons.Any(w => string.IsNullOrWhiteSpace(w)));

            //Custom collection Assert
            //CollectionAssert.That.AllItemNotNullOrWhitespace(playerCharacter.Weapons);
            //CollectionAssert.That.AllItemSatisfy(playerCharacter.Weapons,w => !string.IsNullOrWhiteSpace(w));

            CollectionAssert.That.All(playerCharacter.Weapons, weapon =>
           {
               StringAssert.That.NotNullOrWhitespace(weapon);
               Assert.IsTrue(weapon.Length > 5);
           });

        }

        [TestCleanup]
        public void TestCleanup()
        {
            playerCharacter = null;
        }
    }
}
