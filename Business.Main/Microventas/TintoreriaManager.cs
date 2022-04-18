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

namespace Business.Main.Microventas
{
    public class TintoreriaManager : BaseManager
    {
        public Response RegistrarVentas(RequestRegistroPedido requestRegistroVentas)
        {
            Response response = new Response { Message = "Venta registrada correctamente", State = ResponseType.Success };
            try
            {
                ParamOut paramOutRespuesta = new ParamOut(true);
                ParamOut paramOutLogRespuesta = new ParamOut("");
                ParamOut paramOutIdPedidoMaestro = new ParamOut(0);
                paramOutLogRespuesta.Size = 100;
                requestRegistroVentas.idAmbiente = 1;
                requestRegistroVentas.idPedMaster = 0;
                requestRegistroVentas.Observaciones = "";

                repositoryMicroventas.CallProcedure<Response>("shBusiness.spAddPediddo",
                    requestRegistroVentas.idSesion,
                    requestRegistroVentas.idEmpresa,
                    requestRegistroVentas.idOperacionDiariaCaja,
                    Convert.ToInt64(requestRegistroVentas.idFacCliente),
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
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }
    }
}
