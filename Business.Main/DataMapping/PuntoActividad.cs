using System;
using System.Collections.Generic;

namespace Business.Main.DataMapping
{
    public partial class PuntoActividad
    {
        public string IdPuntoActividad { get; set; }
        public int? IdEmpresaActividad { get; set; }
        public int? IdPuntoAtencion { get; set; }
        public bool? Activo { get; set; }

        public virtual EmpresaActividad IdPuntoActividadNavigation { get; set; }
        public virtual PuntoAtencion IdPuntoAtencionNavigation { get; set; }
    }
}
