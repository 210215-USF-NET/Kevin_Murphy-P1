using StoreModels;
using System;
using StoreBL;
namespace StoreUI
{
    public class LogIn : IMenu
    {
        private IPartsBL _storeBL;
        public LogIn(IPartsBL storeBL)
        {
            _storeBL = storeBL;
        }
        public void Start()
        {
            //Customer currentCustomer = new Customer();
            Customer newCustomer = new Customer();
            Console.WriteLine("Welcome to the Car Parts Store");
            Console.WriteLine("Are you a new user?");
            string userIn = Console.ReadLine();
            if(userIn.Equals("y",StringComparison.OrdinalIgnoreCase)){
                while(true){
                    try
                    {
                        CreateCustomer();
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid input. Try another again!\n\n" + e.Message);
                        
                    }
                }
                
            }
            else{

                Console.WriteLine("Welcome back!");
                Console.WriteLine("Enter your Phone number(xxx-xxx-xxxx)");
                //currentCustomer.PhoneNumber=Console.ReadLine();
                //search for the user information to be able to look up 
            }


           
        }
            public void CreateCustomer()
            {
                Customer newCustomer = new Customer();
                Console.WriteLine("Enter your Name");
                newCustomer.CustomerName=Console.ReadLine();
                Console.WriteLine("Enter your Phone number(in form(xxx)xxx-xxxx)");
                newCustomer.PhoneNumber=Console.ReadLine();
                Console.WriteLine("Enter your what kind of car do you drive");
                newCustomer.CarType = Enum.Parse<CarType>(Console.ReadLine());
                Console.WriteLine($"Welcome {newCustomer.CustomerName}"); 
                _storeBL.AddCustomer(newCustomer);
            }
    }
}