using PizzaStoreAppLibrary;
using System;
using System.Collections.Generic;

namespace PizzaStoreApp
{
    public class Customer
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Dictionary<string, int> PrevLocationsOrdered { get; set; } // number of times ordered from locations, by name of location
        public List<Order> PreviousOrders = new List<Order>();



    }
}
