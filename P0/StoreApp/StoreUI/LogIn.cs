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
        public Location currentLocation = new Location();
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
            else
            {
                while(true){
                    try
                    {
                        currentCustomer=SearchForCustomer(Console.ReadLine());
                        
               
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid input. Try another again!\n\n" + e.Message);
                        
                    }
                }
               Console.WriteLine("Welcome back!");
                
                 
            }

             Boolean stay = true;
            do{
                //get the user name 
                Console.WriteLine($"How can we help you today {currentCustomer.CustomerName} ?");
                Console.WriteLine("[0] Create new customer");
                Console.WriteLine("[.5] View customer info");
                Console.WriteLine("[1] Create a new order");
                Console.WriteLine("[2] Switch user (Using PhoneNumber)");
                Console.WriteLine("[3] search for location by name ");
                Console.WriteLine("[4] search for product by name ");
                Console.WriteLine("[5] Get all your orders");
                Console.WriteLine("[6] Get all products");
                Console.WriteLine("[7] Get all locations");
                Console.WriteLine("[8] Enter a specific store");
                Console.WriteLine("[9] Check what store I am at");
                Console.WriteLine("[10] Get all Products for your current location");
                Console.WriteLine("Enter a number");
                string userInput = Console.ReadLine();
                Order newOrder = new Order();
                Product newProduct = new Product();
                switch(userInput)
                {
                    case "0":
                        CreateCustomer();
                        break;
                    case ".5":
                        Console.WriteLine(currentCustomer.ToString());
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
                                Console.WriteLine(currentLocation.ToString());
                                Console.WriteLine("Invalid input. Try another again!\n\n" + e.Message);
                            }
                        }
                        break;
                    case "2":
                        SearchForCustomer();
                        break;
                    case "3":
                        SearchForLocation();
                        break;
                    case "4":
                        SearchForProduct();
                        break;
                  
                    case "5":
                        GetOrder();
                        break; 
                     case "6":
                        GetProducts();
                        break;
                    case "7":
                        GetLocations();
                        break;
                    case "8":
                        Console.WriteLine("Enter Location Name");
                        currentLocation= SearchForLocation(Console.ReadLine());
                        break;
                    case "9":
                        if(currentLocation.Id == null)
                            Console.WriteLine("\nYou currently are not at a store\n");
                        else
                        {
                            Console.WriteLine($"\n You are at the {currentLocation.LocationName}\n");
                        }
                        break;
                    case "10":
                        GetLocationItems();
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
             Console.WriteLine(currentCustomer.ToString());
            currentCustomer= foundCustomer;
            currentCustomer.Id = foundCustomer.Id;
        }
        public Customer  SearchForCustomer(string number)
        {
            Console.WriteLine("Enter your Phone Number(in form(xxx)xxx-xxxx):");
            Customer foundCustomer = _storeBL.GetCustomerByNumber(Console.ReadLine());
            if(foundCustomer == null)
            {
                Console.WriteLine("no such customer exists try making a new one");
            }

            currentCustomer = foundCustomer;
            currentCustomer.Id = foundCustomer.Id;
            Console.WriteLine(currentCustomer.ToString());
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
            // Console.WriteLine("Enter location Name");
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
            I.Product = foundProduct;
            I.PFK = foundProduct.Id;
            Console.WriteLine(foundProduct.ToString());
        }
        // public Product SearchForProduct(string name)
        // {
        //     Product foundProduct = _storeBL.GetProductByName(Console.ReadLine());
        //     if(foundProduct == null)
        //     {
        //         Console.WriteLine("no such Product exists try again#NewOrder");
        //     }
        //     Console.WriteLine(foundProduct.ToString());
        //     return foundProduct;
        // }
        public Item I = new Item(); 
        public void CreateOrder()
        {
            double total;
            Order newOrder = new Order();
            Product P = new Product();
            // Item newItem = new Item();
            
           
            while(true){
                if (currentLocation.Id == null)
                {
                    Console.WriteLine("Enter Location Name");
                    currentLocation = SearchForLocation(Console.ReadLine());
                    break;
                }
            }
            newOrder.Location= currentLocation;
            
            //while(true ){
                Console.WriteLine("Add product would you like to order[0 to exit]");
                SearchForProduct();
                Console.WriteLine("How many would you like");
                I.Quantity = (int.Parse(Console.ReadLine()));
                newOrder.Item= I;
           // }
            total = I.Product.Price*I.Quantity;
           // I.LFK = currentLocation.Id;
            
            // Console.WriteLine("Enter Order total");
            newOrder.Total = total; 
            newOrder.Customer =  currentCustomer;
            newOrder.Customer.Id = currentCustomer.Id;
            newOrder.CFK = currentCustomer.Id;
           
            //Console.WriteLine($"q={I.Quantity}\tPFK={I.PFK}\tOID={I.OID}");
            _storeBL.AddOrder(newOrder);
            Console.WriteLine(newOrder.ToString()); 

           // I.OID = (int)newOrder.Id;
            //_storeBL.AddIO(I);
        }

        public void GetOrder()
        {   
            Item OrderItem = new Item(); 
            Customer c = new Customer();
            Location l = new Location();
            foreach (var item in _storeBL.GetOrder())
            {
               
                if(item.CFK == currentCustomer.Id){

                    Console.WriteLine((_storeBL.GetCustomerById((int)item.CFK).ToString()));
                    l=_storeBL.GetLocationById((int)item.LFK);
                    Console.WriteLine(l.ToString()+"\n");
                    OrderItem=_storeBL.GetItemByOID((int)item.Id);
                    // if(OrderItem.Id ==null || OrderItem.PFK==null)
                    // {
                    //     Console.WriteLine((_storeBL.GetProductById(OrderItem.PFK)).ToString());
                    //     Console.WriteLine($"Quantity {OrderItem.Quantity}");
                    // }
                        
                    Console.WriteLine(item.ToString());
                    //_storeBL.GetOIS
                    
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

        }
        public void GetLocationItems()
        {
          
            Product P = new Product();
            foreach (var item in _storeBL.GetLocationItems())
            {
            
                    
                Console.WriteLine("Enter Location Name");
                currentLocation= SearchForLocation(Console.ReadLine());
                       
                    
                
                if(item.LFK == currentLocation.Id){
                    //Console.WriteLine(item.ToString());
                    P=_storeBL.GetProductById((int)item.PFK);
                    Console.WriteLine(P.ToString()+"\n");
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

        }

        public void GetProducts()
        {
            foreach(var item in _storeBL.GetProducts())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        public void GetLocations()
        {
            foreach(var item in _storeBL.GetLocations())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        
    }
}