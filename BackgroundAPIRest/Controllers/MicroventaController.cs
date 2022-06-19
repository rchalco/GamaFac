using Business.Main.Microventas;
using Domain.Main.MicroVentas.Cajas;
using Domain.Main.MicroVentas.Facturacion;
using Domain.Main.MicroVentas.General;
using Domain.Main.MicroVentas.Persona;
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


        [HttpPost("AperturaInventario")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<ResulProductoPrecioVenta> AperturaInventario(RequestParametrosGral requestGral)
        {
            StockManger stockManger = new StockManger();
            return stockManger.AperturaInventario(requestGral);
        }

        [HttpPost("GeneraFactura")]
        [EnableCors("MyPolicy")]
        public ResponseObject<FacturaDTO> GeneraFactura(FacturaDTO requestGral)
        {
            FacturacionManager facturacionManager = new FacturacionManager();
            return facturacionManager.GeneraFactura(requestGral);
        }
        [HttpPost("ObtenerPersonas")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<PersonaDTO> ObtenerPersonas(RequestParametrosGral requestGral)
        {
            StockManger stockManger = new StockManger();
            return stockManger.ObtenerPersonas(requestGral);
        }


        [HttpPost("GrabarPersona")]
        [EnableCors("MyPolicy")]
        public ResponseObject<PersonaDTO> GrabarPersona(PersonaDTO personaDTO)
        {
            StockManger stockManger = new StockManger();
            return stockManger.GrabarPersona(personaDTO);
        }

        [HttpPost("ObtenerUsuarios")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<LoginDTO> ObtenerUsuarios(RequestParametrosGral requestGral)
        {
            StockManger stockManger = new StockManger();
            return stockManger.ObtenerUsuarios(requestGral);
        }

        [HttpPost("ObtenerRol")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<RolDTO> ObtenerRol(RequestParametrosGral requestGral)
        {
            StockManger stockManger = new StockManger();
            return stockManger.ObtenerRol(requestGral);
        }

        [HttpPost("GrabarUsuario")]
        [EnableCors("MyPolicy")]
        public ResponseObject<LoginDTO> GrabarUsuario(LoginDTO personaDTO)
        {
            StockManger stockManger = new StockManger();
            return stockManger.GrabarUsuario(personaDTO);
        }
    }


}
