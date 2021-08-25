using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    class Conexion
    {
        public void Conex()
        {
            OracleConnection oracle = new OracleConnection("DATA SOURCE= xe; PASSWORD= 1234; USER ID= PROYECTO;");
            oracle.Open();
            Console.WriteLine("Conectado!");

        }

        static void Main(string Args)
        {
            Conexion enter = new Conexion();
            enter.Conex();
        }
    }
}
