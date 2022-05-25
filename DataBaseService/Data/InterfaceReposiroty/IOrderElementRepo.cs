using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface IOrderElementRepo : ICRUD<OrderElement>, ISaveChanges
    {
        IEnumerable<OrderElement> GetByOrderId(int id);
    }
}
