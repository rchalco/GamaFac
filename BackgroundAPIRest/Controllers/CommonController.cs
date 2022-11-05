using Business.Main.Microventas;
using Domain.Main.MicroVentas.General;
using Domain.Main.MicroVentas.SP;
using Domain.Main.Wraper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundAPIRest.Controllers
{
    [Route("api/CommonServices")]
    [ApiController]
    public class CommonController
    {
        [HttpPost("TiposCategoriasProductos")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<ClasificadorDTO> TiposCategoriasProductos(RequestParametrosGral requestGral)
        {
            CommonManager commonManager = new CommonManager();
            return commonManager.TiposCategoriasProductos(requestGral);
        }

        [HttpPost("ObtieneProductosParaABM")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<ResulProductoPrecioVenta> ObtieneProductosParaABM(RequestParametrosGral requestGral)
        {
            CommonManager commonManager = new CommonManager();
            return commonManager.ObtieneProductosParaABM(requestGral);
        }

        [HttpPost("GrabarProductoYmenu")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<ResulProductoPrecioVenta> GrabarProductoYmenu(ResulProductoPrecioVenta requestProducto)
        {
            CommonManager commonManager = new CommonManager();
            return commonManager.GrabarProductoYmenu(requestProducto);
        }

        [HttpPost("ObtieneClasificadorPorTipo")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<ClasificadorDTO> ObtieneClasificadorPorTipo(RequestParametrosGral requestGral)
        {
            CommonManager commonManager = new CommonManager();
            return commonManager.ObtieneClasificadorPorTipo(requestGral);
        }

    }
}
