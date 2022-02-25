using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TCategoria
    {
        public int IdCategoria { get; set; }
        public long? IdEmpresa { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaVigenciaHasta { get; set; }
    }
}
