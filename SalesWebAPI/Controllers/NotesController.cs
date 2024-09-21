using Microsoft.AspNetCore.Mvc;
using SalesWebAPI.Models;
using SalesWebAPI.Services.Exceptions;
using SalesWebMvc.Services;

namespace SalesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;

        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notes = await _notesService.GetAllNotesAsync();
            return Ok(notes); // Return notes as JSON
        }

        // GET: api/Notes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var note = await _notesService.GetNoteByIdAsync(id);
                return Ok(note); // Return the found note as JSON
            }
            catch (NotFoundException)
            {
                return NotFound(new { message = "Note not found" }); // Return 404 Not Found
            }
        }

        // POST: api/Notes
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title, Content")] Notes notes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return bad request if model state is invalid
            }

            await _notesService.CreateNoteAsync(notes.Title, notes.Content);
            return CreatedAtAction(nameof(GetById), new { id = notes.Id }, notes); // Return 201 Created response
        }

        // DELETE: api/Notes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _notesService.DeleteNoteAsync(id);
                return NoContent(); // Return 204 No Content on successful deletion
            }
            catch (IntegrityException e)
            {
                return BadRequest(new { message = e.Message }); // Return 400 Bad Request on integrity violation
            }
        }
    }
}
