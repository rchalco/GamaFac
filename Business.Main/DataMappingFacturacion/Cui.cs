using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingFacturacion
{
    public partial class Cui
    {
        public Cui()
        {
            Cufds = new HashSet<Cufd>();
        }

        public long IdCuis { get; set; }
        public string ValorCuis { get; set; }
        public bool EsRegistroActual { get; set; }
        public DateTime FechaHora { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public long IdOfficeMf { get; set; }
        public long IdOffice { get; set; }

        public virtual Office IdOfficeNavigation { get; set; }
        public virtual ICollection<Cufd> Cufds { get; set; }
    }
}
