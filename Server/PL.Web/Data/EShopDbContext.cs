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
        #region USER

        var userBuilder = builder.Entity<User>();

        // Первичный клю
        userBuilder
            .HasKey(nameof(User.ObjectID));

        // Связь с заказами
        userBuilder
            .HasMany(nameof(User.Orders))
            .WithOne(nameof(Order.Owner));

        #endregion

        #region ORDER

        var orderBuilder = builder.Entity<Order>();

        // Первичный ключ
        orderBuilder
            .HasKey(nameof(Order.ObjectID));

        // Связь с продуктами
        orderBuilder
            .HasMany(nameof(Order.Products))
            .WithMany(nameof(Product.Orders));

        orderBuilder
            .HasOne(nameof(Order.Owner));

        // Индекс
        orderBuilder
            .HasIndex(nameof(Order.Number));

        #endregion

        #region PRODUCT

        var productBuilder = builder.Entity<Product>();

        // Первичный ключ
        productBuilder
            .HasKey(nameof(Product.ObjectID));

        #endregion
    }
}
