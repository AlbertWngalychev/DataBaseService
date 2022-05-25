namespace DataBaseService.Models
{
    public partial class Photo
    {
        public int Id { get; set; }
        public string Path { get; set; } = null!;
        public int Priopity { get; set; }
        public int ModificationId { get; set; }

        public virtual Mdification Modification { get; set; } = null!;
    }
}
