﻿using Business.Main.Managers;
using Business.Main.Microventas;
using Domain.Main.MicroVentas.Impresion;
using Domain.Main.MicroVentas.SP;
using tintoreria = Domain.Main.Tintoreria;
using Domain.Main.Wraper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Domain.Main.Clientes;
using Domain.Main.Tintoreria;
using Domain.Main.MicroVentas.Facturacion;

namespace MinimalAPI.Controllers
{
    [Route("api/Tintoreria")]
    [ApiController]
    public class TintoreriaController : ControllerBase
    {

        [HttpPost("RegistrarPedidoTintoreria")]
        [EnableCors("MyPolicy")]
        public ResponseObject<FacturaDTO> RegistrarPedidoTintoreria(RequestRegistroPedido requestRegistroPedido)
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

        [HttpPost("SearchProduct")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<ResulSPProductosCantidad> SearchProduct(tintoreria.RequestSearchProduct requestSearchProduct)
        {
            TintoreriaManager tintoreriaManager = new TintoreriaManager();
            return tintoreriaManager.SearchProduct(requestSearchProduct);
        }

        [HttpPost("ObtienePedidosPorEntregar")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<MDPedidosPorEntregar> ObtienePedidosPorEntregar(tintoreria.RequestObtienePedidosPorEntregar requestObtienePedidosPorEntregar)
        {
            TintoreriaManager tintoreriaManager = new TintoreriaManager();
            return tintoreriaManager.ObtienePedidosPorEntregar(requestObtienePedidosPorEntregar);
        }

        [HttpPost("EntregarPedido")]
        [EnableCors("MyPolicy")]
        public Response EntregarPedido(RequestEntregarPedido requestEntregarPedido)
        {
            TintoreriaManager tintoreriaManager = new TintoreriaManager();
            return tintoreriaManager.EntregarPedido(requestEntregarPedido);
        }
        [HttpPost("ObtienePedidosReporte")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<MDPedidosPorEntregar> ObtienePedidosReporte(RequestObtienePedidosPorEntregar requestEntregarPedido)
        {
            TintoreriaManager tintoreriaManager = new TintoreriaManager();
            return tintoreriaManager.ObtienePedidosReporte(requestEntregarPedido);
        }
        [HttpPost("ObtieneArqueoCaja")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<MDPedidosPorEntregar> ObtieneArqueoCaja(RequestObtieneArqueoCaja requestObtieneArqueoCaja)
        {
            TintoreriaManager tintoreriaManager = new TintoreriaManager();
            return tintoreriaManager.ObtieneArqueoCaja(requestObtieneArqueoCaja);
        }

        [HttpPost("ObtieneCajaUsuario")]
        [EnableCors("MyPolicy")]
        public ResponseQuery<ResponseObtieneCajaUsuario> ObtieneCajaUsuario(tintoreria.RequestObtieneCajaUsuario requestObtieneCajaUsuario)
        {
            TintoreriaManager tintoreriaManager = new TintoreriaManager();
            return tintoreriaManager.ObtieneCajaUsuario(requestObtieneCajaUsuario);
        }
    }
}
