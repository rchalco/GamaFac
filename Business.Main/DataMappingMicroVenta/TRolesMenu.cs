using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TRolesMenu
    {
        public int IdrolMenu { get; set; }
        public int IdMenuOpcion { get; set; }
        public int IdRol { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaVigenciaHasta { get; set; }
    }
}
