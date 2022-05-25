namespace DataBaseService.Models
{
    public partial class Material
    {
        public int Id { get; set; }
        public int ClothesId { get; set; }
        public int ClothId { get; set; }
        public int? Count { get; set; }

        public virtual Cloth Cloth { get; set; } = null!;
        public virtual Сlothe Clothes { get; set; } = null!;
    }
}
