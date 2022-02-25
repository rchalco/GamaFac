using System;
using System.Collections.Generic;

namespace Business.Main.DataMapping
{
    public partial class Actividad
    {
        public Actividad()
        {
            EmpresaActividads = new HashSet<EmpresaActividad>();
        }

        public int IdActividad { get; set; }
        public string CodigoCaeb { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<EmpresaActividad> EmpresaActividads { get; set; }
    }
}
