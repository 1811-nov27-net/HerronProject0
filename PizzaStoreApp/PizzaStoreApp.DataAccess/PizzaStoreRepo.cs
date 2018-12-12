using System;
using System.Collections.Generic;
using System.Text;
using PizzaStoreAppLibrary;

namespace PizzaStoreApp.DataAccess
{
    public class PizzaStoreRepo : IPizzaStoreRepo
    {

        private readonly PizzaStoreDBContext _db;

        /// <summary>
        /// Initializes a new Pizza Store repository given a suitable Entity Framework DbContext.
        /// </summary>
        /// <param name="db">The DbContext</param>
        public PizzaStoreRepo(PizzaStoreDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }


        public void AddAddressToCustomer(AddressClass address, CustomerClass customer)
        {
            throw new NotImplementedException();
        }

        public void AddCustomer(CustomerClass customer)
        {
            throw new NotImplementedException();
        }

        public void AddIngrediantToList(string AdminUsername, string AdminPassword, string IngrediantName)
        {
            throw new NotImplementedException();
        }

        public void AddStore(string AdminUsername, string AdminPassword, StoreClass location)
        {
            
        }

        public void ChangeUserPassword(string AdminUsername, string AdminPassword, CustomerClass customer, string NewPassword)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerClass> LoadCustomerByName(string FirstName, string LastName)
        {
            throw new NotImplementedException();
        }

        public CustomerClass LoadCustomerByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StoreClass> LoadLocations()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderClass> LoadOrdersByCustomer(CustomerClass customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderClass> LoadOrdersByLocation(StoreClass location)
        {
            throw new NotImplementedException();
        }

        public void PlaceOrder(OrderClass order)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomerAddress(AddressClass address, CustomerClass customer)
        {
            throw new NotImplementedException();
        }

        public void RemoveLocation(string AdminUsername, string AdminPassword, StoreClass location)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(CustomerClass customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateLocation(StoreClass location)
        {
            throw new NotImplementedException();
        }
    }
}
