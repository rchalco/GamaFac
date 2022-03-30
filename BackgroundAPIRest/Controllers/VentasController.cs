using Business.Main.Managers;
using Business.Main.Microventas;
using Domain.Main.MicroVentas.Impresion;
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

        [HttpPost("GenerarDocumento")]
        [EnableCors("MyPolicy")]
        public IActionResult GenerarDocumento(DataDocumento dataDocumento)
        {
            MangerPrinter mangerPrinter = new MangerPrinter();
            var resulMgr = mangerPrinter.GenerarDocumento(dataDocumento);
            if (resulMgr.State == Domain.Main.Wraper.ResponseType.Success)
            {
                string fileName = resulMgr.Message;
                fileName = fileName.StartsWith("\\") ? "\\" + fileName : fileName;
                return new PhysicalFileResult(fileName, System.Net.Mime.MediaTypeNames.Application.Octet);
            }

            return Problem(resulMgr.Message);
        }

    }
}
