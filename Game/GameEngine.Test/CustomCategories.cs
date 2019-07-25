using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Test
{
    public class PlayerDefaultsAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "Player Defaults" };
    }

    public class PlayerHealthAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "Player Health" };
    }
    //
}