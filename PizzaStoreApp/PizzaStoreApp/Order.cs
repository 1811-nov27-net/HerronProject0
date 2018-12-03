using System;
using System.Collections.Generic;
using System.Text;
using PizzaStoreApp;
using PizzaStoreAppLibrary;

namespace PizzaStoreAppLibrary
{
    public class Order
    {
        public static string[] Ingrediants = { "Sausage", "Peperoni", "Black Olives", "Green Olives", "Bell Peppers", "Jalapenos", "Chicken", "Hot Sauce", "Mushrooms",
            "Pineapple", "Onions", "Tomatoes"};
        public Dictionary<string, int> PricePerIngrediant { get; set; }
        public Location StoreLocation { get; set; }
        public Customer CustOrdered { get; set; }

    }

}
