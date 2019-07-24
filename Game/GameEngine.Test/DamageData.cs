using System.Collections.Generic;

namespace GameEngine.Test
{
    public class DamageData
    {
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
    }
}
