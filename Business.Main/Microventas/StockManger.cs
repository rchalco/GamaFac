using Business.Main.Base;
using Business.Main.DataMappingMicroVenta;
using CoreAccesLayer.Wraper;
using Domain.Main.MicroVentas.SP;
using Domain.Main.Wraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Main.Microventas
{
    public class StockManger : BaseManager
    {

        public ResponseQuery<ResulSPProductosCantidad> SearchProduct(int IdEmpresa)
        {

            ResponseQuery<ResulSPProductosCantidad> response = new ResponseQuery<ResulSPProductosCantidad> { Message = "¨Producto obtenidos correctamente", State = ResponseType.Success };
            try
            {
                response.ListEntities = repositoryMicroventas.GetDataByProcedure<ResulSPProductosCantidad>("spProductosCantidad", "");
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public Response RegistrarCompra(RequestRegistrarCompra requestRegistrarCompra)
        {

            Response response = new Response { Message = "Compra registrada correctamente", State = ResponseType.Success };
            try
            {
                repositoryMicroventas.CallProcedure<Response>("spCompraVentanilla", requestRegistrarCompra.idUsuario, requestRegistrarCompra.idVentanilla, requestRegistrarCompra.idProducto, requestRegistrarCompra.cantidad, requestRegistrarCompra.precioUnitario);
                repositoryMicroventas.Commit();
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }


        public Response RegistrarVentas(RequestRegistroVenta requestRegistroVentas)
        {
            Response response = new Response { Message = "Venta registrada correctamente", State = ResponseType.Success };
            try
            {
                repositoryMicroventas.CallProcedure<Response>("spVentaVentanilla", requestRegistroVentas.idSesion, requestRegistroVentas.idVentanilla, requestRegistroVentas.detalleVentas);
                repositoryMicroventas.Commit();

            }
            catch { }
            return response;
        }

        public ResponseObject<LoginDTO> LoginUsuario(string Usuario, string Password)
        {

            ResponseObject<LoginDTO> response = new ResponseObject<LoginDTO> { Message = "¨Inicio de Sesión Correcto", State = ResponseType.Success };
            try
            {
                ///TODO:Encriptar el pass
                ///
                //response.Object = repositoryMicroventas.GetDataByProcedure<LoginDTO>("spProductosCantidad", Usuario, Password).FirstOrDefault();
                
                response.Object = new LoginDTO { IdUsuario = 1, Usuario = Usuario, DescripcionError = "Usuario o contraseña incorrectos" };
                if (!string.IsNullOrEmpty(response.Object.DescripcionError))
                {
                    response.Message = response.Object.DescripcionError;
                    response.State = ResponseType.Error;
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
                /*
                TUsuario ObjTUsuario = new TUsuario();
                ObjTUsuario = repositoryMicroventas.SimpleSelect<TUsuario>(x => x.Usuario == Usuario).FirstOrDefault();
                if (ObjTUsuario ==  null)
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
