using liftplus_apiproject.Data;
using liftplus_apiproject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace liftplus_apiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioController : ControllerBase
    {
        private readonly LiftPLUS_DBContex _context;

        public ExercicioController(LiftPLUS_DBContex context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercicio>>> GetExercicios()
        {
            return await _context.Exercicios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercicio>> GetExercicio(int id)
        {
            var exercicio = await _context.Exercicios.FindAsync(id);

            if (exercicio == null)
            {
                return NotFound();
            }

            return exercicio;
        }

        [HttpPost]
        public async Task<ActionResult<Exercicio>> PostExercicio(Exercicio exercicio)
        {
            _context.Exercicios.Add(exercicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExercicio", new { id = exercicio.ID }, exercicio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercicio(int id, Exercicio exercicio)
        {
            if (id != exercicio.ID)
            {
                return BadRequest();
            }

            _context.Entry(exercicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExercicioExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercicio(int id)
        {
            var exercicio = await _context.Exercicios.FindAsync(id);
            if (exercicio == null)
            {
                return NotFound();
            }

            _context.Exercicios.Remove(exercicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExercicioExists(int id)
        {
            return _context.Exercicios.Any(e => e.ID == id);
        }
    }
}
