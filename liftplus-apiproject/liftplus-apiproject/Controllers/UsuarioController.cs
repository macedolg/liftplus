using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using liftplus_apiproject.Models;
using liftplus_apiproject.Repositorios.Interfaces;
using liftplus_apiproject.Data;
using Microsoft.EntityFrameworkCore;

namespace liftplus_apiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly iUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(iUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> BuscarTodosUsuarios()
        {
            List<Usuario> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Usuario>>> BuscarPorId(int id)
        {
            Usuario usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Cadastrar([FromBody] Usuario usuarioModel)
        {
            Usuario usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }
    }
}
