using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TfacTipoDocumento
    {
        public int IdfactipoDocumento { get; set; }
        public long IdSesion { get; set; }
        public string TipoDocumento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaVigenciHasta { get; set; }
    }
}
