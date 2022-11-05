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
    public class VentaManager : BaseManager
    {
        public Response RegistrarVentas(RequestRegistroVenta requestRegistroVentas)
        {
            Response response = new Response { Message = "Venta registrada correctamente", State = ResponseType.Success };
            try
            {
                ParamOut paramOutRespuesta = new ParamOut(true);
                ParamOut paramOutLogRespuesta = new ParamOut("");
                paramOutLogRespuesta.Size = 100;
                repositoryMicroventas.CallProcedure<Response>("spVentaVentanilla", requestRegistroVentas.idSesion, requestRegistroVentas.idOperacionDiariaCaja, requestRegistroVentas.detalleVentas, paramOutRespuesta, paramOutLogRespuesta);
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

        public ResponseQuery<ResulProductoPrecioVenta> ObtieneProductosVenta(RequestSearchProduct requestSearchProduct)
        {
            ResponseQuery<ResulProductoPrecioVenta> response = new ResponseQuery<ResulProductoPrecioVenta> { Message = "Venta registrada correctamente", State = ResponseType.Success };
            try
            {
                ParamOut paramOutRespuesta = new ParamOut(true);
                ParamOut paramOutLogRespuesta = new ParamOut("");
                paramOutLogRespuesta.Size = 100;
                response.ListEntities = repositoryMicroventas.GetDataByProcedure<ResulProductoPrecioVenta>("shCommon.spObtienePrecios", requestSearchProduct.idSession, "", paramOutRespuesta, paramOutLogRespuesta);

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

        public ResponseQuery<ResulObtieneFormasdePago> ObtieneFormasdePago(RequestSPObtFormasDePago requestSPObtFormasDePago)
        {
            ResponseQuery<ResulObtieneFormasdePago> response = new ResponseQuery<ResulObtieneFormasdePago> { Message = "Formas de pago obtenidos correctamente", State = ResponseType.Success };
            try
            {
                ParamOut paramOutRespuesta = new ParamOut(true);
                ParamOut paramOutLogRespuesta = new ParamOut("");
                paramOutLogRespuesta.Size = 100;

                response.ListEntities = repositoryMicroventas.GetDataByProcedure<ResulObtieneFormasdePago>("shCommon.spObtFormasDePago",
                    requestSPObtFormasDePago.idSesion,
                    requestSPObtFormasDePago.idFechaProceso,
                    paramOutRespuesta,
                    paramOutLogRespuesta);
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public ResponseQuery<ResulProductoPrecioVentaComplex> ObtienePorAlmacenExpress(RequestSearchProduct requestSearchProduct)
        {
            ResponseQuery<ResulProductoPrecioVentaComplex> response = new ResponseQuery<ResulProductoPrecioVentaComplex> { Message = "Venta registrada correctamente", State = ResponseType.Success };
            try
            {
                ParamOut paramOutRespuesta = new ParamOut(true);
                ParamOut paramOutLogRespuesta = new ParamOut("");
                paramOutLogRespuesta.Size = 100;
                var resulBD = repositoryMicroventas.GetDataByProcedure<ResulProductoPrecioVenta>("shBusiness.spObtienePrecios", requestSearchProduct.idSession, "", paramOutRespuesta, paramOutLogRespuesta);

                if ((bool)paramOutRespuesta.Valor)
                {
                    response.Message = paramOutLogRespuesta.Valor.ToString();
                    response.State = ResponseType.Error;
                    return response;
                }

                resulBD.ForEach(x =>
                {
                    ResulProductoPrecioVentaComplex resulProductoPrecioVentaComplex;
                    if (response.ListEntities.Any(y => y.categoria.Equals(x.categoria)))
                    {
                        resulProductoPrecioVentaComplex = response.ListEntities.First(y => y.categoria.Equals(x.categoria));
                    }
                    else
                    {
                        resulProductoPrecioVentaComplex = new ResulProductoPrecioVentaComplex
                        {
                            categoria = x.categoria,
                            picProducto = Convert.FromBase64String(x.picProductoB64),
                            //etiquetaDerecha = x.etiquetaDerecha,
                            //etiquetaIzquierda = x.etiquetaIzquierda,
                            //slide = x.slide,
                            detalle = new List<ResulProductoPrecioVenta>()
                        };
                        response.ListEntities.Add(resulProductoPrecioVentaComplex);
                    }
                    resulProductoPrecioVentaComplex.detalle.Add(x);
                });


            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public ResponseQuery<ResulProductoPrecioVenta> ObtienePorAlmacenExpressSimple(RequestSearchProduct requestSearchProduct)
        {
            ResponseQuery<ResulProductoPrecioVenta> response = new ResponseQuery<ResulProductoPrecioVenta> { Message = "Productos obtenidos", State = ResponseType.Success };
            try
            {
                ParamOut paramOutRespuesta = new ParamOut(true);
                ParamOut paramOutLogRespuesta = new ParamOut("");
                paramOutLogRespuesta.Size = 100;
                response.ListEntities = repositoryMicroventas.GetDataByProcedure<ResulProductoPrecioVenta>("shCommon.spObtienePrecios", requestSearchProduct.idSession, "", paramOutRespuesta, paramOutLogRespuesta);

                response.ListEntities.ForEach(item =>
                {
                    if (item.picProducto != null)
                        item.picProductoB64 = Convert.ToBase64String(item.picProducto);

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

        public ResponseQuery<PedidosPorEntregarDTO> ObtienePedidosPorEntregarExpress(RequestParametrosGral requestParametrosGral)
        {
            ResponseQuery<PedidosPorEntregarDTO> response = new ResponseQuery<PedidosPorEntregarDTO> { Message = "Productos obtenidos", State = ResponseType.Success };
            try
            {
                ParamOut paramOutRespuesta = new ParamOut(true);
                ParamOut paramOutLogRespuesta = new ParamOut("");
                paramOutLogRespuesta.Size = 100;
                response.ListEntities = repositoryMicroventas.GetDataByProcedure<PedidosPorEntregarDTO>("shBusiness.spObtienePedidosPorEntregar", requestParametrosGral.ParametroLong1, paramOutRespuesta, paramOutLogRespuesta);

               

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

        public Response ActualizaPedidoExpress(RequestParametrosGral requestParametrosGral)
        {

            Response response = new Response { Message = "Datos actualizados", State = ResponseType.Success };
            try
            {
                long id = 0;
                ParamOut poRespuesta = new ParamOut(false);
                ParamOut poLogRespuesta = new ParamOut("");
                poLogRespuesta.Size = 100;

                repositoryMicroventas.CallProcedure<Response>("shBusiness.spActulizaEstadoPedido", requestParametrosGral.ParametroLong1, requestParametrosGral.ParametroInt1, requestParametrosGral.ParametroLong2, poRespuesta, poLogRespuesta);



                if ((bool)poRespuesta.Valor)
                {
                    response.Message = poLogRespuesta.Valor.ToString();
                    response.State = ResponseType.Error;
                    return response;
                }


                repositoryMicroventas.Commit();

            }
            catch (Exception ex)
            {
                response.State = ResponseType.Error;
                response.Message = ex.Message;
                repositoryMicroventas.Rollback();
                ProcessError(ex, response);
            }
            return response;
        }



    }
}
