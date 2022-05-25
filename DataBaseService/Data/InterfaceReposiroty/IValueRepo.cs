using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface IValueRepo : ICRUD<Value>, ISaveChanges
    {
        IEnumerable<Value> GetValues();
    }
}
