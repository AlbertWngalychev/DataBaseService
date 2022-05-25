namespace DataBaseService.Models
{
    public partial class Client
    {
        public Client()
        {
            DeliveryAddresses = new HashSet<DeliveryAddress>();
            Reviews = new HashSet<Review>();
            ShopingCarts = new HashSet<ShopingCart>();
        }

        public int Id { get; set; }
        public string? Tel { get; set; }
        public string? EMail { get; set; }
        public int? AuthId { get; set; }
        public string? Fname { get; set; }

        public virtual Authentication? Auth { get; set; }
        public virtual ICollection<DeliveryAddress> DeliveryAddresses { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<ShopingCart> ShopingCarts { get; set; }
    }
}
