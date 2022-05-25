namespace DataBaseService.Dtos
{
    public class DeliveryAddressReadDto
    {
        public string Country { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string House { get; set; } = null!;
        public string? Flat { get; set; }
        public int Index { get; set; }
        public int ClientId { get; set; }
        public int Id { get; set; }
    }
}
