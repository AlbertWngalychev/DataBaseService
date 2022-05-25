namespace DataBaseService.Models
{
    public partial class Category
    {
        public Category()
        {
            Types = new HashSet<Type>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Type> Types { get; set; }
    }
}
