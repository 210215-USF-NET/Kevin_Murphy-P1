using StoreModels;
using System;
namespace StoreUI
{
    public class LogIn : IMenu
    {
        public void Start()
        {
            Customer currentCustomer = new Customer();
            Customer newCustomer = new Customer();
            Console.WriteLine("Welcome to the Car Parts Store");
            Console.WriteLine("Are you a new user?");
            string userIn = Console.ReadLine();
            if(userIn.Equals("y",StringComparison.OrdinalIgnoreCase)){
                Console.WriteLine("Enter your Name");
                newCustomer.Name=Console.ReadLine();
                Console.WriteLine("Enter your Phone number(xxx-xxx-xxxx");
                newCustomer.PhoneNumber=Console.ReadLine();
                Console.WriteLine("Enter your what kind of car do you drive");
                newCustomer.CarType = Enum.Parse<CarType>(Console.ReadLine());
                Console.WriteLine($"Welcome {newCustomer.Name}"); 
            }
            else{
                Console.WriteLine("Welcome back!");
                Console.WriteLine("Enter your Phone number(xxx-xxx-xxxx)");
                currentCustomer.PhoneNumber=Console.ReadLine();
                //search for the user information to be able to look up 
            }


           
        }
    }
}