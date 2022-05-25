using DataBaseService.Models;

namespace DataBaseService.Data
{
    public abstract class RepoCRUDBase<TEntity> : ISaveChanges, ICRUD<TEntity> where TEntity : class
    {
        private protected dipContext _context;
        public RepoCRUDBase(dipContext context)
        {
            _context = context;
        }

        public virtual void Create(TEntity model)
        {
            _context.Add<TEntity>(model);
        }

        public virtual void DeleteById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            TEntity? temp = GetById(id);
            if (temp == null)
                throw new ArgumentNullException(nameof(temp));

            _context.Remove<TEntity>(GetById(id));
        }

        public virtual TEntity? GetById(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            return _context.Find<TEntity>(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public abstract void Update(int id, TEntity model);
    }
}
