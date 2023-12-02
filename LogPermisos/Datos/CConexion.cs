using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogPermisos.Datos
{
    class CConexion
    {
        private string conn;
        public string strinCon(string nomBD)
        {
            conn = ConfigurationManager.ConnectionStrings[nomBD]
                .ConnectionString;
            return conn;
        }
    }
}
