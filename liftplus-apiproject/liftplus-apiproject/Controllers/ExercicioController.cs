using liftplus_apiproject.Data;
using liftplus_apiproject.Models;
using liftplus_apiproject.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace liftplus_apiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioController : ControllerBase
    {
        private readonly iExercicioRepositorio _exercicioRepositorio;

        public ExercicioController(iExercicioRepositorio exercicioRepositorio)
        {
            _exercicioRepositorio = exercicioRepositorio;
        }

        [HttpGet]
        public async Task <ActionResult<List<Exercicio>>> BuscarExercicios()
        {
            List<Exercicio> exercicios = await _exercicioRepositorio.BuscarExercicios();
            return Ok(exercicios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercicio>> BuscarExercicioID(int id)
        {
            Exercicio exercicio = await _exercicioRepositorio.BuscarExercicioId(id);
            return Ok(exercicio);
        }

        [HttpPost]
        public async Task<ActionResult<Exercicio>> AdicionarExercicio([FromBody] Exercicio exercicioModel)
        {
            Exercicio exercicio = await _exercicioRepositorio.AdicionarExercicio(exercicioModel);
            return Ok(exercicio);
        }

        [HttpDelete]
        public async Task<bool> ApagarExercicio(int id)
        {
            Exercicio exercicio = await _exercicioRepositorio.BuscarExercicioId(id);

            if (exercicio == null)
            {
                return false;
            }

            bool sucesso = await _exercicioRepositorio.ApagarExercicio(id);

            return sucesso;
        }
    }
}
