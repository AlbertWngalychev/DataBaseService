namespace DataBaseService.Dtos
{
    public class ModifReadDto
    {
        public int Id { get; set; }
        public int ClothesId { get; set; }
        public string Name { get; set; } = null!;
        public decimal PriceFactor { get; set; }
        public int Count { get; set; }
    }
}
