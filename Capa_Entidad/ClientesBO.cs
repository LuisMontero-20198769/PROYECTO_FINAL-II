using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class ClientesBO
    {
          // ID INT PRIMARY KEY,
         //CEDULA VARCHAR(15) NOT NULL,
        //NOMBRE VARCHAR2(40) NOT NULL,
       //TELEFONO INT,
      //CORREO VARCHAR2(50),
     //CATEGORIA VARCHAR2(10)

        public int ID { get; set; }
        public string CEDULA { get; set; }
        public string NOMBRE { get; set; }
        public int TELEFONO { get; set; }
        public string CORREO { get; set; }
        public string CATEGORIA { get; set; }
    }
}
