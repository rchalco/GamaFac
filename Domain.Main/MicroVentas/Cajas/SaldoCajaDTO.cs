﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Cajas
{
    public class SaldoCajaDTO
    {
        public long idCaja { get; set; }
        public string nombreCaja { get; set; }
        public string FechaCierre { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal SaldoCierre { get; set; }
        public decimal SaldoUsuario { get; set; }
        public decimal diferencia { get; set; }
        public string Observacion { get; set; }
        public bool EsCajaActual { get; set; }
        public string EstadoCaja { get; set; }
        public long idOperacionDiariaCaja { get; set; }
        public long idSesion { get; set; }
        public DateTime FechaApertura { get; set; }


    }
}