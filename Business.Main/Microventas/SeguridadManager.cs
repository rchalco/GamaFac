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

        public ResponseObject<LoginDTO> CambioContrasena(string Usuario, string Password, string PasswordNuevo)
        {

            ResponseObject<LoginDTO> response = new ResponseObject<LoginDTO> { Message = "¨Se realizo el cambio de contraseña", State = ResponseType.Success };
            try
            {

                ///TODO:Encriptar el pass

                TUsuario ObjTUsuario = new TUsuario();
                ObjTUsuario = repositoryMicroventas.SimpleSelect<TUsuario>(x => x.Usuario == Usuario).FirstOrDefault();
                if (ObjTUsuario == null)
                {
                    response.State = ResponseType.Error;
                    response.Message = "El Usuario no existe";
                    return response;
                }
                if (ObjTUsuario.Pass != Password)
                {
                    response.State = ResponseType.Error;
                    response.Message = "La contraseña es incorrecta";
                    return response;
                }
                ObjTUsuario.Pass = PasswordNuevo;
                Entity<TUsuario> entity = new Entity<TUsuario> { EntityDB = ObjTUsuario, stateEntity = StateEntity.modify };
                repositoryMicroventas.SaveObject<TUsuario>(entity);
                repositoryMicroventas.Commit();

            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public ResponseQuery<MenuGeneralDTO> ObtieneMenuPorUsuario(RequestParametrosGral requestGral)
        {
            ParamOut poRespuesta = new ParamOut(false);
            ParamOut poLogRespuesta = new ParamOut("");
            ResponseQuery<MenuGeneralDTO> response = new ResponseQuery<MenuGeneralDTO> { Message = "Menu Obtenido", State = ResponseType.Success };
            try
            {
                response.ListEntities = repositoryMicroventas.GetDataByProcedure<MenuGeneralDTO>("shCommon.spObtieneMenuPorRol", requestGral.ParametroLong1, requestGral.ParametroLong2, requestGral.ParametroLong3, poRespuesta, poLogRespuesta);
                if (response.ListEntities == null)
                {
                    response.State = ResponseType.Error;
                    response.Message = "No exiten roles";
                }

                if ((bool)poRespuesta.Valor)
                {
                    response.Message = poLogRespuesta.Valor.ToString();
                    response.State = ResponseType.Error;
                    return response;
                }
                /*

                colPersonaResumenDTO.Add(new PersonaResumenDTO { IdPersona = 1, NombreCompleto = "MESERO 1", IdEmpleado = 1 });
                colPersonaResumenDTO.Add(new PersonaResumenDTO { IdPersona = 2, NombreCompleto = "MESERO 2", IdEmpleado = 2 });
                colPersonaResumenDTO.Add(new PersonaResumenDTO { IdPersona = 3, NombreCompleto = "MESERO 3", IdEmpleado = 3 });
                response.ListEntities = colPersonaResumenDTO;
                 */


            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

    }
}
