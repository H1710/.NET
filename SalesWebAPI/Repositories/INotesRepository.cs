using SalesWebAPI.Models;

namespace SalesWebMvc.Repositories
{
    public interface INotesRepository
    {
        Task<IEnumerable<Notes>> GetAllNotesAsync();
        Task CreateNoteAsync(Notes note);
        Task<Notes> GetNoteByIdAsync(int id);
        Task DeleteNoteAsync(int id);
    }
}
