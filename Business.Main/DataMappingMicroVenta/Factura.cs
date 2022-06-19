using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class Factura
    {
        public Factura()
        {
            FacturasDetalles = new HashSet<FacturasDetalle>();
        }

        public int IdFactura { get; set; }
        public int IdDosificacion { get; set; }
        public decimal NumFactura { get; set; }
        public long? Nitcliente { get; set; }
        public string NombreFactura { get; set; }
        public string CompraVenta { get; set; }
        public bool Anulada { get; set; }
        public int Impresiones { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime? FechaUltModificacion { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        public string CodControl { get; set; }
        public decimal? Descuento { get; set; }

        public virtual ICollection<FacturasDetalle> FacturasDetalles { get; set; }
    }
}
