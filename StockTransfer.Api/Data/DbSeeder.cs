
using StockTransfer.Api.Models;

namespace StockTransfer.Api.Data;

public static class DbSeeder
{
    public static void Seed(appDBContext db)
    {
        db.Database.EnsureCreated();

        if (db.Branches.Any())
            return;

        db.Branches.AddRange(
            new Branch { Id = 1, Name = "Colombo" },
            new Branch { Id = 2, Name = "Kandy" },
            new Branch { Id = 3, Name = "Galle" }
        );

        db.Products.AddRange(
            new Product { Id = 1, Name = "Rice" },
            new Product { Id = 2, Name = "Sugar" },
            new Product { Id = 3, Name = "Milk Powder" },
            new Product { Id = 4, Name = "Tea" },
            new Product { Id = 5, Name = "Flour" }
        );

        db.SaveChanges();

        for (int branchId = 1; branchId <= 3; branchId++)
        {
            for (int productId = 1; productId <= 5; productId++)
            {
                db.Stocks.Add(new Stock
                {
                    BranchId = branchId,
                    ProductId = productId,
                    Quantity = 50
                });
            }
        }

        db.SaveChanges();
    }
}
