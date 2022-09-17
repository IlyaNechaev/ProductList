using Microsoft.EntityFrameworkCore;
using PL.Web.Models;

namespace PL.Web.Data;

public class EShopDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }

    public EShopDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region ORDER

        // Первичный ключ
        builder.Entity<Order>()
            .HasKey(nameof(Order.ObjectID));

        // Связь "многие-ко-многим"
        builder.Entity<Order>()
            .HasMany(nameof(Order.Products))
            .WithMany(nameof(Product.Orders));

        #endregion
    }
}
