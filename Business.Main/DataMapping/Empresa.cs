using System;
using System.Collections.Generic;

namespace Business.Main.DataMapping
{
    public partial class Empresa
    {
        public Empresa()
        {
            EmpresaActividads = new HashSet<EmpresaActividad>();
            PuntoAtencions = new HashSet<PuntoAtencion>();
        }

        public int IdEmpresa { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Logo { get; set; }

        public virtual ICollection<EmpresaActividad> EmpresaActividads { get; set; }
        public virtual ICollection<PuntoAtencion> PuntoAtencions { get; set; }
    }
}
