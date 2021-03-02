using Model = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;
using StoreDL.Entities;
using System;
using StoreDL;

namespace StoreDL
{
     
     public class StoreMapper : IMapper
    {
       Model.Customer customerTemp = new Model.Customer();

        //  public Model.Customer ParseCustomer(int? customer)
        // {
            
        //     return new Model.Customer
        //     {
        //         CustomerName = customerTemp.CustomerName,
        //         PhoneNumber = customerTemp.PhoneNumber,
        //         CarType = (Model.CarType)customerTemp.CarType,
        //         Id = (int)customerTemp.Id
        //     };
        // }
        // //get
          
        public Model.Customer ParseCustomer(Entity.Customer customer)
        {
            customerTemp = new Model.Customer
            {
                CustomerName = customer.CustomerName,
                PhoneNumber = customer.PhoneNumber,
                CarType = (Model.CarType)customer.CarType,
                Id = (int)customer.Id
            };
            return new Model.Customer
            {
                CustomerName = customer.CustomerName,
                PhoneNumber = customer.PhoneNumber,
                CarType = (Model.CarType)customer.CarType,
                Id = (int)customer.Id
            };
        }
        
        //Set
        public Entity.Customer ParseCustomer(Model.Customer customer)
        {
            if(customer.Id ==null )
            {
                return new Entity.Customer
                {
                    CustomerName = customer.CustomerName,
                    PhoneNumber = customer.PhoneNumber,
                    CarType = (int)customer.CarType,
                    
                    

                   
                };
            }  
            return new Entity.Customer
            {
                CustomerName = customer.CustomerName,
                PhoneNumber = customer.PhoneNumber,
                CarType = (int)customer.CarType,
                Id = (int)customer.Id
            };
        }
        
        //get order
        public Order ParseOrder(Entity.StoreOrder order)
        { 
            return new Model.Order
            {
               
               // Customer=ParseCustomer(order.Customer),
                CFK = order.Customer,
                Location = ParseLocation(order.Location),
                LFK = order.Location,
                Total = order.Total,
                Id = (int)order.Id
            };
        }


        //to DB(createorder)
        public Entity.StoreOrder ParseOrder(Model.Order order)
        {
               if(order.Id ==null )
            {
                return new Entity.StoreOrder
                {
                    Customer =order.Customer.Id,
                    Location = order.Location.Id,
                    Total = order.Total 
                    
                };
            }  
            return new Entity.StoreOrder
            {
                Customer = order.Customer.Id,
                Total = order.Total,
                Location = order.Location.Id,
                Id = (int)order.Id
            };
        }
        //set orderITem
        public Entity.OrderItem ParseIt(Model.Item Item)
        {
               if(Item.Id ==null )
            {
                return new Entity.OrderItem
                {
                    Product =Item.PFK,
                    Quantity = Item.Quantity,
                    StoreOrder = Item.OID 
                    
                };
            }  
            return new Entity.OrderItem
            {
                Product =Item.PFK,
                Quantity = Item.Quantity,
                StoreOrder = Item.OID 
            };
        }
        //get orederItem
        public Model.Item ParseIt(Entity.OrderItem item)
        {
            return new Model.Item
            {
                Quantity = item.Quantity,
                PFK = item.Product,
                OID = (int)item.StoreOrder
            };
        }

        public Model.Location locationTemp = new Model.Location();
        public Model.Location ParseLocation(int? location)
        {
            return new Model.Location
            {
                
                LocationName = locationTemp.LocationName,
                Address = locationTemp.Address, 
                //Product = ParseProduct(location.Product),
                Id = locationTemp.Id
            };
        }
         public Model.Location ParseLocation(Entity.Location location)
        {
            return new Model.Location
            {
                
                LocationName = location.LocationName,
                Address = location.LocationAddress, 
                //Product = ParseProduct(location.Product),
                Id = location.Id
            };
        }
        //get product from db and map to model
        public Model.Product ParseProduct(Entity.Product product)
        {
            return new Model.Product
            {
                ProductName = product.ProductName,
                ProductDescription=product.ProductDescription,
                Price = product.ProductPrice, 
                Id = (int)product.Id
            };
        }
        //get the inventory -> Item
        public Item ParseItem(Inventory inventory)
        {
            return new Item
            {
                Quantity = inventory.Quantity,
                Id = inventory.Id,
                LFK = inventory.Location,
                PFK = inventory.Product

            };  
        }
        // public OIS POIS(OrderItem OI)
        // {
        //     return new OIS
        //     {
        //         Quantity = OI.Quantity,
        //         PFK = OI.Product

        //     };  
        // }
    }
}