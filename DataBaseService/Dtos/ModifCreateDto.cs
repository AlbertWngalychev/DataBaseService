namespace DataBaseService.Dtos
{
    public class ModifCreateDto
    {
        public int ClothesId { get; set; }
        public string Name { get; set; } = null!;
        public decimal PriceFactor { get; set; }
        public int Count { get; set; }
    }
}
