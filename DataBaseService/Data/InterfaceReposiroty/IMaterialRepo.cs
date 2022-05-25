using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface IMaterialRepo : ICRUD<Material>, ISaveChanges
    {
        IEnumerable<Material> GetMaterialByClothesId(int id);
    }
}
