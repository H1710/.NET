using Microsoft.EntityFrameworkCore;
using SalesWebAPI.Data;
using SalesWebAPI.Models;
using SalesWebAPI.Repositories;

public class SellerRepository : ISellerRepository
{
    private readonly SalesWebMvcContext _context;

    public SellerRepository(SalesWebMvcContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Seller>> GetAllAsync()
    {
        return await _context.Seller.ToListAsync();
    }

    public async Task<Seller> GetByIdAsync(int id)
    {
        return await _context.Seller.FindAsync(id);
    }

    public async Task AddAsync(Seller seller)
    {
        _context.Seller.Add(seller);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Seller seller)
    {
        _context.Entry(seller).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var seller = await _context.Seller.FindAsync(id);
        if (seller != null)
        {
            _context.Seller.Remove(seller);
            await _context.SaveChangesAsync();
        }
    }
}
