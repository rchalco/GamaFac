using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Persona
{
    public class PersonaDTO
    {
        public long idPersona { get; set; }
        public string DocumentoDeIdentidad { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string celular { get; set; }

    }
}
