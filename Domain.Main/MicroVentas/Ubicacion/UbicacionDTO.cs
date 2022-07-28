using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Ubicacion
{
    public  class UbicacionDTO
    {
        public long idUbicacion { get; set; }
        public long idSesion { get; set; }
        public string nombreParqueo { get; set; }
        public int capacidad { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime? fechaVigenciaHasta { get; set; }
        public bool activo { get; set; }
      


    }
}
