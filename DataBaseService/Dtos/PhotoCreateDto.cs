namespace DataBaseService.Dtos
{
    public class PhotoCreateDto
    {
        public string Path { get; set; } = null!;
        public int Priopity { get; set; }
        public int ModificationId { get; set; }
    }
}
