using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingFacturacion
{
    public partial class Cufd
    {
        public Cufd()
        {
            Invoices = new HashSet<Invoice>();
        }

        public long IdCufd { get; set; }
        public string ValorCufd { get; set; }
        public string CodigoControl { get; set; }
        public string CuisRequest { get; set; }
        public bool EsRegistroActual { get; set; }
        public DateTime FechaHora { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public long IdOffice { get; set; }
        public long? IdCuis { get; set; }

        public virtual Cui IdCuisNavigation { get; set; }
        public virtual Office IdOfficeNavigation { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
