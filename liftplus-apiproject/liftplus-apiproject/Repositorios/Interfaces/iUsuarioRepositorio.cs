using liftplus_apiproject.Models;

namespace liftplus_apiproject.Repositorios.Interfaces
{
    public interface iUsuarioRepositorio
    { 
        Task<List<Usuario>> BuscarPerfilUsuarios();

        Task<Usuario> BuscarPorId(int id);

        Task<Usuario> Adicionar(Usuario usuario);

        Task<Usuario> Atualizar(Usuario usuario, int id);

        Task<bool> Apagar(int id); 

    }
}
