using PizzaStoreApp;
using PizzaStoreAppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            string userInput;
            Console.WriteLine("Login (l) or Quit (q)");
            userInput = Console.ReadLine();
            while (userInput[0] != 'q' && userInput[0] != 'Q')
            {

                // load data
                string username, password;

                Console.WriteLine("Please enter your username:");
                username = Console.ReadLine();
                Console.WriteLine("Password:");
                password = Console.ReadLine();

                // find customer
                Customer customer = new Customer(username, password);

                
                Console.WriteLine("Enter (q) to quit, anything else to continue");
                userInput = Console.ReadLine();

            }



        }

        public void OrderPizza(Customer customer, string password)
        {
            string answer;

            Order CurrentOrder = new Order(customer, password);
            bool placeOrder = false, quitLoop = false;
            while (placeOrder == false && quitLoop == false)
            {
                Console.WriteLine($"Your order currently contains {CurrentOrder.pizzas.Count} pizzas.");
                Console.WriteLine("Would you like to (a)dd a pizza, (r)emove a pizza, (p)lace your order or (c)ancel your order?");
                answer = Console.ReadLine();


            }

        }

        public Pizza AddPizza(Order order)
        {

            Pizza.PizzaSize inputSize;
            Console.WriteLine("Size: ");
            foreach (var size in Enum.GetValues(typeof(Pizza.PizzaSize)))
            {
                Console.WriteLine($"{size}: {size.ToString()}");
            }

            inputSize = (Pizza.PizzaSize) Console.ReadLine()[0];

            string userInput ="y";
            HashSet<string> ingrediants = new HashSet<string>();
            while (userInput[0] != 'd' && userInput[0] != 'D')
            {
                Console.Write($"Your {inputSize.ToString()} pizza has ");
                if (ingrediants.Count == 0)
                {
                    Console.Write("no toppings");
                } else
                {
                    foreach (string topping in ingrediants)
                    {
                        Console.Write(topping);
                    }
                }
                Console.WriteLine(".");
                Console.WriteLine("To add a toping, type the topping name. When done, type (d)one.");
                userInput = Console.ReadLine();
                if (userInput[0] != 'd' && userInput[0] != 'D')
                {
                    if (Order.Ingrediants.Contains(userInput))
                    {
                        ingrediants.Add(userInput);
                    }
                    else
                    {
                        Console.WriteLine("I'm sorry, we don't have that ingrediant.");
                    }
                }

            }

            return new Pizza(inputSize,ingrediants);

        }
    }
}
