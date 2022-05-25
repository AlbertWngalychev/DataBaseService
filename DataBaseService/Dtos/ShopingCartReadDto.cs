namespace DataBaseService.Dtos
{
    public class ShopingCartReadDto
    {
        public int Id { get; set; }
        public int ModificationId { get; set; }
        public int ClientId { get; set; }
        public int Count { get; set; }
        public DateTime DateAdd { get; set; }
    }
}
