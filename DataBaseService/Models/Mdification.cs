namespace DataBaseService.Models
{
    public partial class Mdification
    {
        public Mdification()
        {
            CharacteristicsModifications = new HashSet<CharacteristicsModification>();
            OrderElements = new HashSet<OrderElement>();
            Photos = new HashSet<Photo>();
            Reviews = new HashSet<Review>();
            ShopingCarts = new HashSet<ShopingCart>();
        }

        public int Id { get; set; }
        public int ClothesId { get; set; }
        public string Name { get; set; } = null!;
        public decimal PriceFactor { get; set; }
        public int Count { get; set; }

        public virtual Сlothe Clothes { get; set; } = null!;
        public virtual ICollection<CharacteristicsModification> CharacteristicsModifications { get; set; }
        public virtual ICollection<OrderElement> OrderElements { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<ShopingCart> ShopingCarts { get; set; }
    }
}
