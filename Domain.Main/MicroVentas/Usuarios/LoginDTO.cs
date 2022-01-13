﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Usuarios
{
    public class LoginDTO
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string PasswordNuevo { get; set; }
        public string DescripcionError { get; set; }
    }
}
