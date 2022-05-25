namespace DataBaseService.Models
{
    public partial class Type
    {
        public Type()
        {
            Сlothes = new HashSet<Сlothe>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CatagoryId { get; set; }

        public virtual Category Catagory { get; set; } = null!;
        public virtual ICollection<Сlothe> Сlothes { get; set; }
    }
}
