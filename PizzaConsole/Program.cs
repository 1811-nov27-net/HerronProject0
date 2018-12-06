using PizzaStoreApp;
using PizzaStoreAppLibrary;
using System;

namespace PizzaConsole
{
    class Program
    {
        static void Main(string[] args)
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




        }
    }
}
