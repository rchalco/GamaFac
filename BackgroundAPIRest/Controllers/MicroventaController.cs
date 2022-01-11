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
        public ResponseObject<LoginDTO> LoginUsuario(string usuario, string password)
        {
            StockManger stockManger = new StockManger();
            return stockManger.LoginUsuario(usuario, password);
        }

        [HttpPost("CambioContrasena")]
        [EnableCors("MyPolicy")]
        public ResponseObject<LoginDTO> CambioContrasena(string usuario, string password, string passwordNuevo)
        {
            StockManger stockManger = new StockManger();
            return stockManger.CambioContrasena(usuario, password, passwordNuevo);
        }

        [HttpPost("UltimasCajas")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<SaldoCajaDTO> UltimasCajas(int idEmpresa)
        {
            StockManger stockManger = new StockManger();
            return stockManger.UltimasCajas(idEmpresa);
        }

        [HttpPost("CierreCaja")]
        [EnableCors("MyPolicy")]
        public ResponseObject<SaldoCajaDTO> CierreCaja(int idCaja, decimal montoCierre, string observacion)
        {
            StockManger stockManger = new StockManger();
            return stockManger.CierreCaja(idCaja, montoCierre, observacion);
        }
    }


}
