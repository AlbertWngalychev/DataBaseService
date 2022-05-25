using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class StatusRepo : RepoCRUDBase<Status>, IStatusRepo
    {
        public StatusRepo(dipContext context) : base(context)
        {
        }

        public IEnumerable<Status> GetAll()
        {
            return _context.Statuses;
        }

        public override void Update(int id, Status model)
        {
            Status? g = _context.Statuses.Where(x => x.Id == id).FirstOrDefault();
            if (g == null) throw new ArgumentOutOfRangeException(nameof(id));
            g.Name = model.Name;
            _context.Update(g);
        }
    }
}
