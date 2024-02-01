using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Infastructure.Persistance
{
    public class OnlineShopDbContext : DbContext , IOnlineShopDbContext
    {
        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options)
            : base(options)
            => Database.Migrate();
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Price> Prices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Cards)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Products)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasOne(e => e.Price)
                .WithOne(e => e.Product)
                .HasForeignKey<Price>(e => e.ProductId)
                .IsRequired();

            modelBuilder.Entity<Company>()
                .HasOne(e => e.Address)
                .WithOne(e => e.Company)
                .HasForeignKey<Address>(e => e.CompanyId)
                .IsRequired();
        }
    }
}
