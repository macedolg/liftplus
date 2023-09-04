using liftplus_apiproject.Data;
using liftplus_apiproject.Models;
using liftplus_apiproject.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace liftplus_apiproject.Repositorios
{
    public class TreinoRepositorio : iTreinoRepositorio
    {
        private readonly LiftPLUS_DBContex _dbContext;
        public TreinoRepositorio(LiftPLUS_DBContex liftPLUS_DBContex)
        {
            _dbContext = liftPLUS_DBContex;
        }
        public async Task<List<Treino>> BuscarTreinos()
        {
            return await _dbContext.Treinos.ToListAsync();
        }

        public async Task<Treino> BuscarTreinoID(int id)
        {
            return await _dbContext.Treinos.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Treino> AdicionarTreino(Treino treino)
        {
            await _dbContext.Treinos.AddAsync(treino);
            await _dbContext.SaveChangesAsync();

            return treino;
        }

        public async Task<Treino> AtualizarTreino(Treino treino, int id)
        {
            Treino TreinoPorId = await BuscarTreinoID(id);

            if (TreinoPorId == null)
            {
                throw new Exception($"Treino Para o ID:{id} não encontrado");
            }

            TreinoPorId.Nome = treino.Nome;

            _dbContext.Treinos.Update(TreinoPorId);
            await _dbContext.SaveChangesAsync();

            return TreinoPorId;
        }

        public async Task<bool> ApagarTreino(int id)
        {
            Treino TreinoPorId = await BuscarTreinoID(id);

            if (TreinoPorId == null)
            {
                throw new Exception($"Treino Para o ID:{id} não encontrado");
            }

            _dbContext.Treinos.Remove(TreinoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}