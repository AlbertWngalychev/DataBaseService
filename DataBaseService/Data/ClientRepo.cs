using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class ClientRepo : IClientRepo
    {
        private readonly dipContext _context;

        public ClientRepo(dipContext context)
        {
            _context = context;
        }
        public Client? GetClientById(int id)
        {
            return _context.Clients.Where(x => x.Id == id).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateClient(int id, Client newclient)
        {
            Client? client = GetClientById(id);
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            client.Fname = newclient.Fname;
            client.Tel = newclient.Tel;
            client.EMail = newclient.EMail;

            _context.Clients.Update(client);
        }

        public void Create(Client client)
        {
            _context.Add(client);
        }
    }

}
