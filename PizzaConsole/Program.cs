using PizzaStoreApp;
using PizzaStoreAppLibrary;
using System;

namespace PizzaConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            string userInput;
            Console.WriteLine("Login (l) or Quit (q)");
            userInput = Console.ReadLine();
            while (userInput[1] != 'q')
            {

                // load data
                string username, password, answer;

                Console.WriteLine("Please enter your username:");
                username = Console.ReadLine();
                Console.WriteLine("Password:");
                password = Console.ReadLine();

                // find customer
                Customer customer = new Customer(username, password);

                Order CurrentOrder = new Order(customer, password);
                bool placeOrder = false, quitLoop = false;
                while (placeOrder == false && quitLoop == false)
                {
                    Console.WriteLine($"Your order currently contains {CurrentOrder.pizzas.Count} pizzas.");
                    Console.WriteLine("Would you like to (a)dd a pizza, (r)emove a pizza, (p)lace your order or (c)ancel your order?");
                    answer = Console.ReadLine();


                }

                Console.WriteLine("Enter (q) to quit, anything else to continue");
                userInput = Console.ReadLine();

            }



        }

        public Pizza AddPizza(Order order)
        {
            Console.WriteLine("Size: ");
            foreach (var size in Enum.GetValues(typeof(Pizza.PizzaSize)))
            {
                Console.WriteLine($"{size}: {size.ToString()}");
            }

            return new Pizza(size,ingrediants);

        }
    }
}
