using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class OrderElementRepo : RepoCRUDBase<OrderElement>, IOrderElementRepo
    {
        public OrderElementRepo(dipContext context) : base(context)
        {
        }

        public IEnumerable<OrderElement> GetByOrderId(int id)
        {
            return _context.OrderElements.Where(x => x.OrderId == id);
        }

        public override void Update(int id, OrderElement model)
        {
            OrderElement? temp = GetById(id);

            temp.OrderId = model.OrderId;
            temp.Price = model.Price;
            temp.ModificationId = model.ModificationId;
            temp.Count = model.Count;

            _context.OrderElements.Update(temp);
        }
    }
}
