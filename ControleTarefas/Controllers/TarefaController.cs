using ControleTarefas.Models;
using ControleTarefas.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> ListarTodasTarefas()
        {
            List<TarefaModel> tarefas = await _tarefaRepositorio.BuscarTodasTarefas();
            return Ok(tarefas);
        }

        [HttpGet("{id}")] //Rota Personalizada de busca

        public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
        {
            TarefaModel tarefa = await _tarefaRepositorio.BuscarTarefaId(id);
            return Ok(tarefa);
        }

        [HttpPost]

        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepositorio.AdicionarTarefa(tarefaModel);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _tarefaRepositorio.AtualizarTarefa(tarefaModel, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]

        public async Task<bool> DeletarTarefa(int id)
        {
            bool deletado = await _tarefaRepositorio.DeletarTarefa(id);
            return (deletado);
        }
    }
}
