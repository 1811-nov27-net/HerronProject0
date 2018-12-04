using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreAppLibrary
{
    public class Location
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Dictionary<string, int> Invantory = new Dictionary<string, int>();

        public Location(string givenName)
        {
            Name = givenName;
            Restock();
        }

        public void Restock()
        {
            Invantory.Clear();
            foreach (string item in Order.Ingrediants)
            {
                Invantory.Add(item, 30);
            }

        }

        public bool ServeOrder(Order order)
        {
            Dictionary<string, int> ingrediantsNeeded = new Dictionary<string, int>();
            foreach (string item in Order.Ingrediants)
            {
                ingrediantsNeeded.Add(item, 0);
            }
            foreach (Pizza pizza in order.pizzas)
            {
                foreach (string item in pizza.Ingrediants)
                {
                    ingrediantsNeeded[item]++;
                }
            }
            foreach (string item in Order.Ingrediants)
            {
                if (Invantory[item] < ingrediantsNeeded[item])
                    return false;
            }
            foreach (string item in Order.Ingrediants)
            {
                Invantory[item] -= ingrediantsNeeded[item];
            }
            return true;
        }

    }
}
