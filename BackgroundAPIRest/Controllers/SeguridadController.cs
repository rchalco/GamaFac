using Business.Main.Microventas;
using Domain.Main.MicroVentas.Usuarios;
using Domain.Main.Wraper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundAPIRest.Controllers
{
    [Route("api/Seguridad")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {

        [HttpPost("LoginUsuario")]
        [EnableCors("MyPolicy")]
        public ResponseObject<LoginDTO> LoginUsuario(RequestLogin requestLogin)
        {
            SeguridadManager seguridadManager  = new SeguridadManager();
            return seguridadManager.LoginUsuario(requestLogin);
        }
    }
}
