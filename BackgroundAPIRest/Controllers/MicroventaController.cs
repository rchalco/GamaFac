using Business.Main.Microventas;
using Domain.Main.MicroVentas.Cajas;
using Domain.Main.MicroVentas.General;
using Domain.Main.MicroVentas.SP;
using Domain.Main.MicroVentas.Usuarios;
using Domain.Main.MicroVentas.Ventas;
using Domain.Main.Wraper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackgroundAPIRest.Controllers
{
    [Route("api/Microventa")]
    [ApiController]
    public class MicroventaController : ControllerBase
    {
        [HttpPost("SearchProduct")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<ResulSPProductosCantidad> SearchProduct(RequestParametrosGral requestSearchProduct)
        {
            StockManger stockManger = new StockManger();
            return stockManger.SearchProduct(requestSearchProduct);
        }

        [HttpPost("RegistrarCompra")]
        [EnableCors("MyPolicy")]
        public Response RegistrarCompra(RequestRegistrarCompra requestRegistrarCompra)
        {
            StockManger stockManger = new StockManger();
            return stockManger.RegistrarCompra(requestRegistrarCompra);
        }

        //[HttpPost("LoginUsuario")]
        //[EnableCors("MyPolicy")]
        //public ResponseObject<LoginDTO> LoginUsuario(RequestLogin requestLogin)
        //{
        //    StockManger stockManger = new StockManger();
        //    return stockManger.LoginUsuario(requestLogin);
        //}

        //[HttpPost("CambioContrasena")]
        //[EnableCors("MyPolicy")]
        //public ResponseObject<LoginDTO> CambioContrasena(RequestLogin requestLogin)
        //{
        //    StockManger stockManger = new StockManger();
        //    return stockManger.CambioContrasena(requestLogin.usuario, requestLogin.password, requestLogin.passwordNuevo);
        //}

        [HttpPost("UltimasCajas")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<SaldoCajaDTO> UltimasCajas(SaldoCajaDTO objSaldoCajaDTO)
        {
            StockManger stockManger = new StockManger();
            return stockManger.UltimasCajas(objSaldoCajaDTO);
        }

        [HttpPost("CierreCaja")]
        [EnableCors("MyPolicy")]
        public ResponseObject<SaldoCajaDTO> CierreCaja(SaldoCajaDTO requestCierreCaja)
        {
            StockManger stockManger = new StockManger();
            return stockManger.CierreCaja(requestCierreCaja);
        }

        [HttpPost("ObtieneCaja")]
        [EnableCors("MyPolicy")]
        public ResponseObject<SaldoCajaDTO> ObtieneCaja(RequestParametrosGral requestGral)
        {
            StockManger stockManger = new StockManger();
            return stockManger.ObtieneCaja(requestGral);
        }

        [HttpPost("AperturaCaja")]
        [EnableCors("MyPolicy")]
        public ResponseObject<SaldoCajaDTO> AperturaCaja(SaldoCajaDTO requestAperturaCaja)
        {
            StockManger stockManger = new StockManger();
            return stockManger.AperturaCaja(requestAperturaCaja);
        }

        [HttpPost("LugarConsumo")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<LugarConsumoDTO> LugarConsumo(RequestParametrosGral requestGral)
        {
            StockManger stockManger = new StockManger();
            return stockManger.LugarConsumo(requestGral);
        }
        [HttpPost("ListaMeseros")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<PersonaResumenDTO> ListaMeseros(RequestParametrosGral requestGral)
        {
            StockManger stockManger = new StockManger();
            return stockManger.ListaMeseros(requestGral);
        }

        [HttpPost("GrabaPedido")]
        [EnableCors("MyPolicy")]
        public ResponseObject<TransaccionVentasDTO> GrabaPedido(TransaccionVentasDTO transaccionVentas)
        {
            StockManger stockManger = new StockManger();
            return stockManger.GrabaPedido(transaccionVentas);
        }

        [HttpPost("GrabaPedido1")]
        [EnableCors("MyPolicy")]
        public ResponseObject<TransaccionVentasDTO> GrabaPedido1(RequestParametrosGral transaccionVentas)
        {
            StockManger stockManger = new StockManger();
            return null;
        }


        [HttpPost("FinalizarPedido")]
        [EnableCors("MyPolicy")]
        public ResponseObject<TransaccionVentasDTO> FinalizarPedido(TransaccionVentasDTO transaccionVentas)
        {
            StockManger stockManger = new StockManger();
            return stockManger.FinalizarPedido(transaccionVentas);
        }


        [HttpPost("TransaccionesDetallePorID")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<TransaccionVentasDetalleDTO> TransaccionesDetallePorID(RequestParametrosGral requestGral)
        {
            StockManger stockManger = new StockManger();
            return stockManger.TransaccionesDetallePorID(requestGral);
        }

        [HttpPost("CambioDeMesa")]
        [EnableCors("MyPolicy")]
        public ResponseObject<RequestParametrosGral> CambioDeMesa(RequestParametrosGral requestGral)
        {
            StockManger stockManger = new StockManger();
            return stockManger.CambioDeMesa(requestGral);
        }

        [HttpPost("ClasificadorPorTipo")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<ClasificadorDTO> ClasificadorPorTipo(RequestParametrosGral requestGral)
        {
            StockManger stockManger = new StockManger();
            return stockManger.ClasificadorPorTipo(requestGral);
        }

        [HttpPost("GraficoVentaPorProducto")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<DetalleGananciasDTO> GraficoVentaPorProducto(RequestParametrosGral requestGral)
        {
            StockManger stockManger = new StockManger();
            return stockManger.GraficoVentaPorProducto(requestGral);
        }

    }


}
