using Business.Main.Base;
using Business.Main.DataMappingMicroVenta;
using CoreAccesLayer.Implement.SQLServer;
using CoreAccesLayer.Wraper;
using Domain.Main.Clientes;
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
    public class PersonaManager : BaseManager
    {
        public ResponseQuery<ResponseObtenerClientes> ObtenerClientes(RequestObtenerClientes requestObtenerClientes)
        {
            ResponseQuery<ResponseObtenerClientes> response = new ResponseQuery<ResponseObtenerClientes> { Message = "Personas obtenidas correctamente", State = ResponseType.Success };
            try
            {
                ParamOut paramOutRespuesta = new ParamOut(true);
                ParamOut paramOutLogRespuesta = new ParamOut("");
                paramOutLogRespuesta.Size = 100;

                response.ListEntities = repositoryMicroventas.GetDataByProcedure<ResponseObtenerClientes>("shfactura.spObtieneClientes",
                    requestObtenerClientes.idSession,
                    requestObtenerClientes.idEmpresa,
                    requestObtenerClientes.documento,
                    paramOutRespuesta,
                    paramOutLogRespuesta);

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

        public ResponseObject<long> RegistrarClientreFactura(RequestRegistrarClientreFactura requestRegistrarClientreFactura)
        {
            ResponseObject<long> response = new ResponseObject<long> { Message = "Cliente registrado correctamente", State = ResponseType.Success };
            try
            {
                ParamOut paramOutRespuesta = new ParamOut(true);
                ParamOut paramOutidClienteFact = new ParamOut(0);
                ParamOut paramOutLogRespuesta = new ParamOut("");
                paramOutLogRespuesta.Size = 100;


                repositoryMicroventas.CallProcedure<Response>("[shfactura].[spAddClienteFac]",
                    requestRegistrarClientreFactura.idSesion,
                    requestRegistrarClientreFactura.idEmpresa,
                    requestRegistrarClientreFactura.idTipoDocumento,
                    Convert.ToInt64(requestRegistrarClientreFactura.documento),
                    "", //complemento
                    "", //extension
                    requestRegistrarClientreFactura.NombreCliente,
                    requestRegistrarClientreFactura.correoElectronico,
                    requestRegistrarClientreFactura.numCelular,
                    paramOutidClienteFact,
                    paramOutRespuesta,
                    paramOutLogRespuesta);
                repositoryMicroventas.Commit();

                if (Convert.ToBoolean(paramOutRespuesta.Valor))
                {
                    response.State = ResponseType.Warning;
                    response.Message = Convert.ToString(paramOutLogRespuesta.Valor);
                    return response;
                }

                response.Object = Convert.ToInt64(paramOutidClienteFact.Valor);
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }
    }
}
