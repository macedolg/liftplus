using liftplus_apiproject.Data;
using liftplus_apiproject.Models;
using liftplus_apiproject.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace liftplus_apiproject.Repositorios
{
    public class ExercicioRepositorio : iExercicioRepositorio
    {

        private readonly LiftPLUS_DBContex _dbContext;
        public ExercicioRepositorio(LiftPLUS_DBContex liftPLUS_DBContex)
        {
            _dbContext = liftPLUS_DBContex;
        }

        public async Task<Exercicio> BuscarExercicios()
        {
            return await _dbContext.Exercicios.FindAsync();
        }

        public async Task<Exercicio> BuscarExercicioId(int id)
        {
            return await _dbContext.Exercicios.FirstOrDefaultAsync(x => x.ID == id);
        }


        public async Task<Exercicio> AdicionarExercicio(Exercicio exercicio)
        {
            await _dbContext.Exercicios.AddAsync(exercicio);
            await _dbContext.SaveChangesAsync();

            return exercicio;
        }

        public async Task<Exercicio> AtualizarExercicio(Exercicio exercicio, int id)
        {
            Exercicio ExercicioPorId = await BuscarExercicioId(id);

            if (ExercicioPorId == null)
            {
                throw new Exception($"Exercicío Para o ID:{id} não encontrado");
            }

            ExercicioPorId.Nome = exercicio.Nome;

            _dbContext.Exercicios.Update(ExercicioPorId);
            await _dbContext.SaveChangesAsync();

            return ExercicioPorId;
        }

        public async Task<bool> ApagarExercicio(int id)
        {
            Exercicio ExercicioPorId = await BuscarExercicioId(id);

            if (ExercicioPorId == null)
            {
                throw new Exception($"Usuario Para o ID:{id} não encontrado");
            }

            _dbContext.Exercicios.Remove(ExercicioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
