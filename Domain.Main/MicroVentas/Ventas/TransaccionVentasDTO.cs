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
            this.TransaccionDetalle = new HashSet<TransaccionVentasDetalleDTO>();
        }
        public int idTransaccion { get; set; }

        public int idCaja { get; set; }
        /// <summary>
        /// A quien es asignada la venta
        /// </summary>
        public Nullable<int> idcRelacion { get; set; }

        public Nullable<int> idcTipoTransaccion { get; set; }

        public string nombreRelacion { get; set; }
        public string nombre { get; set; }
        public string di { get; set; }
        public Nullable<System.DateTime> fechaHora { get; set; }
        public Nullable<decimal> montoEntrada { get; set; }
        public Nullable<decimal> montoSalida { get; set; }
        public Nullable<decimal> descuento { get; set; }
        public Nullable<int> idcEstado { get; set; }
        public string estado { get; set; }
        public Nullable<System.DateTime> fechaCambioEstado { get; set; }
        public Nullable<int> idRelacionOperacion { get; set; }

        public string observaciones { get; set; }

        public bool? esEfectivo { get; set; }
        public Nullable<decimal> comision { get; set; }
        public string bancoDestinoComision { get; set; }
        public Nullable<int> idcFormaPagoComision { get; set; }
        public Nullable<int> idcFormaPago { get; set; }
        public virtual ICollection<TransaccionVentasDetalleDTO> TransaccionDetalle { get; set; }

    }
}
