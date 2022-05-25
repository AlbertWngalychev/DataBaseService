namespace DataBaseService.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderElements = new HashSet<OrderElement>();
        }

        public int Id { get; set; }
        public int Date { get; set; }
        public int DeliveryAddressId { get; set; }
        public int StatusId { get; set; }
        public string? Promo { get; set; }
        public decimal? Sum { get; set; }

        public virtual DeliveryAddress DeliveryAddress { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual ICollection<OrderElement> OrderElements { get; set; }
    }
}
