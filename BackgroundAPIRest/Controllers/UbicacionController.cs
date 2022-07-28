using Business.Main.Microventas;
using Domain.Main.MicroVentas.SP;
using Domain.Main.MicroVentas.Ubicacion;
using Domain.Main.Wraper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundAPIRest.Controllers
{
    [Route("api/Ubicacion")]
    [ApiController]
    public class UbicacionController : ControllerBase
    {
        [HttpPost("ObtenerUbicaciones")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<UbicacionDTO> ObtenerUbicaciones(RequestParametrosGral requestGral)
        {
            UbicacionManager ubicacionManger = new UbicacionManager();
            return ubicacionManger.ObtenerUbicaciones(requestGral);
        }

        [HttpPost("GrabarUbicacion")]
        [EnableCors("MyPolicy")]
        public ResponseObject<UbicacionDTO> GrabarUbicacion(UbicacionDTO ubicacionDTO)
        {
            UbicacionManager ubicacionManger = new UbicacionManager();
            return ubicacionManger.GrabarUbicacion(ubicacionDTO);
        }

    }
}
