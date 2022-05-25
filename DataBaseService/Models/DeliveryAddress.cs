namespace DataBaseService.Models
{
    public partial class DeliveryAddress
    {
        public DeliveryAddress()
        {
            Orders = new HashSet<Order>();
        }

        public string Country { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string House { get; set; } = null!;
        public string? Flat { get; set; }
        public int Index { get; set; }
        public bool? Active { get; set; }
        public int ClientId { get; set; }
        public int Id { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
