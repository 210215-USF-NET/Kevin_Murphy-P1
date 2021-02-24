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
        public void Goodbye(){
            Console.WriteLine("Thank you come again!");
        }
        Customer newCustomer = new Customer();
        Order newOrder = new Order();
        public void Start()
        {
            
            
            
            Console.WriteLine("Welcome to the Car Parts Store");
            Console.WriteLine("Are you a new user?(Y or N)");
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
                // look up users based on numbers
                
                 
            }

             Boolean stay = true;
            do{
                //get the user name 
                Console.WriteLine("How can we help you today?");
                Console.WriteLine("[0]View your orders");
                Console.WriteLine("[1]Make a new order");
                Console.WriteLine("[2]View all locations");
                Console.WriteLine("[3]Exit");
                Console.WriteLine("Enter a number");
                string userInput = Console.ReadLine();
                Order newOrder = new Order();
                
                switch(userInput)
                {
                    case "0":
                        GetOrder();
                        // Get the get the current customer users
                        break;
                    case "1":
                      while(true){
                            try
                            {
                                CreateOrder();
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Invalid input. Try another again!\n\n" + e.Message);
                                
                            }
                        }
                        break;
                       

                    case "2":
                        Goodbye();
                        stay =false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }while(stay);
    

           
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
         public void CreateOrder()
            {
                Order newOrder = new Order();
                Customer newCustomer = new Customer();
                Console.WriteLine("Enter your Name");
                newCustomer.CustomerName = Console.ReadLine();
                Console.WriteLine("Enter your Phone number(in form(xxx)xxx-xxxx)");
                newCustomer.PhoneNumber = Console.ReadLine();
                Console.WriteLine("Enter cartype");
                newCustomer.CarType=Enum.Parse<CarType>(Console.ReadLine());
                newOrder.Customer = newCustomer;
                // Console.WriteLine("Enter Location name");
                // newOrder.Location.LocationName = Console.ReadLine();
                Location newLocation = new Location();
                newLocation.LocationName ="online store";
                newLocation.Address=("www.OnlineStore.com");
                newOrder.Location =newLocation;
                Console.WriteLine("Enter Order total");
                newOrder.Total = Convert.ToDouble(Console.ReadLine());
            
                _storeBL.AddOrder(newOrder);
            }
        public void GetOrder()
        {
            foreach (var item in _storeBL.GetOrder())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

        }
    }
}