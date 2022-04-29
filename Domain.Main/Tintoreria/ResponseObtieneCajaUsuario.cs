using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Tintoreria
{
    public class ResponseObtieneCajaUsuario
    {
        public int idCaja { get; set; }
        public string Descripcion { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string Usuario { get; set; }
    }
}
