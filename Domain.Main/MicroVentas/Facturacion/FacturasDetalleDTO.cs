using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Facturacion
{
    public class FacturasDetalleDTO
    {
        public int IdFacturaDetalle { get; set; }
        public Nullable<int> IdFactura { get; set; }
        public Nullable<int> IdItem { get; set; }
        public string Concepto { get; set; }

        public Nullable<int> Cantidad { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public Nullable<decimal> ICE { get; set; }
        public Nullable<decimal> Excento { get; set; }
        public Nullable<decimal> Descuento { get; set; }
    }
}
