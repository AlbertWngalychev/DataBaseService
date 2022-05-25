namespace DataBaseService.Models
{
    public partial class Authentication
    {
        public Authentication()
        {
            Clients = new HashSet<Client>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public byte[] HashedPass { get; set; } = null!;
        public byte[] Salt { get; set; } = null!;

        public virtual ICollection<Client> Clients { get; set; }
    }
}
