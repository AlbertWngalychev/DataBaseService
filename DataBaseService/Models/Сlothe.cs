namespace DataBaseService.Models
{
    public partial class Сlothe
    {
        public Сlothe()
        {
            Materials = new HashSet<Material>();
            Mdifications = new HashSet<Mdification>();
            Prices = new HashSet<Price>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int TypeId { get; set; }
        public string VendorCode { get; set; } = null!;
        public bool? Active { get; set; }
        public string Discription { get; set; } = null!;
        public int GenderId { get; set; }

        public virtual Gender Gender { get; set; } = null!;
        public virtual Type Type { get; set; } = null!;
        public virtual ICollection<Material> Materials { get; set; }
        public virtual ICollection<Mdification> Mdifications { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
