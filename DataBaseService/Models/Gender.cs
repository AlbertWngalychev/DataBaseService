namespace DataBaseService.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Сlothes = new HashSet<Сlothe>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Сlothe> Сlothes { get; set; }
    }
}
