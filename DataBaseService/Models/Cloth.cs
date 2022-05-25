namespace DataBaseService.Models
{
    public partial class Cloth
    {
        public Cloth()
        {
            Materials = new HashSet<Material>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Material> Materials { get; set; }
    }
}
