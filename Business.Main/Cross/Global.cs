using PlumbingProps.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Main.Cross
{
    public static class Global
    {
        public static string URIGLOBAL_SERVICES = ConfigManager.GetConfiguration().GetSection("URIGLOBAL_SERVICES").Value;
        public static string URIGLOBAL_CLASIFICADOR = ConfigManager.GetConfiguration().GetSection("URIGLOBAL_CLASFICADOR").Value;
       

    }
}
