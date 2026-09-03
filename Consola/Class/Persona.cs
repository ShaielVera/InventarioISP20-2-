using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola.Class
{
    public class Persona()
    {
        public string nombre = string.Empty;
        private int edad = 0;

        public void CumplirAnios()
        {
            edad++;
            Console.WriteLine($"La edad es {edad}");
        }
        public virtual void Hablar()
        {
            Console.WriteLine("Hola");
        }
    }
}
