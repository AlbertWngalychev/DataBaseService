namespace DataBaseService.Models
{
    public partial class Price
    {
        public int Id { get; set; }
        public int ClothesId { get; set; }
        public decimal FullPrice { get; set; }
        public decimal? Discount { get; set; }
        public DateTime DataFrom { get; set; }

        public virtual Сlothe Clothes { get; set; } = null!;
    }
}
