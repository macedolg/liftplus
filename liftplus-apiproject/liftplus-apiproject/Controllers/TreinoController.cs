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
    public class TreinoController : ControllerBase
    {
        private readonly iTreinoRepositorio _treinoRepositorio;

        public TreinoController(iTreinoRepositorio treinoRepositorio)
        {
            _treinoRepositorio = treinoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Treino>>> BuscarTreinos()
        {
            List<Treino> treinos = await _treinoRepositorio.BuscarTreinos();
            return Ok(treinos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Treino>>> BuscarTreinoID(int id)
        {
            Treino treino = await _treinoRepositorio.BuscarTreinoID(id);
            return Ok(treino);
        }

        [HttpPost]
        public async Task<ActionResult<Treino>> InserirTreino([FromBody] Treino treinoModel)
        {
            Treino treino = await _treinoRepositorio.AdicionarTreino(treinoModel);
            return Ok(treino);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Treino>> UpdateTreino(int id, [FromBody] Treino treinoModel)
        {
            Treino treinoAtual = await _treinoRepositorio.BuscarTreinoID(id);

            if (treinoAtual == null)
            {
                return NotFound();
            }

            // Verifica se o campo Nome foi fornecido no corpo da solicitação
            if (!string.IsNullOrWhiteSpace(treinoModel.Nome))
            {
                treinoAtual.Nome = treinoModel.Nome;
            }

            // Verifica se o campo GrupoMuscular foi fornecido no corpo da solicitação
            if (!string.IsNullOrWhiteSpace(treinoModel.GrupoMuscular))
            {
                treinoAtual.GrupoMuscular = treinoModel.GrupoMuscular;
            }

            // Você pode adicionar verificações semelhantes para outros campos que deseja atualizar

            Treino treinoAtualizado = await _treinoRepositorio.AtualizarTreino(treinoAtual, id);

            if (treinoAtualizado == null)
            {
                return NotFound();
            }

            return Ok(treinoAtualizado);
        }



        [HttpDelete]
        public async Task<bool> ApagarTreino(int id)
        {
            Treino treino = await _treinoRepositorio.BuscarTreinoID(id);

            if (treino == null)
            {
                return false;
            }

            bool sucesso = await _treinoRepositorio.ApagarTreino(id);

            return sucesso;
        }
    }
    }


