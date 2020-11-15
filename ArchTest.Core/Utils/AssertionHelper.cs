using System;
using System.Collections.Generic;
using System.Linq;

namespace ArchTest.Core.Utils
{
    public static class AssertionHelper
    {
        public static void AssertFieldIsNotNullOrDefault(object field, string fieldName)
        {
            if (field == default || field == null)
            {
                throw new ArgumentException("Empty value", fieldName);
            }
        }

        public static void AssertCollectionIsNotNullOrEmpty<T>(List<T> collection, string fieldName)
        {
            if (collection == null || !collection.Any())
            {
                throw new ArgumentException("Empty value", fieldName);
            }
        }
    }
}
