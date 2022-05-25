using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class CategoryRepo : RepoCRUDBase<Category>, ICategoryRepo
    {
        public CategoryRepo(dipContext contex) : base(contex)
        {

        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }

        public IEnumerable<Models.Type> GetTypesByCategoById(int id)
        {
            return _context.Types.Where(x => x.CatagoryId == id);
        }

        public override void Update(int id, Category model)
        {
            var c = GetById(id);
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }
            c.Name = model.Name;
            _context.Update(c);
        }
    }
}
