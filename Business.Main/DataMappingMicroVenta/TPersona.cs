using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TPersona
    {
        public long IdPersona { get; set; }
        public long IdSesion { get; set; }
        public string DocumentoDeIdentidad { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string Celular { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaVigenciaHasta { get; set; }
    }
}
