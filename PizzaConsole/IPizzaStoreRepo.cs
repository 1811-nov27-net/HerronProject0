using PizzaStoreApp;
using PizzaStoreAppLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaConsole
{
    interface IPizzaStoreRepo
    {
        Customer LoadCustomer();
        List<Location> LoadLocations();

    }
}
