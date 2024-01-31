using Microsoft.EntityFrameworkCore;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.Absreactions
{
    public interface IOnlineShopDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderList> OrderLists { get; set; }
        public DbSet<Price> Prices { get; set; }


        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
