namespace OnlineShoping.Domain.Entities
{
    public class Price : BaseModel
    {
        public decimal Pricee { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
