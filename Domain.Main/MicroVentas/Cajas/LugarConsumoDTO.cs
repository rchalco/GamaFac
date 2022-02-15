using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Cajas
{
    public  class LugarConsumoDTO
    {
        public int IdLugarFisico { get; set; }
        public Nullable<int> IdcSala { get; set; }
        public Nullable<int> IdcTipoLugar { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Ocupado { get; set; }
        public Nullable<int> CantidadPersonas { get; set; }
        public string SalaTipo { get; set; }
        public string Sala { get; set; }
        public decimal ConsumoActual { get; set; }
        string _EstadoLugar;
        public string EstadoLugar 
        { 
            get { return Ocupado == true ? "OCUPADO" : "LIBRE"; }
            set { _EstadoLugar = value;} 
        }
        public byte[] picMesa { get; set; }

        public Nullable<int> IdTransaccion { get; set; }
        public Nullable<DateTime> FechaHora { get; set; }
    }
}
