using DataBaseService.Models;

namespace DataBaseService.Data
{
    public interface IClientRepo
    {
        Client? GetClientById(int id);
        void UpdateClient(int id, Client newclient);

        void Create(Client client);
        void SaveChanges();

    }
}
