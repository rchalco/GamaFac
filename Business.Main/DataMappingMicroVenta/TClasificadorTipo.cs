using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TClasificadorTipo
    {
        public long IdClasificadorTipo { get; set; }
        public long? IdSesion { get; set; }
        public int? IdEmpresa { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaVigenciHasta { get; set; }
    }
}
