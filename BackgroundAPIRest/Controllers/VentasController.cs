using Business.Main.Managers;
using Business.Main.Microventas;
using Domain.Main.MicroVentas.General;
using Domain.Main.MicroVentas.Impresion;
using Domain.Main.MicroVentas.SP;
using Domain.Main.MicroVentas.Ventas;
using Domain.Main.Wraper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers;

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

        [HttpPost("RegistrarPedidoTintoreria")]
        [EnableCors("MyPolicy")]
        public Response RegistrarPedidoTintoreria(RequestRegistroPedido requestRegistroPedido)
        {
            TintoreriaManager tintoreriaManager = new TintoreriaManager();
            return tintoreriaManager.RegistrarVentas(requestRegistroPedido);
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
        [HttpPost("ObtieneFormasdePago")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<ResulObtieneFormasdePago> ObtieneFormasdePago(RequestSPObtFormasDePago requestSPObtFormasDePago)
        {
            VentaManager ventaManger = new VentaManager();
            return ventaManger.ObtieneFormasdePago(requestSPObtFormasDePago);
        }

        [HttpPost("ObtieneProductosVentaExpress")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<ResulProductoPrecioVentaComplex> ObtieneProductosVentaExpress(RequestSearchProduct requestSearchProduct)
        {
            VentaManager ventaManger = new VentaManager();
            return ventaManger.ObtienePorAlmacenExpress(requestSearchProduct);
        }

        [HttpPost("ObtieneProductosVentaExpressSimple")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<ResulProductoPrecioVenta> ObtieneProductosVentaExpressSimple(RequestSearchProduct requestSearchProduct)
        {
            VentaManager ventaManger = new VentaManager();
            return ventaManger.ObtienePorAlmacenExpressSimple(requestSearchProduct);
        }


        [HttpPost("FullPathArchivo"), DisableRequestSizeLimit]
        [EnableCors("MyPolicy")]
        public ResponseObject<ImagenDTO> FullPathArchivo()
        {
            ResponseObject<ImagenDTO> resul = new ResponseObject<ImagenDTO> { Message = "Imagen Cargada", State = ResponseType.Success };
            //Response resul = new Response();
            VentaManager ventaManager = new VentaManager();
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Solcitudes", DateTime.Now.ToString("yyyyMMdd"));
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);

                }
                if (file.Length > 0)
                {
                    //var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"').Replace(".xlsx", "").Replace(".xls", "") + DateTime.Now.ToString("yyyyMMdd") + ".xls"
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    string contenidoImagenB64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(fullPath));
                    resul.Object = new ImagenDTO();
                    resul.Object.fullPath = fullPath;
                    resul.Object.imagen = contenidoImagenB64;
                }
                else
                {
                    resul = new ResponseObject<ImagenDTO> { State = ResponseType.Warning, Message = "Error el archivo pesa 0 bytes!!!!" };
                }
            }
            catch (Exception ex)
            {
                ventaManager.ProcessError(ex, resul);
            }
            return resul;
        }

        [HttpPost("ObtienePedidosPorEntregarExpress")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<PedidosPorEntregarDTO> ObtienePedidosPorEntregarExpress(RequestParametrosGral requestParametrosGral)
        {
            VentaManager ventaManger = new VentaManager();
            return ventaManger.ObtienePedidosPorEntregarExpress(requestParametrosGral);
        }

        [HttpPost("ActualizaPedidoExpress")]
        [EnableCors("MyPolicy")]
        public Response ActualizaPedidoExpress(RequestParametrosGral requestParametrosGral)
        {
            VentaManager ventaManger = new VentaManager();
            return ventaManger.ActualizaPedidoExpress(requestParametrosGral);
        }

        [HttpPost("CambiaFormaPagoPedido")]
        [EnableCors("MyPolicy")]
        public Response CambiaFormaPagoPedido(RequestParametrosGral requestParametrosGral)
        {
            VentaManager ventaManger = new VentaManager();
            return ventaManger.CambiaFormaPagoPedido(requestParametrosGral);
        }

    }
}
