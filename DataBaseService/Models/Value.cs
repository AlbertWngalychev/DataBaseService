namespace DataBaseService.Models
{
    public partial class Value
    {
        public Value()
        {
            ChatacteristicsValues = new HashSet<ChatacteristicsValue>();
        }

        public int Id { get; set; }
        public string Value1 { get; set; } = null!;

        public virtual ICollection<ChatacteristicsValue> ChatacteristicsValues { get; set; }
    }
}
