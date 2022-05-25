using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface IClothesRepo : ICRUD<Сlothe>, ISaveChanges
    {
        IEnumerable<Сlothe> GetClothesByTypeId(int id);
        IEnumerable<Сlothe> GetClothesByGenderId(int id);

        IEnumerable<Mdification> GetMdifications(int id);

    }
}
