using Microsoft.AspNetCore.Http;
using ControleTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using ControleTarefas.Repositorios.Interfaces;

namespace ControleTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")] //Personalizada de busca

        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarUsuarioId(id);
            return Ok(usuario);
        }

        [HttpPost]

        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.AdicionarUsuario(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepositorio.AtualizarUsuario(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")] 

        public async Task<bool> DeletarUsuario(int id)
        {
            bool deletado = await _usuarioRepositorio.DeletarUsuario(id);
            return (deletado);
        }
    }
}

