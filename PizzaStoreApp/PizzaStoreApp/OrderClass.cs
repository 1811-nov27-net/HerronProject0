using System;
using System.Collections.Generic;
using System.Text;
using PizzaStoreApp;
using PizzaStoreAppLibrary;

namespace PizzaStoreAppLibrary
{
    public class OrderClass
    {
        public static string[] Ingrediants = { "Sausage", "Peperoni", "Black Olives", "Green Olives", "Bell Peppers", "Jalapenos", "Chicken", "Hot Sauce", "Mushrooms",
            "Pineapple", "Onions", "Tomatoes", "Extra Cheese"};
        public static double PricePerIngrediant = 1.00;
        public static double DeliveryFee = 2.00;
        public static double TaxRate = .08;
        public string Store { get; set; }
        private string _user;
        public string User { get { return _user; } }
        public List<PizzaClass> pizzas;
        private double _totalCost;
        private double _costBeforeTax;
        public double CostBeforeTax { get { return _costBeforeTax; } }
        public double TotalCost { get { return _totalCost; } }

        public OrderClass (CustomerClass customer, string password)
        {
            if(customer.CheckPassword(password))
            {
                _user = customer.Username;
                Store = customer.FavoriteStore ?? customer.PreviousOrders[customer.PreviousOrders.Count - 1].Store ?? "Main";
                
            }

        }

        public void AddPizza (PizzaClass.PizzaSize size, HashSet<string> ingrediants)
        {
            PizzaClass pizza = new PizzaClass(size, ingrediants);
            pizzas.Add(pizza);
            UpdateTotal();
        }

        public double UpdateTotal()
        {
            _totalCost = 0;
            foreach (PizzaClass pizza in pizzas)
            {
                _totalCost += pizza.Price;
            }
            _costBeforeTax = _totalCost;
            _totalCost *= (1+TaxRate); // tax
            _totalCost += DeliveryFee; // delivery fee
            return _totalCost;
        }



    }

}
