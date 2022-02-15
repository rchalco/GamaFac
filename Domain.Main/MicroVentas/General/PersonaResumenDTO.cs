using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.General
{
    public class PersonaResumenDTO
    {
        public int IdPersona { get; set; }
        public string Nombre1 { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Documento { get; set; }
        public string NIT { get; set; }
        public string RazonSocial { get; set; }
        public string NombreCompleto { get; set; }
        public int IdEmpleado { get; set; }
    }
}
