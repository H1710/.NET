using Microsoft.AspNetCore.Mvc;
using SalesWebAPI.Models;
using SalesWebAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class SellerController : ControllerBase
{
    private readonly ISellerService _sellerService;

    public SellerController(ISellerService sellerService)
    {
        _sellerService = sellerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Seller>>> GetAll()
    {
        var sellers = await _sellerService.GetAllSellersAsync();
        return Ok(sellers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Seller>> GetById(int id)
    {
        var seller = await _sellerService.GetSellerByIdAsync(id);
        if (seller == null)
        {
            return NotFound();
        }
        return Ok(seller);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] Seller seller)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _sellerService.AddSellerAsync(seller);
        return CreatedAtAction(nameof(GetById), new { id = seller.Id }, seller);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] Seller seller)
    {
        if (id != seller.Id)
        {
            return BadRequest();
        }

        await _sellerService.UpdateSellerAsync(seller);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var existingSeller = await _sellerService.GetSellerByIdAsync(id);
        if (existingSeller == null)
        {
            return NotFound();
        }

        await _sellerService.DeleteSellerAsync(id);
        return NoContent();
    }
}
