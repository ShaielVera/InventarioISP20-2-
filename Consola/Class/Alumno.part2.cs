using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola.Class
{
    partial class Alumno
    {
        public static string ImprimirCantidadDeInstancias()
        {
            return $"Cantidad de instancias de la clase Alumos: {instancias_de_alumnos}";
        }
    }
}
