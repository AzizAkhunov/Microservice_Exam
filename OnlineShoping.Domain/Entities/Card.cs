namespace OnlineShoping.Domain.Entities
{
    public class Card : BaseModel
    {
        public string CardNumber { get; set; }
        public DateTime ExpareDate { get; set; }
        public decimal Amount { get; set; }
        public int UserId {  get; set; }
        public User User { get; set; }
    }
}
