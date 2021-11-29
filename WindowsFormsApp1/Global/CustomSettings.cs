using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Global
{
    internal class CustomSettings
    {
        public static string TokenImpuestos = "TokenApi " + ConfigurationManager.AppSettings["token_impuestos"];
    }
}
