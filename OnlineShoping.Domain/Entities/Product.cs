namespace OnlineShoping.Domain.Entities
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Price? Price { get; set; }
        public int Count { get; set; }
        public string ImgPath { get; set; }
    }
}
