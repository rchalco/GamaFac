using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Facturacion
{
    public class FacturaDTO
    {
        public FacturaDTO()
        {
            this.FacturasDetalle = new HashSet<FacturasDetalleDTO>();
        }

        public int IdFactura { get; set; }
        public int IdDosificacion { get; set; }
        public decimal NumFactura { get; set; }
        public long NITCliente { get; set; }
        public string NombreFactura { get; set; }
        public string CompraVenta { get; set; }
        public bool Anulada { get; set; }
        public int Impresiones { get; set; }
        public System.DateTime FechaEmision { get; set; }
        public Nullable<System.DateTime> FechaUltModificacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public string CodControl { get; set; }
        public string NroAutorizacion { get; set; }
        public decimal MontoFactura { get; set; }
        public decimal Efectivo { get; set; }
        public decimal Cambio { get; set; }
        public decimal Descuento { get; set; }
        public long IdclienteFac { get; set; }
        public virtual DosificacionDTO Dosificacion { get; set; }
        public virtual ICollection<FacturasDetalleDTO> FacturasDetalle { get; set; }
    }
}
