using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface IModifRepo : ICRUD<Mdification>, ISaveChanges
    {

        IEnumerable<CharacteristicsModification> GetCharacteristicsIdsByModificationsId(int id);
    }
}
