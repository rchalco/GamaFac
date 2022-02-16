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
    public class StockManger : BaseManager
    {

        public ResponseQuery<ResulSPProductosCantidad> SearchProduct(RequestSearchProduct requestSearchProduct)
        {

            ResponseQuery<ResulSPProductosCantidad> response = new ResponseQuery<ResulSPProductosCantidad> { Message = "¨Producto obtenidos correctamente", State = ResponseType.Success };
            try
            {
                response.ListEntities = repositoryMicroventas.GetDataByProcedure<ResulSPProductosCantidad>("spProductosCantidad", requestSearchProduct.IdEmpresa, "%");
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
                if (requestRegistrarCompra.tipoUnidad == "CAJA" && requestRegistrarCompra.unidadXCaja == 0)
                {
                    response.Message = "No se cuenta con las unidaddes por caja para calcular el precio unitario";
                    response.State = ResponseType.Warning;
                }

                if (requestRegistrarCompra.tipoUnidad == "CAJA")
                {
                    requestRegistrarCompra.precioUnitario = requestRegistrarCompra.precioCaja / requestRegistrarCompra.unidadXCaja;
                    requestRegistrarCompra.cantidad = requestRegistrarCompra.cantidad * requestRegistrarCompra.unidadXCaja;
                }
                else
                {
                    requestRegistrarCompra.precioCaja = requestRegistrarCompra.precioUnitario;
                    requestRegistrarCompra.unidadXCaja = 1;
                }
                ParamOut paramOutRespuesta = new ParamOut(true);
                ParamOut paramOutLogRespuesta = new ParamOut("");
                paramOutLogRespuesta.Size = 100;
                repositoryMicroventas.CallProcedure<Response>("spCompraVentanilla", requestRegistrarCompra.idSession, requestRegistrarCompra.idOperacionDiariaCaja, requestRegistrarCompra.idProducto, requestRegistrarCompra.cantidad, requestRegistrarCompra.precioUnitario, requestRegistrarCompra.unidadXCaja, requestRegistrarCompra.precioCaja, paramOutRespuesta, paramOutLogRespuesta);
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

        public ResponseObject<LoginDTO> LoginUsuario(string Usuario, string Password)
        {

            ResponseObject<LoginDTO> response = new ResponseObject<LoginDTO> { Message = "¨Inicio de Sesión Correcto", State = ResponseType.Success };
            try
            {
                ///TODO:Encriptar el pass
                ///
                ParamOut poRespuesta = new ParamOut(false);
                ParamOut poLogRespuesta = new ParamOut("");
                poLogRespuesta.Size = 100;
                response.Object = repositoryMicroventas.GetDataByProcedure<LoginDTO>("spLogin", 1, Usuario, Password, poRespuesta, poLogRespuesta).FirstOrDefault();


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

        public ResponseQuery<SaldoCajaDTO> UltimasCajas(SaldoCajaDTO objSaldoCajaDTO)
        {

            ResponseQuery<SaldoCajaDTO> response = new ResponseQuery<SaldoCajaDTO> { Message = "¨Producto obtenidos correctamente", State = ResponseType.Success };
            try
            {
                List<SaldoCajaDTO> colSaldoCajaDTO = new List<SaldoCajaDTO>();
                /*
                colSaldoCajaDTO.Add(new SaldoCajaDTO { IdCaja = 1, FechaCierre = DateTime.Now.Date.ToShortDateString(), SaldoCierre = 200, SaldoUsuario = 190, Diferencia = 10, Observacion = "error cambio", EsCajaActual = true });
                colSaldoCajaDTO.Add(new SaldoCajaDTO { IdCaja = 2, FechaCierre = (DateTime.Now.Date.AddDays(-1)).ToShortDateString(), SaldoCierre = 300, SaldoUsuario = 300, Diferencia = 0, Observacion = "", EsCajaActual = false });
                */
                if (objSaldoCajaDTO.EstadoCaja == "APERTURA")
                    response.ListEntities = repositoryMicroventas.GetDataByProcedure<SaldoCajaDTO>("spAperturasDeCaja", objSaldoCajaDTO.idSesion, objSaldoCajaDTO.idCaja);
                else
                    response.ListEntities = repositoryMicroventas.GetDataByProcedure<SaldoCajaDTO>("spCieresDeCaja", objSaldoCajaDTO.idSesion, objSaldoCajaDTO.idCaja);

                /*
                colSaldoCajaDTO.Add(new SaldoCajaDTO { idCaja = 1, FechaCierre = DateTime.Now.Date.ToShortDateString(), SaldoCierre = 200, SaldoUsuario = 190, Diferencia = 10, Observacion = "error cambio", EsCajaActual = true });
                colSaldoCajaDTO.Add(new SaldoCajaDTO { idCaja = 2, FechaCierre = (DateTime.Now.Date.AddDays(-1)).ToShortDateString(), SaldoCierre = 300, SaldoUsuario = 300, Diferencia = 0, Observacion = "", EsCajaActual = false });
                colSaldoCajaDTO.Add(new SaldoCajaDTO { idCaja = 3, FechaCierre = (DateTime.Now.Date.AddDays(-2)).ToShortDateString(), SaldoCierre = 400, SaldoUsuario = 390, Diferencia = 0, Observacion = "ssss", EsCajaActual = false });
                */


                //response.ListEntities = colSaldoCajaDTO;
                //response.ListEntities = repositoryMicroventas.GetDataByProcedure<ResulSPProductosCantidad>("spProductosCantidad", IdEmpresa);
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public ResponseObject<SaldoCajaDTO> CierreCaja(SaldoCajaDTO requestAperturaCaja)
        {

            ResponseObject<SaldoCajaDTO> response = new ResponseObject<SaldoCajaDTO> { Message = "¨La caja se cerro correctamente", State = ResponseType.Success };
            try
            {

                response.Object = repositoryMicroventas.GetDataByProcedure<SaldoCajaDTO>("spCierreCaja", requestAperturaCaja.idSesion, requestAperturaCaja.idCaja, requestAperturaCaja.SaldoUsuario, requestAperturaCaja.Observacion).FirstOrDefault();
                if (response.Object == null)
                {
                    response.State = ResponseType.Error;
                    response.Message = "Exisitio un error al cerrar la caja " + requestAperturaCaja.idOperacionDiariaCaja.ToString();
                }

                /*
                response.Object.FechaApertura = requestAperturaCaja.FechaApertura;
                response.Object.SaldoInicial = requestAperturaCaja.SaldoInicial;
                response.Object.Observacion = requestAperturaCaja.Observacion;*/

            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public ResponseObject<SaldoCajaDTO> ObtieneCaja(RequestParametrosGral requestGral)
        {

            ResponseObject<SaldoCajaDTO> response = new ResponseObject<SaldoCajaDTO> { Message = "¨Caja obtenida", State = ResponseType.Success };
            try
            {

                TOperacionDiariaCaja ObjTOperacionDiariaCaja = new TOperacionDiariaCaja();
                ObjTOperacionDiariaCaja = repositoryMicroventas.SimpleSelect<TOperacionDiariaCaja>(x => x.FechaApertura.Date == requestGral.ParametroFecha1.Date && x.IdCaja == requestGral.ParametroLong1).FirstOrDefault();
                if (ObjTOperacionDiariaCaja == null)
                    response.Object = new SaldoCajaDTO { idCaja = requestGral.ParametroLong1, SaldoCierre = 0, SaldoInicial = 0, SaldoUsuario = 0, diferencia = 0, Observacion = "", EstadoCaja = "PENDIENTE", FechaApertura = requestGral.ParametroFecha1.Date };
                else
                    response.Object = new SaldoCajaDTO { idOperacionDiariaCaja = ObjTOperacionDiariaCaja.IdOperacionDiariaCaja, idCaja = ObjTOperacionDiariaCaja.IdCaja.Value, FechaApertura = ObjTOperacionDiariaCaja.FechaApertura, SaldoCierre = ObjTOperacionDiariaCaja.MontoCierreSis == null ? 0 : ObjTOperacionDiariaCaja.MontoCierreSis.Value, SaldoInicial = ObjTOperacionDiariaCaja.MontoApertura, SaldoUsuario = ObjTOperacionDiariaCaja.MontoCierre == null ? 0 : ObjTOperacionDiariaCaja.MontoCierre.Value, Observacion = ObjTOperacionDiariaCaja.ObservacioApertura, EstadoCaja = ObjTOperacionDiariaCaja.FechaCierre == null ? "APERTURADA" : "CERRADA" };
                //response.ListEntities = repositoryMicroventas.GetDataByProcedure<ResulSPProductosCantidad>("spProductosCantidad", IdEmpresa);
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public ResponseObject<SaldoCajaDTO> AperturaCaja(SaldoCajaDTO requestAperturaCajae)
        {

            ResponseObject<SaldoCajaDTO> response = new ResponseObject<SaldoCajaDTO> { Message = "¨La caja se aperturo correctamente", State = ResponseType.Success };
            try
            {
                response.Object = new SaldoCajaDTO();
                //validamos que no exita una caja abierta en otra fecha 
                TOperacionDiariaCaja ObjTOperacionDiariaCaja = new TOperacionDiariaCaja();
                ObjTOperacionDiariaCaja = repositoryMicroventas.SimpleSelect<TOperacionDiariaCaja>(x => x.FechaApertura.Date != requestAperturaCajae.FechaApertura.Date && x.IdCaja == requestAperturaCajae.idCaja && x.FechaCierre == null).FirstOrDefault();
                if (ObjTOperacionDiariaCaja != null)
                {
                    response.State = ResponseType.Error;
                    response.Message = "Existe una caja auna abierta en fecha " + ObjTOperacionDiariaCaja.FechaApertura.ToShortDateString() + ", debe cerrarla";
                }
                else
                    response.Object = repositoryMicroventas.GetDataByProcedure<SaldoCajaDTO>("spAperturaCaja", requestAperturaCajae.idSesion, requestAperturaCajae.idCaja, requestAperturaCajae.SaldoInicial, requestAperturaCajae.Observacion).FirstOrDefault();
                response.Object.FechaApertura = requestAperturaCajae.FechaApertura;
                response.Object.SaldoInicial = requestAperturaCajae.SaldoInicial;
                response.Object.Observacion = requestAperturaCajae.Observacion;

            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public ResponseQuery<LugarConsumoDTO> LugarConsumo(RequestParametrosGral requestGral)
        {
            ParamOut poRespuesta = new ParamOut(false);
            ParamOut poLogRespuesta = new ParamOut("");

            ResponseQuery<LugarConsumoDTO> response = new ResponseQuery<LugarConsumoDTO> { Message = "¨Sala Obtenida", State = ResponseType.Success };
            try
            {
                List<LugarConsumoDTO> colLugarConsumoDTO = new List<LugarConsumoDTO>();

                response.ListEntities = repositoryMicroventas.GetDataByProcedure<LugarConsumoDTO>("spResLugarConsumoDTO", requestGral.ParametroLong1, requestGral.ParametroLong2, poRespuesta, poLogRespuesta);
                if (response.ListEntities == null)
                {
                    response.State = ResponseType.Error;
                    response.Message = "No existen mesas, sillas ";
                }

                /*
                colLugarConsumoDTO.Add(new LugarConsumoDTO { IdLugarFisico = 1, Descripcion = "MESA 1", CantidadPersonas = 4, ConsumoActual = 50, Ocupado = true });
                colLugarConsumoDTO.Add(new LugarConsumoDTO { IdLugarFisico = 2, Descripcion = "MESA 2", CantidadPersonas = 4, ConsumoActual = 50, Ocupado = false });
                colLugarConsumoDTO.Add(new LugarConsumoDTO { IdLugarFisico = 3, Descripcion = "MESA 3", CantidadPersonas = 4, ConsumoActual = 50, Ocupado = false });
                colLugarConsumoDTO.Add(new LugarConsumoDTO { IdLugarFisico = 4, Descripcion = "MESA 4", CantidadPersonas = 4, ConsumoActual = 50, Ocupado = false });
                colLugarConsumoDTO.Add(new LugarConsumoDTO { IdLugarFisico = 5, Descripcion = "MESA 5", CantidadPersonas = 4, ConsumoActual = 50, Ocupado = true });
                colLugarConsumoDTO.Add(new LugarConsumoDTO { IdLugarFisico = 6, Descripcion = "MESA 6", CantidadPersonas = 4, ConsumoActual = 50, Ocupado = false });
                colLugarConsumoDTO.Add(new LugarConsumoDTO { IdLugarFisico = 7, Descripcion = "MESA 7", CantidadPersonas = 4, ConsumoActual = 50, Ocupado = false });
                colLugarConsumoDTO.Add(new LugarConsumoDTO { IdLugarFisico = 8, Descripcion = "MESA 8", CantidadPersonas = 4, ConsumoActual = 50, Ocupado = false });
                
                response.ListEntities = colLugarConsumoDTO;
                */

            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }


        public ResponseQuery<PersonaResumenDTO> ListaMeseros(RequestParametrosGral requestGral)
        {

            ResponseQuery<PersonaResumenDTO> response = new ResponseQuery<PersonaResumenDTO> { Message = "¨Mesero Obtenido", State = ResponseType.Success };
            try
            {
                List<PersonaResumenDTO> colPersonaResumenDTO = new List<PersonaResumenDTO>();
                colPersonaResumenDTO.Add(new PersonaResumenDTO { IdPersona = 1, NombreCompleto = "MESERO 1", IdEmpleado = 1 });
                colPersonaResumenDTO.Add(new PersonaResumenDTO { IdPersona = 2, NombreCompleto = "MESERO 2", IdEmpleado = 2 });
                colPersonaResumenDTO.Add(new PersonaResumenDTO { IdPersona = 3, NombreCompleto = "MESERO 3", IdEmpleado = 3 });

                response.ListEntities = colPersonaResumenDTO;

            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

    }
}
