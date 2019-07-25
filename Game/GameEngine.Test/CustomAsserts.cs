using System;
using System.Collections.Generic;
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

        public static void AllItemNotNullOrWhitespace(this CollectionAssert collectionAssert,
            ICollection<string> collection)
        {
            foreach (var item in collection)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    throw  new AssertFailedException("One or more items are null or white space");
                }
            }
        }

        public static void AllItemSatisfy<T>(this CollectionAssert collectionAssert,
            ICollection<T> collection,Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if (!predicate(item))
                {
                    throw new AssertFailedException("All items do not satisfy predicate");
                }
            }
        }

    }
}
