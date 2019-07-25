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

        public static void All<T>(this CollectionAssert collectionAssert,
            ICollection<T> collection,
            Action<T> assert)
        {
            foreach (var item in collection)
            {
                assert(item);
            }
        }
        public static void NotNullOrWhitespace(this StringAssert stringAssert, string actual)
        {
            if (string.IsNullOrWhiteSpace(actual))
            {
                throw new AssertFailedException("Value is null or white space");
            }
        }

        public static void AtLeastOneItemSatisfies<T>(this CollectionAssert collectionAssert,
            ICollection<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                   return;
                }
            }
            throw new AssertFailedException("No item satisfied predicate");
        }
    }
}
