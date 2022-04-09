using Business.Main.Base;
using Business.Main.DataMappingMicroVenta;
using CoreAccesLayer.Implement.SQLServer;
using CoreAccesLayer.Wraper;
using Domain.Main.MicroVentas.Cajas;
using Domain.Main.MicroVentas.General;
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
    public class SeguridadManager : BaseManager
    {
        public ResponseObject<LoginDTO> LoginUsuario(RequestLogin requestLogin)
        {

            ResponseObject<LoginDTO> response = new ResponseObject<LoginDTO> { Message = "¨Inicio de Sesión Correcto", State = ResponseType.Success };
            try
            {
                ///TODO:Encriptar el pass
                ///
                ParamOut poRespuesta = new ParamOut(false);
                ParamOut poLogRespuesta = new ParamOut("");
                poLogRespuesta.Size = 100;
                response.Object = repositoryMicroventas.GetDataByProcedure<LoginDTO>("shSecurity.spLogin", requestLogin.idEmpresa, requestLogin.usuario, requestLogin.password, poRespuesta, poLogRespuesta).FirstOrDefault();


                if (response.Object == null)
                {
                    response.Message = "Error al realizar la consulta";
                    response.State = ResponseType.Error;
                    return response;
                }

                if ((bool)poRespuesta.Valor)
                {
                    response.Message = poLogRespuesta.Valor.ToString();
                    response.State = ResponseType.Error;
                    return response;
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
