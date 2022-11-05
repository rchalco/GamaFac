using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Ventas
{
    public class TransaccionVentasDTO
    {
        public TransaccionVentasDTO()
        {
            this.transaccionDetalle = new List<TransaccionVentasDetalleDTO>();
        }
        public long idPedMaster { get; set; }

        public long idCajaOperacionDiariaCaja { get; set; }
        public long idCaja { get; set; }
        public long idMesero { get; set; }
        public long idAlmacen { get; set; }
        /// <summary>
        /// A quien es asignada la venta
        /// </summary>
        //public Nullable<long> idcRelacion { get; set; }

        public Nullable<long> idcTipoTransaccion { get; set; }

        //public string nombreRelacion { get; set; }
        //public string nombre { get; set; }
        //public string di { get; set; }
        public Nullable<System.DateTime> fechaHora { get; set; }
        public decimal montoPedido { get; set; }
        //public Nullable<decimal> montoSalida { get; set; }
        //public Nullable<decimal> descuento { get; set; }
        //public Nullable<long> idcEstado { get; set; }
        //public string estado { get; set; }
        //public Nullable<System.DateTime> fechaCambioEstado { get; set; }
        public Nullable<long> idAmbiente { get; set; }

        public string observaciones { get; set; }

        //public bool? esEfectivo { get; set; }
        //public Nullable<decimal> comision { get; set; }
        //public string bancoDestinoComision { get; set; }
        //public Nullable<long> idcFormaPagoComision { get; set; }
        //public Nullable<long> idcFormaPago { get; set; }
        

        public List<TransaccionVentasDetalleDTO> transaccionDetalle { get; set; }

        ///OTROS DATOS
        public long idSesion { get; set; }
        public long idEmpresa { get; set; }

        public long idFechaProceso { get; set; }

    }
}
