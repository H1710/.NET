using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWebAPI.Models;
using SalesWebAPI.Services;

namespace SalesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentsController : ControllerBase
    {
        private readonly IDepartamentService _departamentService;

        public DepartamentsController(IDepartamentService departamentService)
        {
            _departamentService = departamentService;
        }

        // GET: api/Departaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departament>>> GetDepartaments()
        {
            return Ok(await _departamentService.GetAllAsync());
        }

        // GET: api/Departaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departament>> GetDepartament(int id)
        {
            var departament = await _departamentService.GetByIdAsync(id);

            if (departament == null)
            {
                return NotFound();
            }

            return Ok(departament);
        }

        // POST: api/Departaments
        [HttpPost]
        public async Task<ActionResult<Departament>> PostDepartament(Departament departament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _departamentService.AddAsync(departament);
            return CreatedAtAction(nameof(GetDepartament), new { id = departament.Id }, departament);
        }

        // PUT: api/Departaments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartament(int id, Departament departament)
        {
            if (id != departament.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _departamentService.UpdateAsync(departament);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_departamentService.DepartamentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Departaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartament(int id)
        {
            if (!_departamentService.DepartamentExists(id))
            {
                return NotFound();
            }

            await _departamentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
