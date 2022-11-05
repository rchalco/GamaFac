using Business.Main.Base;
using CoreAccesLayer.Implement.SQLServer;
using Domain.Main.MicroVentas.General;
using Domain.Main.MicroVentas.SP;
using Domain.Main.MicroVentas.Types;
using Domain.Main.Wraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Main.Microventas
{
    public class CommonManager : BaseManager
    {
        string imagenDefault = "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";
        byte[] arr1 = Enumerable.Repeat((byte)0x20, 100).ToArray();

        public ResponseQuery<ClasificadorDTO> ClasificadorPorTipo(RequestParametrosGral requestGral)
        {

            ResponseQuery<ClasificadorDTO> response = new ResponseQuery<ClasificadorDTO> { Message = "Clasificador recuperado", State = ResponseType.Success };
            try
            {


                List<ClasificadorDTO> colClasificadorDTO = new List<ClasificadorDTO>();
                colClasificadorDTO.Add(new ClasificadorDTO { idClasificador = 1, nombre = "EFECTIVO" });
                colClasificadorDTO.Add(new ClasificadorDTO { idClasificador = 2, nombre = "TARJETA" });
                colClasificadorDTO.Add(new ClasificadorDTO { idClasificador = 3, nombre = "TRANSFERENCIA" });


                response.ListEntities = colClasificadorDTO;

            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }


        public ResponseQuery<ClasificadorDTO> TiposCategoriasProductos(RequestParametrosGral requestGral)
        {

            ResponseQuery<ClasificadorDTO> response = new ResponseQuery<ClasificadorDTO> { Message = "Clasificador recuperado", State = ResponseType.Success };
            try
            {
                ParamOut paramOutRespuesta = new ParamOut(true);
                ParamOut paramOutLogRespuesta = new ParamOut("");
                paramOutLogRespuesta.Size = 100;
                response.ListEntities = repositoryMicroventas.GetDataByProcedure<ClasificadorDTO>("shCommon.spObtClasificador", requestGral.ParametroLong1,1, paramOutRespuesta, paramOutLogRespuesta);
                response.ListEntities.ForEach(item =>
                {
                    if (item.picCategoria != null)
                        item.picCategoriaB64 = Convert.ToBase64String(item.picCategoria);

                });


                if ((bool)paramOutRespuesta.Valor)
                {
                    response.Message = paramOutLogRespuesta.Valor.ToString();
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

        public ResponseQuery<ResulProductoPrecioVenta> ObtieneProductosParaABM(RequestParametrosGral requestSearchProduct)
        {
            ResponseQuery<ResulProductoPrecioVenta> response = new ResponseQuery<ResulProductoPrecioVenta> { Message = "Productos recuperados", State = ResponseType.Success };
            try
            {
                ParamOut paramOutRespuesta = new ParamOut(true);
                ParamOut paramOutLogRespuesta = new ParamOut("");
                paramOutLogRespuesta.Size = 100;
                response.ListEntities = repositoryMicroventas.GetDataByProcedure<ResulProductoPrecioVenta>("[shCommon].[spObtMenuProductos]", requestSearchProduct.ParametroLong1, paramOutRespuesta, paramOutLogRespuesta);
                response.ListEntities.ForEach(item =>
                {
                    if (item.picProducto!= null)
                        item.picProductoB64 = Convert.ToBase64String(item.picProducto);
                    item.detalleProductos = new List<ResulProductoPrecioVenta>();
                    item.detalleProductos = repositoryMicroventas.GetDataByProcedure<ResulProductoPrecioVenta>(" [shCommon].[spObtDetallePrecios]", requestSearchProduct.ParametroLong1, item.idPrecio, paramOutRespuesta, paramOutLogRespuesta);

                });

                if ((bool)paramOutRespuesta.Valor)
                {
                    response.Message = paramOutLogRespuesta.Valor.ToString();
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


        public ResponseQuery<ResulProductoPrecioVenta> GrabarProductoYmenu(ResulProductoPrecioVenta requestProducto)
        {
            ResponseQuery<ResulProductoPrecioVenta> response = new ResponseQuery<ResulProductoPrecioVenta> { Message = "Prodcutos recuperados", State = ResponseType.Success };
            try
            {
                List<typeDetailIngredientes> coltypeDetailIngredientes = new List<typeDetailIngredientes>();
                ParamOut paramOutRespuesta = new ParamOut(true);
                ParamOut paramOutLogRespuesta = new ParamOut("");
                ParamOut paramOutLogId = new ParamOut(0);
                paramOutLogRespuesta.Size = 100;
                ////Adicionamos producto si es que no tiene un detalle de ingredientes
                if (requestProducto.detalleProductos == null || requestProducto.detalleProductos.Count == 0 || requestProducto.idProducto > 0)
                {
                    repositoryMicroventas.CallProcedure<ResulProductoPrecioVenta>("[shCommon].[spAddProducto]",
                       requestProducto.idSesion,
                       requestProducto.idProducto,
                       requestProducto.idcCategoria,
                       requestProducto.nombreProducto,
                       requestProducto.marca,
                       requestProducto.contenido,
                       requestProducto.producto,
                       requestProducto.picProductoB64 == null ? arr1 :Convert.FromBase64String(requestProducto.picProductoB64.Replace("data:image/jpeg;base64,", "")),
                       paramOutRespuesta,
                       paramOutLogRespuesta,
                       paramOutLogId);
                }

                ///Si se tiene detalle de productos para combos y es para menu
                if (requestProducto.esParaMenu)
                {
                    long idPrecio = 0;

                    if (requestProducto.detalleProductos == null || requestProducto.detalleProductos.Count == 0)
                    {
                        coltypeDetailIngredientes.Add(new typeDetailIngredientes { idProducto = requestProducto.idProducto > 0 ? requestProducto.idProducto : (int)paramOutLogId.Valor, cantidad = 0, montoIndividual = requestProducto.precio });
                    }
                    else
                    {
                        requestProducto.detalleProductos.ForEach(x =>
                        {
                            idPrecio = x.idPrecio;
                            coltypeDetailIngredientes.Add(new typeDetailIngredientes { idProducto = x.idProducto, cantidad = x.cantidad, montoIndividual = x.precio });
                        });
                    }
                    if (requestProducto.idPrecio > 0)
                    {
                        repositoryMicroventas.CallProcedure<ResulProductoPrecioVenta>("[shCommon].[spAddModifyPrecioMenu]",
                        requestProducto.idSesion,
                        requestProducto.idPrecio,
                        requestProducto.idcCategoria,
                        requestProducto.nombreProducto,
                        requestProducto.producto,
                        requestProducto.contenido,
                        0,//cantidad
                        requestProducto.embase,
                        requestProducto.precio,
                        requestProducto.precioUnitario,
                        requestProducto.picProductoB64 == null ? arr1 : Convert.FromBase64String(requestProducto.picProductoB64.Replace("data:image/jpeg;base64,", "")),
                        requestProducto.activo,
                        coltypeDetailIngredientes,
                        paramOutRespuesta,
                        paramOutLogRespuesta);

                    }
                    else
                    {
                        repositoryMicroventas.CallProcedure<ResulProductoPrecioVenta>("[shCommon].[spAddPrecioMenu]",
                        requestProducto.idSesion,
                        requestProducto.idcCategoria,
                        requestProducto.nombreProducto,
                        requestProducto.producto,
                        requestProducto.contenido,
                        0,//cantidad
                        requestProducto.embase,
                        requestProducto.precio,
                        requestProducto.precioUnitario,
                        requestProducto.picProductoB64 == null ? arr1 : Convert.FromBase64String(requestProducto.picProductoB64.Replace("data:image/jpeg;base64,", "")),
                        coltypeDetailIngredientes,
                        paramOutRespuesta,
                        paramOutLogRespuesta);
                    }
                    

                }
                repositoryMicroventas.Commit();
                //repositoryMicroventas.Rollback();


            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
                repositoryMicroventas.Rollback();
            }
            return response;
        }

        public ResponseQuery<ClasificadorDTO> ObtieneClasificadorPorTipo(RequestParametrosGral requestSearchProduct)
        {
            ResponseQuery<ClasificadorDTO> response = new ResponseQuery<ClasificadorDTO> { Message = "clasificador obtenido", State = ResponseType.Success };
            try
            {
                ParamOut paramOutRespuesta = new ParamOut(true);
                ParamOut paramOutLogRespuesta = new ParamOut("");
                paramOutLogRespuesta.Size = 100;
                response.ListEntities = repositoryMicroventas.GetDataByProcedure<ClasificadorDTO>("[shCommon].[spObtClasificador]", requestSearchProduct.ParametroLong1, requestSearchProduct.ParametroLong2, paramOutRespuesta, paramOutLogRespuesta);
                

                if ((bool)paramOutRespuesta.Valor)
                {
                    response.Message = paramOutLogRespuesta.Valor.ToString();
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


