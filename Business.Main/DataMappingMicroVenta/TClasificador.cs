using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TClasificador
    {
        public long IdClasificador { get; set; }
        public long IdSesion { get; set; }
        public long IdClasificadorTipo { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaVigenciHasta { get; set; }
    }
}
