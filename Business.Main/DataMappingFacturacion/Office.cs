using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingFacturacion
{
    public partial class Office
    {
        public Office()
        {
            Cufds = new HashSet<Cufd>();
            Cuis = new HashSet<Cui>();
            EventoSignificativos = new HashSet<EventoSignificativo>();
            Invoices = new HashSet<Invoice>();
        }

        public long IdOffice { get; set; }
        public int IdPuntoVentaSin { get; set; }
        public string Name { get; set; }
        public string Nit { get; set; }
        public int? CodigoModalidad { get; set; }
        public int? CodigoAmbiente { get; set; }
        public string CodigoSistema { get; set; }
        public string CodigoSucursal { get; set; }
        public string CodigoTipoPuntoVenta { get; set; }
        public string CuisCreacion { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cufd> Cufds { get; set; }
        public virtual ICollection<Cui> Cuis { get; set; }
        public virtual ICollection<EventoSignificativo> EventoSignificativos { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
