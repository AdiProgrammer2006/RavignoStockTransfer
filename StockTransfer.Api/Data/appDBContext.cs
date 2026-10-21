using Microsoft.EntityFrameworkCore;
using StockTransfer.Api.Models;

namespace StockTransfer.Api.Data;

public class appDBContext : DbContext
{
    public appDBContext(DbContextOptions<appDBContext> options) : base(options)
    {
    }

    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<StockTransfer.Api.Models.StockTransfer> Transfers
    => Set<StockTransfer.Api.Models.StockTransfer>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stock>()
        .HasIndex(s => new {s.BranchId, s.ProductId})
        .IsUnique();

       modelBuilder.Entity<Stock>()
    .ToTable(t => t.HasCheckConstraint(
        "CK_Stock_Quantity", "Quantity >= 0"));
    }
}