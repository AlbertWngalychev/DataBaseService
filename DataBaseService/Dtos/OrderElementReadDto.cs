namespace DataBaseService.Dtos
{
    public class OrderElementReadDto
    {
        public int Id { get; set; }
        public int ModificationId { get; set; }
        public int Count { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }
    }
}
