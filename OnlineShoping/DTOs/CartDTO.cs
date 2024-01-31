namespace OnlineShoping.API.DTOs
{
    public class CartDTO
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public bool Active { get; set; }
    }
}
