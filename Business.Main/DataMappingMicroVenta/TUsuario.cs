using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TUsuario
    {
        public long IdUsuario { get; set; }
        public long IdSesion { get; set; }
        public long IdPersona { get; set; }
        public long IdEmpresa { get; set; }
        public long IdRol { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaVigenciaHasta { get; set; }
    }
}
