namespace OnlineShoping.Domain.Entities
{
    public class Address : BaseModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
