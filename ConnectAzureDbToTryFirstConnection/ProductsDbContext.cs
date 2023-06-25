using ConnectAzureDbToTryFirstConnection.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectToAzureDbToTryFirstConnection;

public class ProductsDbContext : DbContext
{
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
        : base(options) { }

    public DbSet<Product> Product { get; set; }
    public DbSet<ProductCategory> ProductCategory { get; set; }
}