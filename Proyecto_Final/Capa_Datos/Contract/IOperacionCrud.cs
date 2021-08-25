using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Contract
{
    public interface IOperacionCrud<T>
    {
        string insertar(T dto);
        string actualizar(T dto);
        string eliminar(string dto);
        List<T> Listar();

    }
}
