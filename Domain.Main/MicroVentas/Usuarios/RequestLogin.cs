using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Usuarios
{
    public class RequestLogin
    {
        public string usuario { get; set; }
        public string password { get; set; }
        public string passwordNuevo { get; set; }
        public long idEmpresa { get; set; }
        /// <summary>
        /// 0 = fabula, 1 = parqueo
        /// </summary>
        public int aplicacion { get; set; }
    }
}
