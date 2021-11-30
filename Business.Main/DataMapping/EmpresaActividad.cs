using System;
using System.Collections.Generic;

namespace Business.Main.DataMapping
{
    public partial class EmpresaActividad
    {
        public string IdEmpresaActividad { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdActividad { get; set; }
        public bool? Activo { get; set; }

        public virtual Actividad IdActividadNavigation { get; set; }
        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual PuntoActividad PuntoActividad { get; set; }
    }
}
