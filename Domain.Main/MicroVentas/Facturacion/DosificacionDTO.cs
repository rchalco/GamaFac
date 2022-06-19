using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Facturacion
{
    public class DosificacionDTO
    {
        public DosificacionDTO()
        {
            //this.Factura = new HashSet<Factura>();
        }

        public int IdDosificacion { get; set; }
        public string NroAutorizacion { get; set; }
        public string LlaveDosificacion { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<decimal> NroFacturaActual { get; set; }
        public Nullable<decimal> NumFacturaInicial { get; set; }
        public Nullable<decimal> NumFacturaFin { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}
