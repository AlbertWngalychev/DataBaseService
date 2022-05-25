namespace DataBaseService.Dtos
{
    public class ReviewReadDto
    {
        public int Id { get; set; }
        public int? ModificatonId { get; set; }
        public int? ClientId { get; set; }
        public string? Advantages { get; set; }
        public string? Limitations { get; set; }
        public string? Text { get; set; }
        public int? Mark { get; set; }
    }
}
