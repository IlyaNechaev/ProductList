using Microsoft.EntityFrameworkCore;

namespace PL.Web.Data;

public class EShopDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }

    public EShopDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region ORDER

        var orderBuilder = builder.Entity<Order>();

        // Первичный ключ
        orderBuilder
            .HasKey(nameof(Order.ObjectID));

        // Связь с продуктами
        orderBuilder
            .HasMany(nameof(Order.Products))
            .WithMany(nameof(Product.Orders));

        // Индекс
        orderBuilder
            .HasIndex(nameof(Order.Number));

        #endregion
    }
}
