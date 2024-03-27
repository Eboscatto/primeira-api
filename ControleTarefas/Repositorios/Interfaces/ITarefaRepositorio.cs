using ControleTarefas.Models;

namespace ControleTarefas.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<List<TarefaModel>> BuscarTodasTarefas();

        Task<TarefaModel> BuscarTarefaId(int id);

        Task<TarefaModel> AdicionarTarefa(TarefaModel tarefa);

        Task<TarefaModel> AtualizarTarefa(TarefaModel tarefa, int id);

        Task<bool> DeletarTarefa(int id);
    }

}
