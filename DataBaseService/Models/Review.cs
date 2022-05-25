namespace DataBaseService.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public int? ModificatonId { get; set; }
        public int? ClientId { get; set; }
        public string? Advantages { get; set; }
        public string? Limitations { get; set; }
        public string? Text { get; set; }
        public int? Mark { get; set; }

        public virtual Client? Client { get; set; }
        public virtual Mdification? Modificaton { get; set; }
    }
}
