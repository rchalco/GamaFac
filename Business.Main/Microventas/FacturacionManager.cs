using Business.Main.Base;
using Business.Main.DataMappingMicroVenta;
using Business.Main.Microventas.Facturacion;
using CoreAccesLayer.Wraper;
using Domain.Main.MicroVentas.Facturacion;
using Domain.Main.Wraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Main.Microventas
{
    public class FacturacionManager : BaseManager
    {

        /// <summary>
        /// Genera una factura a partir de un objeto TransaccionVentasDTO y su detalle
        /// </summary>
        /// <returns></returns>
        public ResponseObject<FacturaDTO> GeneraFactura(FacturaDTO objTransaccionVentasDTO)
        {
            ResponseObject<FacturaDTO> Resultado = new ResponseObject<FacturaDTO>();

            try
            {
                // Obtenemos datos de la dosificacion
                Dosificacion ObjDosificacion = new Dosificacion();
                ObjDosificacion = repositoryMicroventas.SimpleSelect<Dosificacion>(x => x.Activo == true).FirstOrDefault();
                if (ObjDosificacion == null || ObjDosificacion.IdDosificacion == 0)
                {
                    Resultado.State = ResponseType.Error;
                    Resultado.Object = null;
                    Resultado.Message = "No existe dosificación activa verifique.";
                    return Resultado;
                }

                if (ObjDosificacion.FechaFin < DateTime.Now.Date)
                {
                    Resultado.State = ResponseType.Error;
                    Resultado.Object = null;
                    Resultado.Message = "La fecha de dosificación ya supero el límite, Dosifique una nueva.";
                    return Resultado;
                }

                ///obtiene cliente factura
                TClienteFac clienteFac = new TClienteFac();
                clienteFac = repositoryMicroventas.SimpleSelect<TClienteFac>(x => x.IdclienteFac == objTransaccionVentasDTO.IdclienteFac).FirstOrDefault();
                if (clienteFac == null)
                {
                    Resultado.State = ResponseType.Error;
                    Resultado.Object = null;
                    Resultado.Message = "No existe IdclienteFac " + objTransaccionVentasDTO.IdclienteFac.ToString() + " activa verifique.";
                    return Resultado;
                }

                

                long NumFactura = 0;
                NumFactura = Convert.ToInt64((ObjDosificacion.NroFacturaActual.Value + 1));
                ObjDosificacion.NroFacturaActual = NumFactura;

                Entity<Dosificacion> entity = new Entity<Dosificacion> { EntityDB = ObjDosificacion, stateEntity = StateEntity.modify };
                repositoryMicroventas.SaveObject<Dosificacion>(entity);

                //CurrentRepository.SaveChanges<Dosificacion>(ObjDosificacion, Operation.Modify);
                Factura ObjFactura = new Factura();

                ObjFactura.Anulada = false;
                ObjFactura.CompraVenta = "VENTA";
                ObjFactura.FechaEmision = DateTime.Now.Date;
                ObjFactura.Impresiones = 1;
                ObjFactura.NombreFactura = clienteFac.NombreCliente;
                ObjFactura.Nitcliente = Convert.ToInt64(clienteFac.Documento);
                ObjFactura.IdDosificacion = ObjDosificacion.IdDosificacion;
                ObjFactura.Descuento = objTransaccionVentasDTO.Descuento;

                ObjFactura.NumFactura = NumFactura;
                CodigoControImpuestos ObjCodigoControImpuestos = new CodigoControImpuestos();

                ObjCodigoControImpuestos.NumeroAutorizacion = Convert.ToInt64(ObjDosificacion.NroAutorizacion);
                ObjCodigoControImpuestos.Nit = Convert.ToInt64(clienteFac.Documento);
                ObjCodigoControImpuestos.NroFactura = NumFactura;
                ObjCodigoControImpuestos.LlaveDosificacion = ObjDosificacion.LlaveDosificacion;
                string FechaFactura = (DateTime.Now.Date).ToString("yyyyMMdd");
                ObjCodigoControImpuestos.Fecha = Convert.ToInt64(FechaFactura);
                decimal MontoFact5ura = Math.Round((decimal)objTransaccionVentasDTO.MontoFactura - (decimal)objTransaccionVentasDTO.Descuento, 0, MidpointRounding.AwayFromZero);
                ObjCodigoControImpuestos.Monto = Convert.ToInt64(MontoFact5ura);
                string CodigoControl = ObjCodigoControImpuestos.GeneraCodigoControl();
                ObjFactura.CodControl = CodigoControl;

                //CurrentRepository.SaveChanges<Factura>(ObjFactura, Operation.Add);
                Entity<Factura> entity1 = new Entity<Factura> { EntityDB = ObjFactura, stateEntity = StateEntity.add };
                repositoryMicroventas.SaveObject<Factura>(entity1);

                List<FacturasDetalle> ColFacturasDetalle = new List<FacturasDetalle>();
                /// GRABAR DETALLE DE LA FACTURA
                if (objTransaccionVentasDTO.FacturasDetalle != null && objTransaccionVentasDTO.FacturasDetalle.Count > 0)
                {
                    FacturasDetalle ObjFacturasDetalle;
                    Entity<FacturasDetalle> entity3 = new Entity<FacturasDetalle>();

                    foreach (FacturasDetalleDTO item in objTransaccionVentasDTO.FacturasDetalle)
                    {
                        ObjFacturasDetalle = new FacturasDetalle();
                        ObjFacturasDetalle.IdFactura = ObjFactura.IdFactura;
                        ObjFacturasDetalle.IdItem = item.IdItem;
                        ObjFacturasDetalle.Cantidad = item.Cantidad;
                        ObjFacturasDetalle.Monto = item.Monto;
                        ObjFacturasDetalle.Concepto = item.Concepto;
                        ObjFacturasDetalle.Ice = 0;
                        ObjFacturasDetalle.Excento = 0;
                        ObjFacturasDetalle.Descuento = item.Descuento;
                        //ObjFacturasDetalle.fa = null;
                        //CurrentRepository.SaveChanges<FacturasDetalle>(ObjFacturasDetalle, Operation.Add);
                        entity3 = new Entity<FacturasDetalle> { EntityDB = ObjFacturasDetalle, stateEntity = StateEntity.add };
                        repositoryMicroventas.SaveObject<FacturasDetalle>(entity3);
                        ColFacturasDetalle.Add(ObjFacturasDetalle);
                    }
                }

                FacturaDTO ObjFacturaDTO = new FacturaDTO();
                ObjFactura.FacturasDetalles = ColFacturasDetalle;
                ObjFacturaDTO.IdFactura = ObjFactura.IdFactura;
                //AutoMapper.Mapper.CreateMap<Factura, FacturaDTO>();
                //AutoMapper.Mapper.CreateMap<FacturasDetalle, FacturasDetalleDTO>();
                //AutoMapper.Mapper.CreateMap<Dosificacion, DosificacionDTO>();
                //ObjFacturaDTO = AutoMapper.Mapper.Map<Factura, FacturaDTO>(ObjFactura);
                Resultado.State = ResponseType.Success;
                Resultado.Object = new FacturaDTO();
                Resultado.Object = ObjFacturaDTO;
                objTransaccionVentasDTO.IdFactura = ObjFactura.IdFactura;
                objTransaccionVentasDTO.NumFactura = ObjFactura.NumFactura;
                repositoryMicroventas.Commit();

                Resultado.State = ResponseType.Success;
                Resultado.Message = Convert.ToString("Factura generada");

            }
            catch (Exception ex)
            {
                ProcessError(ex, Resultado);
            }
            return Resultado;
        }


    }


}
