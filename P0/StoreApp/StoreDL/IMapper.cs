using Model = StoreModels;
using Entity = StoreDL.Entities;

namespace StoreDL
{
    public interface IMapper
    {
        Model.Customer ParseCustomer(Entity.Customer customer);
       
        Entity.Customer ParseCustomer(Model.Customer customer);
        Model.Location ParseLocation(Entity.Location location);

        Model.Product ParseProduct(Entity.Product product);
        Model.Order ParseOrder(Entity.StoreOrder order);

        Entity.StoreOrder ParseOrder(Model.Order order);

        Model.Item ParseItem(Entity.Inventory inventory);
        Model.Item ParseIt(Entity.OrderItem item);
        Entity.OrderItem ParseIt(Model.Item Item);
        //Entity.StoreOrder ParseOrderFK(Model.Order order);
    }
}