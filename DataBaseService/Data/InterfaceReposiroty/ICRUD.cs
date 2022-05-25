namespace DataBaseService.Data
{
    public interface ICRUD<TEntity> where TEntity : class
    {
        TEntity? GetById(int id);
        void DeleteById(int id);
        void Create(TEntity model);
        void Update(int id, TEntity model);
    }
}
