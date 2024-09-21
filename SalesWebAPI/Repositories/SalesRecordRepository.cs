using Microsoft.EntityFrameworkCore;
using SalesWebAPI.Data;
using SalesWebAPI.Models;
using SalesWebAPI.Repositories;

public class SalesRecordRepository : ISalesRecordRepository
{
    private readonly SalesWebMvcContext _context;

    public SalesRecordRepository(SalesWebMvcContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SalesRecord>> GetAllAsync()
    {
        return await _context.SalesRecord.Include(sr => sr.Seller).ToListAsync();
    }

    public async Task<SalesRecord> GetByIdAsync(int id)
    {
        return await _context.SalesRecord.Include(sr => sr.Seller).FirstOrDefaultAsync(sr => sr.Id == id);
    }

    public async Task AddAsync(SalesRecord salesRecord)
    {
        _context.SalesRecord.Add(salesRecord);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(SalesRecord salesRecord)
    {
        _context.Entry(salesRecord).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var salesRecord = await _context.SalesRecord.FindAsync(id);
        if (salesRecord != null)
        {
            _context.SalesRecord.Remove(salesRecord);
            await _context.SaveChangesAsync();
        }
    }
}
