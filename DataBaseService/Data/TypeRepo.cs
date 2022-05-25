using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class TypeRepo : RepoCRUDBase<Models.Type>, ITypeRepo
    {

        public TypeRepo(dipContext context)
            : base(context)
        {
        }

        public IEnumerable<Models.Type> GetByName(string name)
        {
            return _context.Types.Where(x => x.Name == name).ToList();
        }

        public override void Update(int id, Models.Type model)
        {
            var temp = GetById(id);
            if (temp == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            temp.Name = model.Name;
            temp.CatagoryId = model.CatagoryId;

            _context.Types.Update(temp);

        }

        public IEnumerable<Models.Type> GetAll() => _context.Types.ToList();
    }
}
