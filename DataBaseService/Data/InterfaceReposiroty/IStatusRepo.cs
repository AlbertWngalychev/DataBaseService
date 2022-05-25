using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface IStatusRepo : ICRUD<Status>, ISaveChanges
    {
        IEnumerable<Status> GetAll();
    }
}
