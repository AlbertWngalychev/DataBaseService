using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class ShopingCartRepo : RepoCRUDBase<ShopingCart>, IShopingCartRepo
    {
        public ShopingCartRepo(dipContext context) : base(context)
        {
        }

        public override void Update(int id, ShopingCart model)
        {
            ShopingCart? g = _context.ShopingCarts.Where(x => x.Id == id).FirstOrDefault();
            if (g == null) throw new ArgumentOutOfRangeException(nameof(id));
            g.DateAdd = DateTime.Now;
            g.Count = model.Count;
            g.ClientId = model.ClientId;
            g.ModificationId = model.ModificationId;
            _context.Update(g);
        }

        public override void Create(ShopingCart model)
        {
            model.DateAdd = DateTime.Now;
            base.Create(model);
        }

        public IEnumerable<ShopingCart> GetAllByClientId(int id)
        {
            return _context.ShopingCarts.Where(x => x.ClientId == id);
        }
    }
}
