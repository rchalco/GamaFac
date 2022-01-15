﻿using Business.Main.Microventas;
using Domain.Main.MicroVentas.Cajas;
using Domain.Main.MicroVentas.SP;
using Domain.Main.MicroVentas.Usuarios;
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
        public ResponseObject<LoginDTO> LoginUsuario(RequestLogin requestLogin)
        {
            StockManger stockManger = new StockManger();
            return stockManger.LoginUsuario(requestLogin.usuario, requestLogin.password);
        }

        [HttpPost("CambioContrasena")]
        [EnableCors("MyPolicy")]
        public ResponseObject<LoginDTO> CambioContrasena(RequestLogin requestLogin)
        {
            StockManger stockManger = new StockManger();
            return stockManger.CambioContrasena(requestLogin.usuario, requestLogin.password, requestLogin.passwordNuevo);
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
        public ResponseObject<SaldoCajaDTO> CierreCaja(RequestCierreCaja requestCierreCaja)
        {
            StockManger stockManger = new StockManger();
            return stockManger.CierreCaja(requestCierreCaja.idCaja, requestCierreCaja.montoCierre, requestCierreCaja.observacion);
        }

        [HttpPost("ObtieneCaja")]
        [EnableCors("MyPolicy")]
        public ResponseObject<SaldoCajaDTO> ObtieneCaja(RequestParametrosGral requestGral)
        {
            StockManger stockManger = new StockManger();
            return stockManger.ObtieneCaja(requestGral.ParametroFecha1);
        }

        [HttpPost("AperturaCaja")]
        [EnableCors("MyPolicy")]
        public ResponseObject<SaldoCajaDTO> AperturaCaja(RequestParametrosGral requestAperturaCaja)
        {
            StockManger stockManger = new StockManger();
            return stockManger.AperturaCaja(requestAperturaCaja.ParametroFecha1, requestAperturaCaja.ParametroEntero1);
        }


    }


}
