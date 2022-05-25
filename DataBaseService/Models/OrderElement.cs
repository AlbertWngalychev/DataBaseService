namespace DataBaseService.Models
{
    public partial class OrderElement
    {
        public int Id { get; set; }
        public int ModificationId { get; set; }
        public int Count { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }

        public virtual Mdification Modification { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
