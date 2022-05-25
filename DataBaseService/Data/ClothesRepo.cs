using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class ClothesRepo : RepoCRUDBase<Сlothe>, IClothesRepo
    {
        public ClothesRepo(dipContext context) : base(context)
        {
        }

        public IEnumerable<Сlothe> GetClothesByGenderId(int id)
        {
            return _context.Сlothes.Where(x => x.GenderId == id);
        }

        public IEnumerable<Сlothe> GetClothesByTypeId(int id)
        {
            return _context.Сlothes.Where(x => x.TypeId == id);
        }

        public override void Update(int id, Сlothe model)
        {
            Сlothe? c = GetById(id);
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }
            c.Active = model.Active;
            c.Name = model.Name;
            c.GenderId = model.GenderId;
            c.TypeId = model.TypeId;
            c.Discription = model.Discription;
            c.VendorCode = model.VendorCode;

            _context.Update(c);
        }
        public override void DeleteById(int id)
        {
            Сlothe? c = GetById(id);
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }
            c.Active = false;
            Update(id, c);
        }

        public IEnumerable<Mdification> GetMdifications(int id)
        {
            return _context.Mdifications.Where(x => x.ClothesId == id);
        }
    }
}
