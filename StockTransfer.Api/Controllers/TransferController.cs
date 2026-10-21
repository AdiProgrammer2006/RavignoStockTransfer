
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockTransfer.Api.Data;
using StockTransfer.Api.Models;
using TransferEntity = StockTransfer.Api.Models.StockTransfer;

namespace StockTransfer.Api.Controllers;

[ApiController]
[Route("transfers")]
public class TransfersController : ControllerBase
{
    private readonly appDBContext _db;

    public TransfersController(appDBContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransfer(
        [FromBody] TransferRequest request)
    {
        if (request.Quantity <= 0)
            return BadRequest(new
            {
                message = "Quantity must be greater than zero."
            });

        if (request.FromBranchId == request.ToBranchId)
            return BadRequest(new
            {
                message = "Cannot transfer to the same branch."
            });

        var fromBranch = await _db.Branches
            .FindAsync(request.FromBranchId);

        var toBranch = await _db.Branches
            .FindAsync(request.ToBranchId);

        if (fromBranch == null || toBranch == null)
            return BadRequest(new
            {
                message = "Invalid branch."
            });

        var product = await _db.Products
            .FindAsync(request.ProductId);

        if (product == null)
            return BadRequest(new
            {
                message = "Product does not exist."
            });

        await using var transaction =
            await _db.Database.BeginTransactionAsync();

        var fromStock = await _db.Stocks
            .FirstOrDefaultAsync(s =>
                s.BranchId == request.FromBranchId &&
                s.ProductId == request.ProductId);

        var toStock = await _db.Stocks
            .FirstOrDefaultAsync(s =>
                s.BranchId == request.ToBranchId &&
                s.ProductId == request.ProductId);

        if (fromStock == null ||
            fromStock.Quantity < request.Quantity)
            return BadRequest(new
            {
                message = "Insufficient stock."
            });

        if (toStock == null)
        {
            toStock = new Stock
            {
                BranchId = request.ToBranchId,
                ProductId = request.ProductId,
                Quantity = 0
            };

            _db.Stocks.Add(toStock);
        }

        fromStock.Quantity -= request.Quantity;
        toStock.Quantity += request.Quantity;

        var transfer = new TransferEntity
        {
            FromBranchId = request.FromBranchId,
            ToBranchId = request.ToBranchId,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            CreatedAt = DateTime.UtcNow
        };

        _db.Transfers.Add(transfer);

        await _db.SaveChangesAsync();
        await transaction.CommitAsync();

        return Ok(new
        {
            message = "Transfer completed successfully.",
            transferId = transfer.Id
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetTransfers()
    {
        var transfers = await _db.Transfers
            .OrderByDescending(t => t.CreatedAt)
            .ThenByDescending(t => t.Id)
            .ToListAsync();

        return Ok(transfers);
    }
}
