using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface IDelAddessRepo
    {
        DeliveryAddress? GetDeliveryAddressById(int id);
        IEnumerable<DeliveryAddress> GetDeliveryAddressesByClientId(int clientId);

        void CreateDeliveryAddress(DeliveryAddress da);
        void DeleteDeliveryAddress(int id);
        void SaveChanges();
    }
}
