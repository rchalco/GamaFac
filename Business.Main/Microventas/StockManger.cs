using Business.Main.Base;
using Business.Main.DataMappingMicroVenta;
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

<<<<<<< HEAD
        public Response RegistrarVentas(RequestRegistroVenta requestRegistroVentas)
        {
            Response response = new Response { Message = "Venta registrada correctamente", State = ResponseType.Success };
            try
            {
                repositoryMicroventas.CallProcedure<Response>("spVentaVentanilla", requestRegistroVentas.idSesion, requestRegistroVentas.idVentanilla, requestRegistroVentas.detalleVentas);
                repositoryMicroventas.Commit();
=======
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

>>>>>>> 8eef0f8b891ccf23fd61aa0c1dcdb66812904b5b
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }
<<<<<<< HEAD
=======

>>>>>>> 8eef0f8b891ccf23fd61aa0c1dcdb66812904b5b
    }
}
