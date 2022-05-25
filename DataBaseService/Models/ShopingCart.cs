namespace DataBaseService.Models
{
    public partial class ShopingCart
    {
        public int Id { get; set; }
        public int ModificationId { get; set; }
        public int ClientId { get; set; }
        public int Count { get; set; }
        public DateTime DateAdd { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Mdification Modification { get; set; } = null!;
    }
}
