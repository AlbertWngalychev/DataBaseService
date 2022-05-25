namespace DataBaseService.Dtos
{
    public class PriceReadDto
    {
        public int Id { get; set; }
        public int ClothesId { get; set; }
        public decimal FullPrice { get; set; }
        public decimal? Discount { get; set; }
        public DateTime DataFrom { get; set; }

    }
}
