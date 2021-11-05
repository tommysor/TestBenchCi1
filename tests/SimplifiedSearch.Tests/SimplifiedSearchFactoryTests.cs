﻿using SimplifiedSearch.Tests.Models;
using SimplifiedSearch.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimplifiedSearch.Tests
{
    public class SimplifiedSearchFactoryTests
    {
        [Fact]
        public async Task SimplifiedSearchFactory_NoExplicitSettings_CanBeUsed()
        {
            var factory = new SimplifiedSearchFactory();
            var simplifiedSearch = factory.GetSimplifiedSearch();
            var actual = await simplifiedSearch.SimplifiedSearchAsync(TestData.UsStates, "new york", v => v.Name);
            Assert.Single(actual);
        }

        [Fact(Skip = "Functionality not implemented.")]
        public async Task SimplifiedSearchFactory_FuzzySearchMaxDifferences_IsRespected()
        {
            //todo Check test value is not default value.

            var factory = new SimplifiedSearchFactory(c => c.FuzzySearchMaxDifferences = 1);
            var search = factory.GetSimplifiedSearch();

            var list = new[]
            {
                new TestItem { Id = 1, Name = "aaaa" },
                new TestItem { Id = 2, Name = "aaaz" },
                new TestItem { Id = 3, Name = "aazz" }
            };

            var expected = list[0..2];

            var actual = await search.SimplifiedSearchAsync(list, "aaaa", v => v.Name);

            AssertCollectionUtils.AssertCollectionContainsEqualIds(expected, actual);
        }
    }
}
