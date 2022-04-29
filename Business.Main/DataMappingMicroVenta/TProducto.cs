using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TProducto
    {
        public long IdProducto { get; set; }
        public long? Idsesion { get; set; }
        public long? IdEmpresa { get; set; }
        public long IdClasificador { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string UnidadDeMedida { get; set; }
        public bool Stockeado { get; set; }
        public byte[] PicProducto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaVigenciaHasta { get; set; }
    }
}
