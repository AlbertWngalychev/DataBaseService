namespace DataBaseService.Models
{
    public partial class ChatacteristicsValue
    {
        public ChatacteristicsValue()
        {
            CharacteristicsModifications = new HashSet<CharacteristicsModification>();
        }

        public int Id { get; set; }
        public int CharacteristicsId { get; set; }
        public int ValueId { get; set; }

        public virtual Chatacteristic Characteristics { get; set; } = null!;
        public virtual Value Value { get; set; } = null!;
        public virtual ICollection<CharacteristicsModification> CharacteristicsModifications { get; set; }
    }
}
