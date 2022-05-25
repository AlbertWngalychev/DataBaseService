namespace DataBaseService.Dtos
{
    public class PhotoReadDto
    {
        public int Id { get; set; }
        public string Path { get; set; } = null!;
        public int Priopity { get; set; }
        public int ModificationId { get; set; }
    }
}
