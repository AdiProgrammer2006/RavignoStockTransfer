
namespace StockTransfer.Api.Models;

public class StockTransfer
{
    public int Id { get; set; }
    public int FromBranchId { get; set; }
    public int ToBranchId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
    