using Business.Main.Microventas;
using Domain.Main.MicroVentas.SP;
using Domain.Main.Wraper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundAPIRest.Controllers
{
    [Route("api/Microventa")]
    [ApiController]
    public class MicroventaController : ControllerBase
    {
        [HttpPost("SearchProduct")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<ResulSPProductosCantidad> SearchProduct(int IdEmpresa)
        {
            StockManger stockManger = new StockManger();
            return stockManger.SearchProduct(IdEmpresa);
        }

        [HttpPost("RegistrarCompra")]
        [EnableCors("MyPolicy")]
        public Response RegistrarCompra(RequestRegistrarCompra requestRegistrarCompra)
        {
            StockManger stockManger = new StockManger();
            return stockManger.RegistrarCompra(requestRegistrarCompra);
        }

        [HttpPost("LoginUsuario")]
        [EnableCors("MyPolicy")]
        public ResponseObject<LoginDTO> LoginUsuario(string Usuario, string Password)
        {
            StockManger stockManger = new StockManger();
            return stockManger.LoginUsuario(Usuario, Password);
        }

        [HttpPost("CambioContrasena")]
        [EnableCors("MyPolicy")]
        public ResponseObject<LoginDTO> CambioContrasena(string Usuario, string Password, string PasswordNuevo)
        {
            StockManger stockManger = new StockManger();
            return stockManger.CambioContrasena(Usuario, Password, PasswordNuevo);
        }

        [HttpPost("UltimasCajas")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<SaldoCajaDTO> UltimasCajas(int IdEmpresa)
        {
            StockManger stockManger = new StockManger();
            return stockManger.UltimasCajas(IdEmpresa);
        }

    }


}
