using liftplus_apiproject.Models;

namespace liftplus_apiproject.Repositorios.Interfaces
{

    public interface iExercicioRepositorio 
    {
        Task<Exercicio> BuscarExercicioId(int id);
        Task<Exercicio> BuscarExercicios();

        Task<Exercicio> AdicionarExercicio(Exercicio exercicio);

        Task<Exercicio> AtualizarExercicio(Exercicio exercicio, int id);

        Task<bool> ApagarExercicio(int id);
    }
}
