using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TmenuOpcione
    {
        public int IdMenuOpcion { get; set; }
        public int IdEmpresa { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string Decripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaVigenciaHasta { get; set; }
    }
}
