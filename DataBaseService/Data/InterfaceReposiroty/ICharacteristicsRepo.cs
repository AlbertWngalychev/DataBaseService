using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface ICharacteristicsRepo : ICRUD<Chatacteristic>, ISaveChanges
    {
        IEnumerable<Chatacteristic> GetCharacteristics();
    }
}
