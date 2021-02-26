using Model = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;
using StoreDL.Entities;

namespace StoreDL
{
    public class StoreMapper : IMapper
    {
        //get
        public Model.Customer ParseCustomer(Entity.Customer customer)
        {
            return new Model.Customer
            {
                CustomerName = customer.CustomerName,
                PhoneNumber = customer.PhoneNumber,
                CarType = (Model.CarType)customer.CarType,
                Id = customer.Id
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

         public Model.Location ParseLocation(Entity.Location location)
        {
            return new Model.Location
            {
                
                LocationName = location.LocationName,
                Address = location.LocationAddress, 
                Id = location.Id
            };
        }

        public Model.Product ParseProduct(Entity.Product product)
        {
            return new Model.Product
            {
                ProductName = product.ProductName,
                Price = product.ProductPrice, 
                Id = product.Id
            };
        }
    }
}