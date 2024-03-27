using ControleTarefas.Data;
using ControleTarefas.Models;
using ControleTarefas.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleTarefas.Repositorios
{
    public class TarefaRepositorio: ITarefaRepositorio
    {
        private readonly ControleTarefasDBContex _dbContext;

        public TarefaRepositorio(ControleTarefasDBContex controleTarefasDBContex)
        {
            _dbContext = controleTarefasDBContex;
        }

        public async Task<TarefaModel> BuscarTarefaId(int id)
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<TarefaModel> AdicionarTarefa(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<TarefaModel> AtualizarTarefa(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarTarefaId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"O usuário para o ID: {id} não foi encontrando no banco de dados.");
            }
            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Data = tarefa.Data;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;

            _dbContext.Tarefas.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }

        public async Task<bool> DeletarTarefa(int id)
        {
            TarefaModel tarefaPorId = await BuscarTarefaId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"A tarefa para o ID: {id} não foi encontranda no banco de dados.");
            }

            _dbContext.Tarefas.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }


}
