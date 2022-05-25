namespace DataBaseService.Dtos
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public int Date { get; set; }
        public int DeliveryAddressId { get; set; }
        public int StatusId { get; set; }
        public string? Promo { get; set; }
        public decimal? Sum { get; set; }
    }
}
