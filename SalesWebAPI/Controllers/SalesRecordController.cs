using Microsoft.AspNetCore.Mvc;
using SalesWebAPI.Controllers.Requests;
using SalesWebAPI.Models;
using SalesWebAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class SalesRecordController : ControllerBase
{
    private readonly ISalesRecordService _salesRecordService;

    public SalesRecordController(ISalesRecordService salesRecordService)
    {
        _salesRecordService = salesRecordService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SalesRecord>>> GetAll()
    {
        var salesRecords = await _salesRecordService.GetAllSalesRecordsAsync();
        return Ok(salesRecords);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SalesRecord>> GetById(int id)
    {
        var salesRecord = await _salesRecordService.GetSalesRecordByIdAsync(id);
        if (salesRecord == null)
        {
            return NotFound();
        }
        return Ok(salesRecord);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateSalesRecordRequest salesRecord)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _salesRecordService.AddSalesRecordAsync(salesRecord);
        return CreatedAtAction(nameof(GetById), new { id = salesRecord.Id }, salesRecord);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] SalesRecord salesRecord)
    {
        if (id != salesRecord.Id)
        {
            return BadRequest();
        }

        await _salesRecordService.UpdateSalesRecordAsync(salesRecord);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var existingRecord = await _salesRecordService.GetSalesRecordByIdAsync(id);
        if (existingRecord == null)
        {
            return NotFound();
        }

        await _salesRecordService.DeleteSalesRecordAsync(id);
        return NoContent();
    }
}
