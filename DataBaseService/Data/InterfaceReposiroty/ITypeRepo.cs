namespace DataBaseService.Data
{
    public interface ITypeRepo : ICRUD<Models.Type>, ISaveChanges
    {
        IEnumerable<Models.Type> GetByName(string name);
        IEnumerable<Models.Type> GetAll();
    }
}
