using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface IClothRepo : ICRUD<Cloth>, ISaveChanges
    {
        IEnumerable<Cloth> GetAll();
    }
}
