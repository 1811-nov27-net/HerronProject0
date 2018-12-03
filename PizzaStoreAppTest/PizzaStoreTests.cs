using System;
using System.Collections.Generic;
using PizzaStoreAppLibrary;
using Xunit;

namespace PizzaStoreAppTest
{
    public class PizzaStoreTests
    {
        [Fact]
        public void NewStoreHasStock()
        {
            // arrange & act
            Location SUT = new Location();

            // assert
            foreach (KeyValuePair<string, int> entry in SUT.Invantory)
            {
                Assert.NotEqual(0,entry.Value);
            }

        }
    }
}
