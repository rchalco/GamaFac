using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TEmpresa
    {
        public long IdEempresa { get; set; }
        public string RazonSocialVc { get; set; }
        public string TipoContribuyente { get; set; }
        public string NitEmpresaVc { get; set; }
        public bool? Activo { get; set; }
        public string NombreSucursal { get; set; }
        public string Direccion { get; set; }
        public string Zona { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
        public long? IdPadreNb { get; set; }
        public string Firma { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaVigenciaHasta { get; set; }
    }
}
