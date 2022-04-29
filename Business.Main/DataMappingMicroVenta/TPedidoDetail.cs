using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TPedidoDetail
    {
        public long IdPedDetail { get; set; }
        public long? IdSesion { get; set; }
        public long? IdPedMaster { get; set; }
        public long? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
