using Modle = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;
using StoreDL.Entities;

namespace StoreDL
{
    public class StoreMapper : IMapper
    {
        //get
        public Modle.Customer ParseCustomer(Entity.Customer customer)
        {
            return new Modle.Customer
            {
                CustomerName = customer.CustomerName,
                PhoneNumber = customer.PhoneNumber,
                CarType = (Modle.CarType)customer.CarType,
                Id = customer.Id
            };
        }
        //Set

        public Entity.Customer ParseCustomer(Modle.Customer customer)
        {
            if(customer.Id ==null )
            {
                return new Entity.Customer
                {
                    CustomerName = customer.CustomerName,
                    PhoneNumber = customer.PhoneNumber,
                    CarType = (int)customer.CarType
                };
            }  
            return new Entity.Customer
            {
                CustomerName = customer.CustomerName,
                PhoneNumber = customer.PhoneNumber,
                CarType = (int)customer.CarType,
            };
        }

        //get order
        public Order ParseOrder(StoreOrder order)
        {
            return new Order
            {
                
                Total = order.Total,
                Id = order.Id
            };
        }
        

        //to DB(createorder)
        public StoreOrder ParseOrder(Order order)
        {
               if(order.Id ==null )
            {
                return new Entity.StoreOrder
                {
                    Customer = order.Customer.Id,
                    Total = order.Total 
                    
                };
            }  
            return new Entity.StoreOrder
            {
                Customer = order.Customer.Id,
                Total = order.Total,
                Id = (int)order.Id
            };
        }

         public Modle.Location ParseLocation(Entity.Location location)
        {
            return new Modle.Location
            {
                
                LocationName = location.LocationName,
                Address = location.LocationAddress, 
                Id = location.Id
            };
        }

        public Modle.Product ParseProduct(Entity.Product product)
        {
            return new Modle.Product
            {
                ProductName = product.ProductName,
                Price = product.ProductPrice, 
                Id = product.Id
            };
        }
    }
}