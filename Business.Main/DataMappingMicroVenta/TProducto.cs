using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TProducto
    {
        public long IdProducto { get; set; }
        public long? IdEmpresa { get; set; }
        public int Idcategoria { get; set; }
        public string NombreProducto { get; set; }
        public string Marca { get; set; }
        public string Contenido { get; set; }
        public int? CajaXunidades { get; set; }
        public string Descripcion { get; set; }
        public byte[] PicProducto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaVigenciaHasta { get; set; }
    }
}
