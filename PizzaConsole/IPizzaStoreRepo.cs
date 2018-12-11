using PizzaStoreApp;
using PizzaStoreAppLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaConsole
{
    interface IPizzaStoreRepo
    {
        Customer LoadCustomerByUsername(string username);
        IEnumerable<Location> LoadLocations();
        void AddCustomer(Customer customer);
        void AddAddressToCustomer(Address address, Customer customer);
        void RemoveCustomerAddress(Address address, Customer customer);
        IEnumerable<Order> LoadOrdersByLocation(Location location);
        IEnumerable<Order> LoadOrdersByCustomer(Customer customer);
        void PlaceOrder(Order order);
        void Save();
        void UpdateLocation(Location location);
        void UpdateCustomer(Customer customer);
        void AddIngrediantToList(string AdminUsername, string AdminPassword, string IngrediantName);
        void RemoveLocation(string AdminUsername, string AdminPassword, Location location);
        Customer ChangeUserPassword(string AdminUsername, string AdminPassword, Customer customer, string NewPassword);

    }
}
