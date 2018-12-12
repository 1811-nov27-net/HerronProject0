using PizzaStoreAppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaStoreApp.DataAccess
{
    class Mapper
    {
        public static Pizza Map(PizzaClass pizzaClass)
        {
            Pizza pizza = new Pizza();
            pizza.Size = (int) pizzaClass.Size;
            pizza.Cost = (decimal) pizzaClass.Price;

            return pizza;
        }
        public static PizzaClass Map(Pizza pizza)
        {
            HashSet<string> ingrediants = new HashSet<string>();
            foreach (var IoP in pizza.IngrediantsOnPizza)
            {

            }
            PizzaClass pizzaClass = new PizzaClass((PizzaClass.PizzaSize) pizza.Size,ingrediants);
            pizza.Cost = (decimal)pizzaClass.Price;

            return pizzaClass;
        }
    }
}
