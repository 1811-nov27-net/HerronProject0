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
            "Pineapple", "Onions", "Tomatoes", "Extra Cheese"};
        public static double PricePerIngrediant = 1.00;
        public Location StoreLocation { get; set; }
        public Customer CustOrdered { get; set; }
        public List<Pizza> pizzas;

    }

}
