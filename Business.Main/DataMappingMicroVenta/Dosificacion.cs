using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class Dosificacion
    {
        public int IdDosificacion { get; set; }
        public string NroAutorizacion { get; set; }
        public string LlaveDosificacion { get; set; }
        public DateTime? FechaFin { get; set; }
        public decimal? NroFacturaActual { get; set; }
        public decimal? NumFacturaInicial { get; set; }
        public decimal? NumFacturaFin { get; set; }
        public bool? Activo { get; set; }
    }
}
