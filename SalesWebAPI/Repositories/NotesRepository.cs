using Microsoft.EntityFrameworkCore;
using SalesWebAPI.Data;
using SalesWebAPI.Models;
using SalesWebAPI.Repositories;

namespace SalesWebMvc.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private readonly SalesWebMvcContext _context;

        public NotesRepository(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notes>> GetAllNotesAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task CreateNoteAsync(Notes note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
        }

        public async Task<Notes> GetNoteByIdAsync(int id)
        {
            return await _context.Notes.FindAsync(id);
        }

        public async Task DeleteNoteAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
        }
    }
}
