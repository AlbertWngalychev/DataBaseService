namespace DataBaseService.Models
{
    public partial class Chatacteristic
    {
        public Chatacteristic()
        {
            ChatacteristicsValues = new HashSet<ChatacteristicsValue>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ChatacteristicsValue> ChatacteristicsValues { get; set; }
    }
}
