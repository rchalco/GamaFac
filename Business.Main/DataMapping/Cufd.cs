using System;
using System.Collections.Generic;

namespace Business.Main.DataMapping
{
    public partial class Cufd
    {
        public long IdCufd { get; set; }
        public string CufdValue { get; set; }
        public string Cuis { get; set; }
        public int IdPuntoAtencion { get; set; }
        public string Xmlrequest { get; set; }
        public string Xmlresponse { get; set; }
        public DateTime FechaHora { get; set; }

        public virtual PuntoAtencion IdPuntoAtencionNavigation { get; set; }
    }
}
