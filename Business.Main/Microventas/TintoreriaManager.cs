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
                paramOutLogRespuesta.Size = 100;
                requestRegistroVentas.idAmbiente = 1;
                requestRegistroVentas.idPedMaster = 0;
                requestRegistroVentas.Observaciones = "";

                repositoryMicroventas.CallProcedure<Response>("shBusiness.spAddPediddo",
                    requestRegistroVentas.idSesion,
                    requestRegistroVentas.idEmpresa,
                    requestRegistroVentas.idOperacionDiariaCaja,
                    requestRegistroVentas.idFacCliente,
                    requestRegistroVentas.idAmbiente,
                    requestRegistroVentas.idPedMaster,
                    requestRegistroVentas.detallePedido,
                    requestRegistroVentas.Observaciones,
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

        public ResponseQuery<ResponseObtienePedidosPorEntregar> ObtienePedidosPorEntregar(tintoreria.RequestObtienePedidosPorEntregar requestObtienePedidosPorEntregar)
        {

            ResponseQuery<ResponseObtienePedidosPorEntregar> response = new ResponseQuery<ResponseObtienePedidosPorEntregar> { Message = "¨Pedidos obtenidos correctamente", State = ResponseType.Success };
            try
            {
                ParamOut codRespuesta = new ParamOut(true);
                ParamOut logRespuesta = new ParamOut("");
                logRespuesta.Size = 100;
                response.ListEntities = repositoryMicroventas.GetDataByProcedure<ResponseObtienePedidosPorEntregar>("shfactura.spObtienePedidosPorEntregar",
                    requestObtienePedidosPorEntregar.idSession,
                    requestObtienePedidosPorEntregar.idEmpresa,
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
