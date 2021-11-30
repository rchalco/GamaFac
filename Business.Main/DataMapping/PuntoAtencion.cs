using System;
using System.Collections.Generic;

namespace Business.Main.DataMapping
{
    public partial class PuntoAtencion
    {
        public PuntoAtencion()
        {
            Cufds = new HashSet<Cufd>();
            Facturas = new HashSet<Factura>();
            PuntoActividads = new HashSet<PuntoActividad>();
        }

        public int IdPuntoAtencion { get; set; }
        public int? IdEmpresa { get; set; }
        public string Cuis { get; set; }
        public string NombrePunto { get; set; }
        public int? TipoSin { get; set; }
        public string TipoSindescripcion { get; set; }
        public int? IdSucursalSin { get; set; }
        public string IdPuntoVentaSin { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<Cufd> Cufds { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<PuntoActividad> PuntoActividads { get; set; }
    }
}
