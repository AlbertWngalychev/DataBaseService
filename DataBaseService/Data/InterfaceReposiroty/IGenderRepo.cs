using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface IGenderRepo : ICRUD<Gender>, ISaveChanges
    {
        IEnumerable<Gender> GetAll();

    }
}
