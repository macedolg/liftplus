using liftplus_apiproject.Data;
using liftplus_apiproject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace liftplus_apiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreinoController : ControllerBase
    {
        private readonly LiftPLUS_DBContex _context;

        public TreinoController(LiftPLUS_DBContex context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Treino>>> GetTreinos()
        {
            return await _context.Treinos.Include(t => t.Exercicios).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Treino>> GetTreino(int id)
        {
            var treino = await _context.Treinos.Include(t => t.Exercicios).FirstOrDefaultAsync(m => m.ID == id);

            if (treino == null)
            {
                return NotFound();
            }

            return treino;
        }

        [HttpPost]
        public async Task<ActionResult<Treino>> PostTreino(Treino treino)
        {
            _context.Treinos.Add(treino);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTreino", new { id = treino.ID }, treino);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTreino(int id, Treino treino)
        {
            if (id != treino.ID)
            {
                return BadRequest();
            }

            _context.Entry(treino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreinoExists(id))
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
        public async Task<IActionResult> DeleteTreino(int id)
        {
            var treino = await _context.Treinos.FindAsync(id);
            if (treino == null)
            {
                return NotFound();
            }

            _context.Treinos.Remove(treino);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TreinoExists(int id)
        {
            return _context.Treinos.Any(e => e.ID == id);
        }

        [HttpGet("{id}/Exercicios")]
        public async Task<ActionResult<IEnumerable<ExercicioController>>> GetExerciciosByTreino(int id)
        {
            var treino = await _context.Treinos.Include(t => t.Exercicios).FirstOrDefaultAsync(t => t.ID == id);

            if (treino == null)
            {
                return NotFound();
            }

            return Ok(treino.Exercicios);
        }

        [HttpPost("{id}/AdicionarExercicio")]
        public async Task<IActionResult> AdicionarExercicio(int id, Exercicio exercicio)
        {
            var treino = await _context.Treinos.FindAsync(id);

            if (treino == null)
            {
                return NotFound();
            }

            treino.Exercicios.Add(exercicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExerciciosByTreino", new { id = treino.ID }, treino.Exercicios);
        }
    }
}

