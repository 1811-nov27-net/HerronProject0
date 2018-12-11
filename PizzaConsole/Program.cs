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

            string UserInput;
            Console.WriteLine("Login (l), Quit (q) or Admin (a)");
            UserInput = Console.ReadLine();
            char CurrentAction = UserInput[0];
            CurrentAction = Char.ToLower(CurrentAction);
            while (CurrentAction == 'l' || CurrentAction == 'a')
            {

                // load data
                string username, password;

                Console.WriteLine("Please enter your username:");
                username = Console.ReadLine();
                Console.WriteLine("Password:");
                password = Console.ReadLine();
                
                if(CurrentAction == 'a')
                {
                    try
                    {
                        AdminLoop(username, password);
                    }
                    catch (InvalidLoginException e)
                    {
                        Console.WriteLine(e.Message);
                        
                    }
                }

                if(CurrentAction == 'l')
                {
                    try
                    {
                        CustomerLoop(username, password);

                    }
                    catch (InvalidLoginException e)
                    {
                        Console.WriteLine(e.Message);
                        
                    }
                }

                Console.WriteLine("Login (l), Quit (q) or Admin (a)");
                UserInput = Console.ReadLine();
                CurrentAction = UserInput[0];
                CurrentAction = Char.ToLower(CurrentAction);

            }



        }

        private static void AdminLoop(string username, string password)
        {
            if (username != SecretString.AdminUsername || password != SecretString.AdminPassword)
            {
                throw new InvalidLoginException("Invalid Admin Username and/or Password");
            }


        }

        private static void CustomerLoop(string username, string password)
        {

        }

        public void OrderPizza(CustomerClass customer, string password)
        {
            string answer;

            OrderClass CurrentOrder = new OrderClass(customer, password);
            bool placeOrder = false, quitLoop = false;
            while (placeOrder == false && quitLoop == false)
            {
                Console.WriteLine($"Your order currently contains {CurrentOrder.pizzas.Count} pizzas.");
                Console.WriteLine("Would you like to (a)dd a pizza, (r)emove a pizza, (p)lace your order or (c)ancel your order?");
                answer = Console.ReadLine();


            }

        }

        public PizzaClass AddPizza(OrderClass order)
        {

            PizzaClass.PizzaSize inputSize;
            Console.WriteLine("Size: ");
            foreach (var size in Enum.GetValues(typeof(PizzaClass.PizzaSize)))
            {
                Console.WriteLine($"{size}: {size.ToString()}");
            }

            inputSize = (PizzaClass.PizzaSize) Console.ReadLine()[0];

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
                    if (OrderClass.Ingrediants.Contains(userInput))
                    {
                        ingrediants.Add(userInput);
                    }
                    else
                    {
                        Console.WriteLine("I'm sorry, we don't have that ingrediant.");
                    }
                }

            }

            return new PizzaClass(inputSize,ingrediants);

        }
    }
}
