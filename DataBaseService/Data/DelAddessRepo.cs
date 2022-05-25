using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class DelAddessRepo : IDelAddessRepo
    {
        private readonly dipContext _context;

        public DelAddessRepo(dipContext context)
        {
            _context = context;
        }
        public void CreateDeliveryAddress(DeliveryAddress da)
        {
            _context.DeliveryAddresses.Add(da);
        }

        public void DeleteDeliveryAddress(int id)
        {
            var da = _context.DeliveryAddresses.Where(x => x.Id == id).FirstOrDefault();

            if (da != null)
            {
                da.Active = false;
            }
        }

        public DeliveryAddress? GetDeliveryAddressById(int id)
        {
            return _context.DeliveryAddresses.Where(x => x.Id == id && x.Active == true).FirstOrDefault();
        }

        public IEnumerable<DeliveryAddress> GetDeliveryAddressesByClientId(int clientId)
        {
            return _context.DeliveryAddresses.Where(x => x.ClientId == clientId && x.Active == true).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
