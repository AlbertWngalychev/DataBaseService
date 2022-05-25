using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class CharacteristicsRepo : RepoCRUDBase<Chatacteristic>, ICharacteristicsRepo
    {
        public CharacteristicsRepo(dipContext context) : base(context)
        {
        }

        public IEnumerable<Chatacteristic> GetCharacteristics()
        {
            return _context.Chatacteristics;
        }

        public override void Update(int id, Chatacteristic model)
        {
            Chatacteristic? g = _context.Chatacteristics.Where(x => x.Id == id).FirstOrDefault();
            if (g == null) throw new ArgumentOutOfRangeException(nameof(id));
            g.Name = model.Name;
            _context.Update(g);
        }
    }
}
