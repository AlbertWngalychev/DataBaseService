using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class ClothRepo : RepoCRUDBase<Cloth>, IClothRepo
    {
        public ClothRepo(dipContext context) : base(context) { }
        public IEnumerable<Cloth> GetAll()
        {
            return _context.Cloths;
        }

        public override void Update(int id, Cloth model)
        {
            Cloth? g = _context.Cloths.Where(x => x.Id == id).FirstOrDefault();
            if (g == null) throw new ArgumentOutOfRangeException(nameof(id));
            g.Name = model.Name;
            _context.Update(g);
        }
    }
}
