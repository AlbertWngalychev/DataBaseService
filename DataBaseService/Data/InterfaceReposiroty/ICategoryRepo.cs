using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface ICategoryRepo : ICRUD<Category>, ISaveChanges
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Models.Type> GetTypesByCategoById(int id);
    }
}
