namespace OnlineShoping.Domain.Entities
{
    public class Comment : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Text { get; set; }
    }
}
