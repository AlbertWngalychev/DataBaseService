using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface IPhotoRepo : ICRUD<Photo>, ISaveChanges
    {
        IEnumerable<Photo> GetAllByModifId(int id);
    }
}
