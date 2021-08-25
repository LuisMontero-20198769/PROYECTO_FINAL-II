using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class OracleConexion
    {
        protected string strOracle = string.Empty;

        public OracleConexion()
        {
            strOracle = ConfigurationManager.ConnectionStrings[""].ConnectionString;
        }
    }
}
