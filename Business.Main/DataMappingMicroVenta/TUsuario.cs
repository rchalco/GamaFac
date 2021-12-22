using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TUsuario
    {
        public long IdUsuario { get; set; }
        public long IdEmpresa { get; set; }
        public string DocumentoDeIdentidad { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public long IdRol { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
        public string Celular { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaVigenciaHasta { get; set; }
    }
}
