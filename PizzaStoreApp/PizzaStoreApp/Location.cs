using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreAppLibrary
{
    public class Location
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Dictionary<string, int> Invantory { get; set; }


    }
}
