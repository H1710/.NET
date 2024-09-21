using Microsoft.EntityFrameworkCore;
using SalesWebAPI.Data;
using SalesWebAPI.Models;

namespace SalesWebAPI.Repositories
{
    public class DepartamentRepository : IDepartamentRepository
    {
        private readonly SalesWebMvcContext _context;

        public DepartamentRepository(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Departament>> GetAllAsync()
        {
            return await _context.Departament.ToListAsync();
        }

        public async Task<Departament> GetByIdAsync(int id)
        {
            return await _context.Departament.FindAsync(id);
        }

        public async Task AddAsync(Departament departament)
        {
            _context.Departament.Add(departament);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Departament departament)
        {
            _context.Entry(departament).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var departament = await _context.Departament.FindAsync(id);
            if (departament != null)
            {
                _context.Departament.Remove(departament);
                await _context.SaveChangesAsync();
            }
        }

        public bool DepartamentExists(int id)
        {
            return _context.Departament.Any(e => e.Id == id);
        }
    }
}
