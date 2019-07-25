using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Test
{
    public static class CustomAsserts
    {
        public static void IsRange(this Assert assert, int actual, int expectedMinValue, int expectedMaxValue)
        {
            if (actual < expectedMinValue || actual > expectedMaxValue)
            {
                throw new AssertFailedException($"{actual} was not in the range {expectedMinValue} -{expectedMaxValue}");
            }
        }
    }
}
