using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class GenderRepo : RepoCRUDBase<Gender>, IGenderRepo
    {
        public GenderRepo(dipContext context) : base(context)
        {

        }
        public IEnumerable<Gender> GetAll()
        {
            return _context.Genders;
        }

        public override void Update(int id, Gender model)
        {
            Gender? g = _context.Genders.Where(x => x.Id == id).FirstOrDefault();
            if (g == null) throw new ArgumentOutOfRangeException(nameof(id));
            g.Name = model.Name;
            _context.Update(g);
        }
    }
}
