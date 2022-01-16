using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Usuarios
{
    public class LoginDTO
    {
        public long IdUsuario { get; set; }
        public string usuario_vc { get; set; }
        public string Password { get; set; }
        public string PasswordNuevo { get; set; }
        public string Log_respuesta { get; set; }
        public long sesion { get; set; }
        public long IdOperacionDiariaCaja { get; set; }
        public bool respuesta { get; set; }
        public string rol_name { get; set; }
        public long idCaja { get; set; }


    }
}
