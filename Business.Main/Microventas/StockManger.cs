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

        public Response RegistrarVentas(RequestRegistroVenta requestRegistroVentas)
        {
            Response response = new Response { Message = "Venta registrada correctamente", State = ResponseType.Success };
            try
            {
                repositoryMicroventas.CallProcedure<Response>("spVentaVentanilla", requestRegistroVentas.idSesion, requestRegistroVentas.idVentanilla, requestRegistroVentas.detalleVentas);
                repositoryMicroventas.Commit();
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }
    }
}
