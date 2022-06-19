using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TClienteFac
    {
        public long IdclienteFac { get; set; }
        public long? IdSesion { get; set; }
        public long? IdEmpresa { get; set; }
        public int? IdTipoDocumento { get; set; }
        public long Documento { get; set; }
        public string Complemento { get; set; }
        public string Extension { get; set; }
        public string NombreCliente { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumCelular { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaRegistroHasta { get; set; }
    }
}
