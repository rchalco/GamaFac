using Business.Main.Microventas;
using Domain.Main.MicroVentas.SP;
using Domain.Main.MicroVentas.Ventas;
using Domain.Main.Wraper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundAPIRest.Controllers
{
    [Route("api/MicroventaOperacion")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        [HttpPost("ObtieneProductosVenta")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<ResulProductoPrecioVenta> ObtieneProductosVenta(RequestSearchProduct requestSearchProduct)
        {
            VentaManager ventaManger = new VentaManager();
            return ventaManger.ObtieneProductosVenta(requestSearchProduct);
        }

        [HttpPost("RegistrarVentas")]
        [EnableCors("MyPolicy")]
        public Response RegistrarVentas(RequestRegistroVenta requestRegistroVentas)
        {
            VentaManager ventaManger = new VentaManager();
            return ventaManger.RegistrarVentas(requestRegistroVentas);
        }
    }
}
