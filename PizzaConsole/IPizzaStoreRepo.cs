using PizzaStoreApp;
using PizzaStoreAppLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaConsole
{
    interface IPizzaStoreRepo
    {
        CustomerClass LoadCustomerByUsername(string username);
        IEnumerable<CustomerClass> LoadCustomerByName(string FirstName, string LastName);
        IEnumerable<StoreClass> LoadLocations();
        void AddCustomer(CustomerClass customer);
        void AddAddressToCustomer(AddressClass address, CustomerClass customer);
        void RemoveCustomerAddress(AddressClass address, CustomerClass customer);
        IEnumerable<OrderClass> LoadOrdersByLocation(StoreClass location);
        IEnumerable<OrderClass> LoadOrdersByCustomer(CustomerClass customer);
        void PlaceOrder(OrderClass order);
        void Save();
        void UpdateLocation(StoreClass location);
        void UpdateCustomer(CustomerClass customer);
        void AddIngrediantToList(string AdminUsername, string AdminPassword, string IngrediantName);
        void RemoveLocation(string AdminUsername, string AdminPassword, StoreClass location);
        CustomerClass ChangeUserPassword(string AdminUsername, string AdminPassword, CustomerClass customer, string NewPassword);

    }
}
