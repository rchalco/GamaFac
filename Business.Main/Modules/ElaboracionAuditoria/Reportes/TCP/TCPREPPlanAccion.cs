using Business.Main.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resportes.ReportDTO
{
    class TCPREPPlanAccion : IObjectReport
    {
        public string NombreEmpresa { get; set; }
        public string TipoAuditoria { get; set; }
        public string Norma { get; set; }
        public string Fecha { get; set; }
        public string AuditorLider { get; set; }
        public List<HallazgosPAC> ListHallazgosPAC { get; set; }

    }

    class HallazgosPAC
    {
        public int nro { get; set; }
        public string TipoHallazgo { get; set; }
        public string Descripcion { get; set; }
        public string Correccion { get; set; }
        public string AnalisisCausa { get; set; }
        public string AccionesCorrectivas { get; set; }
        public string Responsable { get; set; }
        public string FechaCumplimiento { get; set; }
        public string PresentaEvidencia { get; set; }
        public string ComentariosAuditor { get; set; }
        public string Verificacion { get; set; }
        public string Aprobacion { get; set; }
    }
}
