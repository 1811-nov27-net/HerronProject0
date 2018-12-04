using PizzaStoreAppLibrary;
using System;
using System.Collections.Generic;

namespace PizzaStoreApp
{
    public class Customer
    {
        public string Username { get; set; }
        private string Password;
        private int failedPasswordChecks;
        public Address Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FavoriteStore { get; set; }
        public Dictionary<string, int> PrevLocationsOrdered { get; set; } // number of times ordered from locations, by name of location
        public List<Order> PreviousOrders = new List<Order>();

        public Customer(string newUsername)
        {
            Username = newUsername;
        }

        public Customer(string newUsername, string newPassword)
        {
            Username = newUsername;
            Password = newPassword;
        }

        public bool CheckPassword(string testPassword)
        {
            if (failedPasswordChecks > 3)
            {
                Console.WriteLine("Account locked; more than three failed login attempts"); // use error throw-catch here later?
                return false;
            }

            if (testPassword == Password)
            {
                failedPasswordChecks = 0;
                return true;
            }
            else
            {
                failedPasswordChecks++;
                return false;
            }
        }

        public bool AdminPasswordReset(string adminUsername, string adminPassword, string newPassword)
        {
            if(adminUsername == "PizzaTheHutt" && adminPassword == "Barf... Puke... whatever!")
            {
                Password = newPassword;
                failedPasswordChecks = 0;
                return true;
            }
            // mail to someone: failed admin override attempted
            return false;
        }


    }
}
