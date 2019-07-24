using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Test
{
    [TestClass]
    public class PlayerCharacterShould
    {
        [TestMethod]
        public void BeInexperiencedWhenNew()
        {
            var sut = new PlayerCharacter();

            Assert.IsTrue(sut.IsNoob);
        }

        //[TestMethod]
        //public void NotHaveNickNameByDefault()
        //{
        //    var sut = new PlayerCharacter();

        //    Assert.IsNull(sut.Nickname);
        //}
    }
}
