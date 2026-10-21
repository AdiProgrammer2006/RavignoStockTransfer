
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockTransfer.Api.Data;

namespace StockTransfer.Api.Controllers;

[ApiController]
[Route("branches")]
public class BranchesController : ControllerBase
{
    private readonly appDBContext _db;

    public BranchesController(appDBContext db)
    {
        _db = db;
    }

    [HttpGet("{id}/stock")]
    public async Task<IActionResult> GetStock(int id)
    {
        var branch = await _db.Branches
            .FindAsync(id);

        if (branch == null)
        {
            return NotFound(new
            {
                message = "Branch not found"
            });
        }

        var stock = await _db.Stocks
            .Where(s => s.BranchId == id)
            .Join(
                _db.Products,
                s => s.ProductId,
                p => p.Id,
                (s, p) => new
                {
                    productId = p.Id,
                    productName = p.Name,
                    quantity = s.Quantity
                })
            .ToListAsync();

        return Ok(new
        {
            branchId = branch.Id,
            branchName = branch.Name,
            stock
        });
    }
}
