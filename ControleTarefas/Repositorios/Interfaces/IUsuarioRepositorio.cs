using ControleTarefas.Models;

namespace ControleTarefas.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();

        Task<UsuarioModel> BuscarUsuarioId(int id);

        Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario);
        
        Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id);

        Task<bool> DeletarUsuario(int id);
    }
}
