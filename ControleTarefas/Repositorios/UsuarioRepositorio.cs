using ControleTarefas.Data;
using ControleTarefas.Models;
using ControleTarefas.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ControleTarefasDBContex _dbContext;

        public UsuarioRepositorio(ControleTarefasDBContex controleTarefasDBContex)
        {
            _dbContext = controleTarefasDBContex;
        }

        public async Task<UsuarioModel> BuscarUsuarioId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarUsuarioId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"O usuário para o ID: {id} não foi encontrando no banco de dados.");
            }
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> DeletarUsuario(int id)
        {
            UsuarioModel usuarioPorId = await BuscarUsuarioId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"O usuário para o ID: {id} não foi encontrando no banco de dados.");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

