using Business.Main.Base;
using Business.Main.DataMappingMicroVenta;
using CoreAccesLayer.Implement.SQLServer;
using CoreAccesLayer.Wraper;
using Domain.Main.MicroVentas.Cajas;
using Domain.Main.MicroVentas.SP;
using Domain.Main.MicroVentas.Usuarios;
using Domain.Main.MicroVentas.Ventas;
using tintoreria = Domain.Main.Tintoreria;
using Domain.Main.Wraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Main.Clientes;
using Business.Main.Managers;
using Domain.Main.MicroVentas.Impresion;
using Domain.Main.Tintoreria;
using Domain.Main.MicroVentas.Facturacion;

namespace Business.Main.Microventas
{
    public class TintoreriaManager : BaseManager
    {
        public ResponseObject<FacturaDTO> RegistrarVentas(RequestRegistroPedido requestRegistroVentas)
        {
            ResponseObject<FacturaDTO> response = new ResponseObject<FacturaDTO> { Message = "Venta registrada correctamente", State = ResponseType.Success };
            try
            {
                ParamOut paramOutRespuesta = new ParamOut(true);
                ParamOut paramOutLogRespuesta = new ParamOut("");
                ParamOut paramOutIdPedidoMaestro = new ParamOut(0);
                paramOutLogRespuesta.Size = 100;
                requestRegistroVentas.idAmbiente = 1;
                requestRegistroVentas.idPedMaster = 0;
                requestRegistroVentas.Observaciones = "";

                ///convierte datos para facturas
                FacturacionManager facturacionManager = new FacturacionManager();
                ResponseObject<FacturaDTO> responseFactura = new ResponseObject<FacturaDTO>();
                FacturaDTO facturaDTO = new FacturaDTO();
                facturaDTO.Descuento = requestRegistroVentas.Descuento;
                facturaDTO.MontoFactura = requestRegistroVentas.MontoFactura;
                facturaDTO.IdclienteFac = requestRegistroVentas.idFacCliente;
                //facturaDTO.NITCliente = requestRegistroVentas.NITCliente;
                //facturaDTO.NombreFactura = requestRegistroVentas.NombreFactura;
                FacturasDetalleDTO facturasDetalleDTO;
                List<FacturasDetalleDTO> colFacturasDetalleDTO =  new List<FacturasDetalleDTO>();
                requestRegistroVentas.detallePedido.ForEach(x => {
                    facturasDetalleDTO = new FacturasDetalleDTO();
                    facturasDetalleDTO.Cantidad = (int)x.cantidad.Value;
                    facturasDetalleDTO.Monto = x.PrecioFinal;
                    facturasDetalleDTO.IdItem = (int)x.idProducto.Value;
                    facturasDetalleDTO.Descuento = x.Descuento;
                    facturasDetalleDTO.Concepto = x.NombreProducto;
                    colFacturasDetalleDTO.Add(facturasDetalleDTO);
                });
                facturaDTO.FacturasDetalle = colFacturasDetalleDTO;

                responseFactura = facturacionManager.GeneraFactura(facturaDTO);
                if (responseFactura.State != ResponseType.Success)
                {
                    response.State = responseFactura.State;
                    response.Message = responseFactura.Message;
                    return response;
                }

                repositoryMicroventas.CallProcedure<Response>("shBusiness.spAddPediddo",
                    requestRegistroVentas.idSesion,
                    requestRegistroVentas.idEmpresa,
                    requestRegistroVentas.idOperacionDiariaCaja,
                    Convert.ToInt64(responseFactura.Object.IdFactura),
                    requestRegistroVentas.idAmbiente,
                    requestRegistroVentas.idPedMaster,
                    requestRegistroVentas.detallePedido,
                    requestRegistroVentas.Observaciones,
                    paramOutIdPedidoMaestro,
                    paramOutRespuesta,
                    paramOutLogRespuesta);
                repositoryMicroventas.Commit();
                if (Convert.ToBoolean(paramOutRespuesta.Valor))
                {
                    response.State = ResponseType.Warning;
                    response.Message = Convert.ToString(paramOutLogRespuesta.Valor);
                }
                response.Code = Convert.ToString(paramOutIdPedidoMaestro.Valor);
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public Response EntregarPedido(RequestEntregarPedido requestEntregarPedido)
        {
            Response response = new Response { Message = "Pedido entregado correctamente", State = ResponseType.Success };
            try
            {
                ParamOut paramOutRespuesta = new ParamOut(true);
                ParamOut paramOutLogRespuesta = new ParamOut("");
                paramOutLogRespuesta.Size = 100;

                repositoryMicroventas.CallProcedure<Response>("[shBusiness].[spEntregaPedido]",
                    requestEntregarPedido.idSesion,
                    requestEntregarPedido.idEmpresa,
                    requestEntregarPedido.idPedidoMaster,
                    paramOutRespuesta,
                    paramOutLogRespuesta);
                repositoryMicroventas.Commit();

                if (Convert.ToBoolean(paramOutRespuesta.Valor))
                {
                    response.State = ResponseType.Warning;
                    response.Message = Convert.ToString(paramOutLogRespuesta.Valor);
                }

            }
            catch (Exception ex)
            {
                repositoryMicroventas.Rollback();
                ProcessError(ex, response);
            }
            return response;
        }

        public ResponseQuery<ResulSPProductosCantidad> SearchProduct(tintoreria.RequestSearchProduct requestSearchProduct)
        {

            ResponseQuery<ResulSPProductosCantidad> response = new ResponseQuery<ResulSPProductosCantidad> { Message = "¨Producto obtenidos correctamente", State = ResponseType.Success };
            try
            {
                ParamOut codRespuesta = new ParamOut(true);
                ParamOut logRespuesta = new ParamOut("");
                logRespuesta.Size = 100;
                response.ListEntities = repositoryMicroventas.GetDataByProcedure<ResulSPProductosCantidad>("shBusiness.spObtienePrecios",
                    requestSearchProduct.idSesion,
                    requestSearchProduct.idEmpresa,
                    "%",
                    codRespuesta,
                    logRespuesta);

            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public ResponseQuery<MDPedidosPorEntregar> ObtienePedidosPorEntregar(tintoreria.RequestObtienePedidosPorEntregar requestObtienePedidosPorEntregar)
        {

            ResponseQuery<MDPedidosPorEntregar> response = new ResponseQuery<MDPedidosPorEntregar> { Message = "¨Pedidos obtenidos correctamente", State = ResponseType.Success };
            try
            {
                ParamOut codRespuesta = new ParamOut(true);
                ParamOut logRespuesta = new ParamOut("");
                logRespuesta.Size = 100;
                List<ResponseObtienePedidosPorEntregar> listSP = repositoryMicroventas.GetDataByProcedure<ResponseObtienePedidosPorEntregar>("shBusiness.spObtienePedidosEstado",
                    requestObtienePedidosPorEntregar.idSession,
                    requestObtienePedidosPorEntregar.idEmpresa,
                    1,
                    new DateTime(2022, 1, 1),
                    new DateTime(2025, 1, 1),
                    codRespuesta,
                    logRespuesta);

                ///Convertimos a estructura de maestro detalle
                response.ListEntities = new List<MDPedidosPorEntregar>();
                listSP.ForEach(resp =>
                {
                    MDPedidosPorEntregar mDPedidosPorEntregar = response.ListEntities.FirstOrDefault(x => resp.idPedMaster == x.idPedMaster);
                    if (mDPedidosPorEntregar == null)
                    {
                        mDPedidosPorEntregar = new MDPedidosPorEntregar
                        {
                            documento = resp.documento,
                            fechaRegistro = resp.fechaRegistro,
                            idPedMaster = resp.idPedMaster,
                            NombreCliente = resp.NombreCliente,
                            detallePedidosEntregar = new List<DetallePedidosEntregar>()
                        };
                        response.ListEntities.Add(mDPedidosPorEntregar);
                    }
                    mDPedidosPorEntregar.detallePedidosEntregar.Add(new DetallePedidosEntregar
                    {
                        Cantidad = resp.Cantidad,
                        Precio = resp.Precio,
                        producto = resp.producto,
                    });

                });
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public ResponseQuery<MDPedidosPorEntregar> ObtienePedidosReporte(tintoreria.RequestObtienePedidosPorEntregar requestObtienePedidosPorEntregar)
        {

            ResponseQuery<MDPedidosPorEntregar> response = new ResponseQuery<MDPedidosPorEntregar> { Message = "¨Pedidos obtenidos correctamente", State = ResponseType.Success };
            try
            {
                ParamOut codRespuesta = new ParamOut(true);
                ParamOut logRespuesta = new ParamOut("");
                logRespuesta.Size = 100;
                List<ResponseObtienePedidosPorEntregar> listSP = repositoryMicroventas.GetDataByProcedure<ResponseObtienePedidosPorEntregar>("shBusiness.spObtienePedidosEstado",
                    requestObtienePedidosPorEntregar.idSession,
                    requestObtienePedidosPorEntregar.idEmpresa,
                    requestObtienePedidosPorEntregar.idEstado,
                    requestObtienePedidosPorEntregar.FechaDesde,//new DateTime(2022, 1, 1),
                    requestObtienePedidosPorEntregar.FechaHasta,//new DateTime(2025, 1, 1),
                    codRespuesta,
                    logRespuesta);

                ///Convertimos a estructura de maestro detalle
                response.ListEntities = new List<MDPedidosPorEntregar>();
                listSP.ForEach(resp =>
                {
                    MDPedidosPorEntregar mDPedidosPorEntregar = response.ListEntities.FirstOrDefault(x => resp.idPedMaster == x.idPedMaster);
                    if (mDPedidosPorEntregar == null)
                    {
                        mDPedidosPorEntregar = new MDPedidosPorEntregar
                        {
                            documento = resp.documento,
                            fechaRegistro = resp.fechaRegistro,
                            idPedMaster = resp.idPedMaster,
                            NombreCliente = resp.NombreCliente,
                            Estado = resp.Estado,
                            detallePedidosEntregar = new List<DetallePedidosEntregar>()
                        };
                        response.ListEntities.Add(mDPedidosPorEntregar);
                    }
                    mDPedidosPorEntregar.detallePedidosEntregar.Add(new DetallePedidosEntregar
                    {
                        Cantidad = resp.Cantidad,
                        Precio = resp.Precio,
                        producto = resp.producto,
                    });

                });
                //Sumarizamos los totales
                response.ListEntities.ForEach(x =>
                {
                    x.Total = x.detallePedidosEntregar.Sum(y => y.Cantidad * y.Precio);
                });
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public ResponseQuery<MDPedidosPorEntregar> ObtieneArqueoCaja(tintoreria.RequestObtieneArqueoCaja requestObtieneArqueoCaja)
        {

            ResponseQuery<MDPedidosPorEntregar> response = new ResponseQuery<MDPedidosPorEntregar> { Message = "¨Pedidos obtenidos correctamente", State = ResponseType.Success };
            try
            {
                ParamOut codRespuesta = new ParamOut(true);
                ParamOut logRespuesta = new ParamOut("");
                logRespuesta.Size = 100;
                requestObtieneArqueoCaja.FechaDesde =
                   requestObtieneArqueoCaja.FechaDesde != null ? requestObtieneArqueoCaja.FechaDesde.Value.Date : DateTime.Now.Date;
                requestObtieneArqueoCaja.FechaHasta = requestObtieneArqueoCaja.FechaDesde.Value.AddDays(1);
                List<ResponseObtienePedidosPorEntregar> listSP = repositoryMicroventas.GetDataByProcedure<ResponseObtienePedidosPorEntregar>("shBusiness.spArqueoCajas",
                    requestObtieneArqueoCaja.idSession,
                    requestObtieneArqueoCaja.idEmpresa,
                    requestObtieneArqueoCaja.idCaja,
                    requestObtieneArqueoCaja.FechaDesde,//new DateTime(2022, 1, 1),
                    requestObtieneArqueoCaja.FechaHasta,//new DateTime(2025, 1, 1),
                    codRespuesta,
                    logRespuesta);

                ///Convertimos a estructura de maestro detalle
                response.ListEntities = new List<MDPedidosPorEntregar>();
                listSP.ForEach(resp =>
                {
                    MDPedidosPorEntregar mDPedidosPorEntregar = response.ListEntities.FirstOrDefault(x => resp.idPedMaster == x.idPedMaster);
                    if (mDPedidosPorEntregar == null)
                    {
                        mDPedidosPorEntregar = new MDPedidosPorEntregar
                        {
                            documento = resp.documento,
                            fechaRegistro = resp.fechaRegistro,
                            idPedMaster = resp.idPedMaster,
                            NombreCliente = resp.NombreCliente,
                            Estado = resp.Estado,
                            montoApertura = resp.montoApertura,
                            montoCierre = resp.montoCierre,
                            detallePedidosEntregar = new List<DetallePedidosEntregar>()
                        };
                        response.ListEntities.Add(mDPedidosPorEntregar);

                    }
                    mDPedidosPorEntregar.detallePedidosEntregar.Add(new DetallePedidosEntregar
                    {
                        Cantidad = resp.Cantidad,
                        Precio = resp.Precio,
                        producto = resp.producto,
                    });

                });

                //Sumarizamos los totales
                response.ListEntities.ForEach(x =>
                {
                    x.Total = x.detallePedidosEntregar.Sum(y => y.Cantidad * y.Precio);
                });

            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public ResponseQuery<ResponseObtieneCajaUsuario> ObtieneCajaUsuario(tintoreria.RequestObtieneCajaUsuario requestObtieneCajaUsuario)
        {

            ResponseQuery<ResponseObtieneCajaUsuario> response = new ResponseQuery<ResponseObtieneCajaUsuario> { Message = "¨Pedidos obtenidos correctamente", State = ResponseType.Success };
            try
            {
                ParamOut codRespuesta = new ParamOut(true);
                ParamOut logRespuesta = new ParamOut("");
                logRespuesta.Size = 100;
                response.ListEntities = repositoryMicroventas.GetDataByProcedure<ResponseObtieneCajaUsuario>("shBusiness.spCajasUsuario",
                    requestObtieneCajaUsuario.idSession,
                    requestObtieneCajaUsuario.idEmpresa,
                    codRespuesta,
                    logRespuesta);
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }
    }
}
