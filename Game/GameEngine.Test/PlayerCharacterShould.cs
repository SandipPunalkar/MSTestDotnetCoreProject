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
        public void BeInexperiencedWhenNew()
        {
            var playerCharacter = new PlayerCharacter();

            Assert.IsTrue(playerCharacter.IsNoob);
        }

        [TestMethod]
        public void NotHaveNickNameByDefault()
        {
            var playerCharacter = new PlayerCharacter();

            Assert.IsNull(playerCharacter.Nickname);
        }

        [TestMethod]
        public void StartWithDefaultHealth()
        {
            var playerCharacter = new PlayerCharacter();
            Assert.AreEqual(100,playerCharacter.Health);
        }
        [TestMethod]
        public void TakeDamage()
        {
            var playerCharacter = new PlayerCharacter();
            playerCharacter.TakeDamage(1);
            Assert.AreEqual(99,playerCharacter.Health);
        }
        [TestMethod]
        public void TakeDamage_NotEqual()
        {
            var playerCharacter = new PlayerCharacter();
            playerCharacter.TakeDamage(1);
            Assert.AreNotEqual(100, playerCharacter.Health);
        }
        [TestMethod]
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