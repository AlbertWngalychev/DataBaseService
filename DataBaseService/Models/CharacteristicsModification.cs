namespace DataBaseService.Models
{
    public partial class CharacteristicsModification
    {
        public int Id { get; set; }
        public int ModificationId { get; set; }
        public int CharacteristicsValueId { get; set; }

        public virtual ChatacteristicsValue CharacteristicsValue { get; set; } = null!;
        public virtual Mdification Modification { get; set; } = null!;
    }
}
