namespace OnlineShoping.Domain.Entities
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}
