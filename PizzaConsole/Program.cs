using Microsoft.EntityFrameworkCore;
using PizzaStoreApp;
using pda = PizzaStoreApp.DataAccess;
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

            var optionsBuilder = new DbContextOptionsBuilder<pda.PizzaStoreDBContext>();
            optionsBuilder.UseSqlServer(SecretString.ConnectionString);
            var options = optionsBuilder.Options;

            var dbContext = new pda.PizzaStoreDBContext(options);
            IPizzaStoreRepo PR = new pda.PizzaStoreRepo(dbContext);


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

                if (CurrentAction == 'a')
                {
                    try
                    {
                        AdminLoop(username, password, PR);
                    }
                    catch (InvalidLoginException e)
                    {
                        Console.WriteLine(e.Message);

                    }
                }

                if (CurrentAction == 'l')
                {
                    try
                    {
                        CustomerLoop(username, password, PR);

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

        private static void AdminLoop(string username, string password, IPizzaStoreRepo PR)
        {
            if (username != SecretString.AdminUsername || password != SecretString.AdminPassword)
            {
                throw new InvalidLoginException("Invalid Admin Username and/or Password");
            }
            Console.WriteLine("(A)dd location, (C)lose location, display order history by (u)ser, display order history by " +
                "(l)ocation, search user by (n)ame, display details of an (o)rder (any other key to quit).");
            string UserInput = Console.ReadLine();
            char CurrentAction = Char.ToLower(UserInput[0]);
            char[] AcceptableActions = { 'a', 'c', 'u', 'l', 'n', 'o' };
            while (Array.Exists<char>(AcceptableActions, c => c == CurrentAction))
            {
                if (CurrentAction == 'a')
                {
                    AddLocation(username, password, PR);
                }
                if (CurrentAction == 'c')
                {
                    CloseLocation(username, password, PR);
                }
                if (CurrentAction == 'u')
                {
                    OrderHistoryByName(username, password, PR);
                }
                if (CurrentAction == 'l')
                {
                    OrderHistoryByLocation(username, password, PR);
                }
                if (CurrentAction == 'n')
                {
                    SearchUserByName(username, password, PR);
                }
                if (CurrentAction == 'o')
                {
                    DetailsOfOrder(username, password, PR);
                }


                Console.WriteLine("(A)dd location, (C)lose location, display order history by (u)ser, display order history by " +
                  "(l)ocation, search user by (n)ame, display details of an (o)rder (any other key to quit).");
                UserInput = Console.ReadLine();
                CurrentAction = Char.ToLower(UserInput[0]);

            }


        }

        private static void AddLocation(string username, string password, IPizzaStoreRepo PR)
        {
            Console.WriteLine("Creating new store");
            Console.WriteLine("Store Name:");
            StoreClass NewStore = new StoreClass(Console.ReadLine());
            try
            {

                Console.WriteLine("Address, line 1:");
                NewStore.Address.Street = Console.ReadLine();
                Console.WriteLine("Address, line 2:");
                NewStore.Address.Apartment = Console.ReadLine();
                Console.WriteLine("City:");
                NewStore.Address.City = Console.ReadLine();
                Console.WriteLine("State:");
                NewStore.Address.State = Console.ReadLine();
                Console.WriteLine("Zip:");
                int tempZip;
                Int32.TryParse(Console.ReadLine(), out tempZip);
                NewStore.Address.Zip = tempZip;

                PR.AddStore(AdminUsername: username, AdminPassword: password, location: NewStore);
                PR.Save();

            }
            catch (InvalidNullFieldException e)
            {
                Console.WriteLine($"Error: {e.Message} cannot be null");
                return;
                
            }
            catch (InvalidLoginException e)
            {
                Console.WriteLine("Admin Login or Password does not match database. Contact DB Admin.");
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine("Store added.");
        }

        private static void CloseLocation(string username, string password, IPizzaStoreRepo PR)
        {
            Console.WriteLine("Store name:");
            string NameOfLocationToClose = Console.ReadLine();
            List<StoreClass> stores = (List<StoreClass>) PR.LoadLocations();
            StoreClass StoreToClose = stores.Where(s => s.Name == NameOfLocationToClose).First();
            if(StoreToClose == null)
            {
                Console.WriteLine("No store by that name found.");
                return;
            }
            Console.WriteLine($"Are you sure you want to close the location {StoreToClose.Name} in {StoreToClose.Address.City}, {StoreToClose.Address.State}?");
            string answer = Console.ReadLine();
            if(answer == "Yes")
            {
                try
                {
                    PR.RemoveLocation(username, password, StoreToClose);
                    PR.Save();
                    Console.WriteLine("Store Removed.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    
                }
            }
            else
            {
                Console.WriteLine("Store closure canceled.");
            }

        }
        private static void SearchUserByName(string username, string password, IPizzaStoreRepo PR)
        {

        }
        private static void OrderHistoryByLocation(string username, string password, IPizzaStoreRepo PR)
        {

        }
        private static void OrderHistoryByName(string username, string password, IPizzaStoreRepo PR)
        {

        }
        private static void DetailsOfOrder(string username, string password, IPizzaStoreRepo PR)
        {

        }


        private static void CustomerLoop(string username, string password, IPizzaStoreRepo PR)
        {

        }

        public void OrderPizza(CustomerClass customer, string password)
        {
            string answer;
            char ans;
            OrderClass CurrentOrder = new OrderClass(customer, password);
            bool placeOrder = false, quitLoop = false;
            while (placeOrder == false && quitLoop == false)
            {
                Console.WriteLine($"Your order currently contains {CurrentOrder.pizzas.Count} pizzas.");
                Console.WriteLine("Would you like to (a)dd a pizza, (r)emove a pizza, (p)lace your order or (c)ancel your order?");
                answer = Console.ReadLine();
                ans = Char.ToLower(answer[0]);

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

            inputSize = (PizzaClass.PizzaSize)Console.ReadLine()[0];

            string userInput = "y";
            HashSet<string> ingrediants = new HashSet<string>();
            while (userInput[0] != 'd' && userInput[0] != 'D')
            {
                Console.Write($"Your {inputSize.ToString()} pizza has ");
                if (ingrediants.Count == 0)
                {
                    Console.Write("no toppings");
                }
                else
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

            return new PizzaClass(inputSize, ingrediants);

        }
    }
}
