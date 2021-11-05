﻿using SimplifiedSearch.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SimplifiedSearch.Tests.Utils
{
    internal class AssertCollectionUtils
    {
        internal static void AssertCollectionContainsEqualIds(IEnumerable<TestItem> expected, IEnumerable<TestItem> actual)
        {
            var expectedIds = expected.Select(v => v.Id).ToArray();
            var actualIds = actual.Select(v => v.Id).ToArray();
            Assert.True(expectedIds.Length == actualIds.Length, $"Lists were different lengths. Expected: {expectedIds.Length}, Actual: {actualIds.Length}");
            var intersect = expectedIds.Intersect(actualIds).ToArray();
            Assert.True(intersect.Length == expectedIds.Length, $"Lists have different content. Expected: {expectedIds.Length}, Actual: {intersect.Length}");
        }
    }
}
