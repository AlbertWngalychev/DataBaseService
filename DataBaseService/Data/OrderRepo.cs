using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class OrderRepo : RepoCRUDBase<Order>, IOrderRepo
    {
        public OrderRepo(dipContext context) : base(context)
        {
        }

        public override void Update(int id, Order model)
        {
            Order? g = _context.Orders.Where(x => x.Id == id).FirstOrDefault();

            if (g == null)
                throw new ArgumentOutOfRangeException(nameof(id));

            g.DeliveryAddressId = model.DeliveryAddressId;
            g.Promo = model.Promo;
            g.Date = model.Date;
            g.StatusId = model.StatusId;
            g.Sum = model.Sum;

            _context.Update(g);
        }
    }
}
