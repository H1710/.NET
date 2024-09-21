using SalesWebAPI.Models;
using SalesWebAPI.Services.Exceptions;
using SalesWebMvc.Repositories;

namespace SalesWebMvc.Services
{
    public class NotesService : INotesService
    {
        private readonly INotesRepository _notesRepository;

        public NotesService(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public async Task<IEnumerable<Notes>> GetAllNotesAsync()
        {
            return await _notesRepository.GetAllNotesAsync();
        }

        public async Task CreateNoteAsync(string title, string content)
        {
            var note = new Notes { Title = title, Content = content };
            await _notesRepository.CreateNoteAsync(note);
        }

        public async Task<Notes> GetNoteByIdAsync(int id)
        {
            var note = await _notesRepository.GetNoteByIdAsync(id);
            if (note == null)
            {
                throw new NotFoundException("Note not found");
            }
            return note;
        }

        public async Task DeleteNoteAsync(int id)
        {
            await _notesRepository.DeleteNoteAsync(id);
        }
    }
}
