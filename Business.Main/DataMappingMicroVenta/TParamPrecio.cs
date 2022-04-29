using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TParamPrecio
    {
        public long IdPrecio { get; set; }
        public long IdSesion { get; set; }
        public long IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string Embase { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioUnitario { get; set; }
        public byte[] PicProducto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaVigenciaHasta { get; set; }
    }
}
