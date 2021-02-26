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
        public Customer currentCustomer = new Customer();
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
                Console.WriteLine("[0] Create new customer");
                Console.WriteLine("[1] Create a new order");
                Console.WriteLine("[2] search for customer based on number");
                Console.WriteLine("[3] search for location by name ");
                Console.WriteLine("[4] search for product by name ");
                Console.WriteLine("[5] Get all locations");
                Console.WriteLine("Enter a number");
                string userInput = Console.ReadLine();
                Order newOrder = new Order();
                Product newProduct = new Product();
                switch(userInput)
                {
                    case "0":
                        CreateCustomer();
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
                        SearchForCustomer();
                        Goodbye();
                        stay =false;
                        break;
                    case "3":
                        SearchForLocation();
                        Goodbye();
                        stay =false;
                        break;
                    case "4":
                        SearchForProduct();
                        Goodbye();
                        stay =false;
                        break;
                    case "5":
                        //GetLocations();
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
            currentCustomer = newCustomer;
        }
        public void SearchForCustomer()
        {
            Console.WriteLine("Enter your Phone Number(in form(xxx)xxx-xxxx):");
            Customer foundCustomer = _storeBL.GetCustomerByNumber(Console.ReadLine());
            if(foundCustomer == null)
            {
                Console.WriteLine("no such customer exists try making a new one");
            }
            else
            {
                Console.WriteLine(foundCustomer.ToString());
            }
        }
        public Customer  SearchForCustomer(string number)
        {
            Console.WriteLine("Enter your Phone Number(in form(xxx)xxx-xxxx):");
            Customer foundCustomer = _storeBL.GetCustomerByNumber(Console.ReadLine());
            if(foundCustomer == null)
            {
                Console.WriteLine("no such customer exists try making a new one");
            }
            return foundCustomer;
        }
        public void SearchForLocation()
        {
            Console.WriteLine("Enter location Name");
            Location foundLocation = _storeBL.GetLocationByName(Console.ReadLine());
            
            Console.WriteLine(foundLocation.ToString());
        }
        public Location SearchForLocation(string name)
        {
            Console.WriteLine("Enter location Name");
            Location foundLocation = _storeBL.GetLocationByName(name);
            
            return foundLocation;
        }

         public void SearchForProduct()
        {
            Console.WriteLine("Enter item Name");
            Product foundProduct = _storeBL.GetProductByName(Console.ReadLine());
             if(foundProduct == null)
            {
                Console.WriteLine("no such Product exists try again");
            }
            Console.WriteLine(foundProduct.ToString());
        }

        public void CreateOrder()
        {
            Order newOrder = new Order();
            newOrder.Customer =  SearchForCustomer(Console.ReadLine());
            newOrder.Location = SearchForLocation(Console.ReadLine());
            Console.WriteLine("Enter Order total");
            newOrder.Total = double.Parse(Console.ReadLine());
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

        public void GetLocation()
        {


        }
    }
}