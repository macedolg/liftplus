using liftplus_apiproject.Models;

namespace liftplus_apiproject.Repositorios.Interfaces
{
    public interface iTreinoRepositorio
    { 
        Task<List<Treino>> BuscarTreinos();

        Task<Treino> BuscarTreinoID(int id);

        Task<Treino> AdicionarTreino(Treino treino);

        Task<Treino> AtualizarTreino(Treino treino, int id);

        Task<bool> ApagarTreino(int id); 

    }
}
