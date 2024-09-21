using SalesWebAPI.Models;

namespace SalesWebMvc.Services
{
    public interface INotesService
    {
        Task<IEnumerable<Notes>> GetAllNotesAsync();
        Task CreateNoteAsync(string title, string content);
        Task<Notes> GetNoteByIdAsync(int id);
        Task DeleteNoteAsync(int id);
    }
}
