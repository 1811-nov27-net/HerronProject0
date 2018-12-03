using System;
using System.Collections.Generic;
using PizzaStoreApp;
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
            Location SUT = new Location("Test Name");

            // assert
            foreach (KeyValuePair<string, int> entry in SUT.Invantory)
            {
                Assert.NotEqual(0,entry.Value);
            }



        }

        [Theory]

        [InlineData("Dominoes")]
        [InlineData("Pizza Hut")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("You lost your self esteem" +
            "Along the way, yeah... O.o")]
        

        public void NewStoreHasNameGivenToConstructor(string testName)
        {
            Location SUT = new Location(testName);

            Assert.Equal(testName, SUT.Name);
        }

        [Theory]

        [InlineData("Dominoes")]
        [InlineData("Pizza Hut")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("You lost your self esteem" +
            "Along the way, yeah... O.o")]


        public void NewCustomerHasNameGivenToConstructor(string testName)
        {
            Customer SUT = new Customer(testName);

            Assert.Equal(testName, SUT.Username);
        }


        [Theory]

        [InlineData("Dominoes", "abc123","abc123",true)]
        [InlineData("", "", "", true)]
        [InlineData("L00ser", "My Cat Henrey", "password", false)]
        [InlineData("Admin", "password", "password", true)]
        [InlineData("Space Man", "", " ", false)]
        [InlineData("Nothing", "", null, false)]
        [InlineData("Null?", null, null, true)]


        public void NewCustomerPasswordCheck(string testName, string testPW, string testInput, bool expected)
        {
            // arrange
            Customer SUT = new Customer(testName, testPW);

            // act
            bool result = SUT.checkPassword(testInput);

            // assert
            Assert.Equal(result, expected);
        }


    }
}
