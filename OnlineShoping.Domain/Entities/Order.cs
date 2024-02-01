namespace OnlineShoping.Domain.Entities
{
    public class Order : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
