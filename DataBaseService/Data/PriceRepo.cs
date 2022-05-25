using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class PriceRepo : RepoCRUDBase<Price>, IPriceRepo
    {
        public PriceRepo(dipContext context) : base(context)
        {

        }

        public IEnumerable<Price> GetPrices()
        {
            return _context.Prices;
        }

        public IEnumerable<Price> GetPricesByClothesId(int id)
        {
            return _context.Prices.Where(x => x.ClothesId == id);
        }

        public override void Update(int id, Price model)
        {
            Price? p = _context.Prices.Where(x => x.Id == id).FirstOrDefault();
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            p.FullPrice = model.FullPrice;
            p.Discount = model.Discount;
            p.ClothesId = model.ClothesId;
            p.DataFrom = model.DataFrom;

            _context.Update(p);
        }
    }
}
