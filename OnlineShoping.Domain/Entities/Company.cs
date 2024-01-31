namespace OnlineShoping.Domain.Entities
{
    public class Company : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public Address? Address { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
