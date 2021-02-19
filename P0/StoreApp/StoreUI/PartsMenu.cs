using StoreModels;
using System;
namespace StoreUI
{
    public class PartsMenu : IMenu
    {
        public void Start()
        {
            Customer newCustomer = new Customer();
            Console.WriteLine("This is the Main Menu");
            Console.WriteLine("what is your name");
            newCustomer.Name=Console.ReadLine();
            Console.WriteLine($"Welcome {newCustomer.Name}");

        }
    }
}