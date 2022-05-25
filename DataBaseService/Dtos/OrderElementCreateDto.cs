namespace DataBaseService.Dtos
{
    public class OrderElementCreateDto
    {
        public int ModificationId { get; set; }
        public int Count { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }
    }
}
