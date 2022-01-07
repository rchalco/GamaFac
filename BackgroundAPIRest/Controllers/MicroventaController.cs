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

    }


}
