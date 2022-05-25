using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface IOrderRepo : ICRUD<Order>, ISaveChanges
    {
    }
}
