using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using liftplus_apiproject.Models;

namespace liftplus_apiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Usuario>> UserProfile()
        {
            return Ok(new List<Usuario>());
        }
    }
}
