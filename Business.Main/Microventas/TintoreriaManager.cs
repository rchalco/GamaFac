using Business.Main.Base;
using Business.Main.DataMappingMicroVenta;
using CoreAccesLayer.Implement.SQLServer;
using CoreAccesLayer.Wraper;
using Domain.Main.MicroVentas.Cajas;
using Domain.Main.MicroVentas.SP;
using Domain.Main.MicroVentas.Usuarios;
using Domain.Main.MicroVentas.Ventas;
using Domain.Main.Wraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

                repositoryMicroventas.CallProcedure<Response>("spAddPediddo",
                    requestRegistroVentas.idSesion,
                    requestRegistroVentas.idEmpresa,
                    requestRegistroVentas.idOperacionDiariaCaja,
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
    }
}
