using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingFacturacion
{
    public partial class EventoSignificativo
    {
        public EventoSignificativo()
        {
            LogProcesoMasivos = new HashSet<LogProcesoMasivo>();
        }

        public long IdEventoSignificativo { get; set; }
        public int CodSucursal { get; set; }
        public int CodPuntoVenta { get; set; }
        public int CodEvento { get; set; }
        public string DescripcionEvento { get; set; }
        public int Idcufd { get; set; }
        public string CufdEvento { get; set; }
        public string XmlRequest { get; set; }
        public string XmlResponse { get; set; }
        public string CodEventoSignificativo { get; set; }
        public bool Procesado { get; set; }
        public int? Idcufdevento { get; set; }
        public DateTime? FechaHoraIni { get; set; }
        public DateTime? FechaHoraFin { get; set; }
        public int? IdRegistroEvento { get; set; }
        public string CodigoControlCufd { get; set; }
        public string CodigoControlCufdevento { get; set; }
        public long? IdOffice { get; set; }

        public virtual Office IdOfficeNavigation { get; set; }
        public virtual ICollection<LogProcesoMasivo> LogProcesoMasivos { get; set; }
    }
}
