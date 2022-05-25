using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class ValueRepo : RepoCRUDBase<Value>, IValueRepo
    {
        public ValueRepo(dipContext context) : base(context)
        {
        }

        public IEnumerable<Value> GetValues()
        {
            return _context.Values;
        }

        public override void Update(int id, Value model)
        {
            Value? g = _context.Values.Where(x => x.Id == id).FirstOrDefault();
            if (g == null) throw new ArgumentOutOfRangeException(nameof(id));
            g.Value1 = model.Value1;
            _context.Update(g);
        }
    }
}
