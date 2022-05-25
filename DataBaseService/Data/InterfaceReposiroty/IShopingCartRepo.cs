using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface IShopingCartRepo : ICRUD<ShopingCart>, ISaveChanges
    {
        IEnumerable<ShopingCart> GetAllByClientId(int id);
    }
}
