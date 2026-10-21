
namespace StockTransfer.Api.Models;

public class TransferRequest
{
    public int FromBranchId { get; set; }
    public int ToBranchId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
