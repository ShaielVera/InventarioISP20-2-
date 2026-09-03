using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola.Class
{
    public class Estudiante: Persona
    {
        //private string nombre=string.Empty;

        public string Nombre
        {
            get { return nombre.ToUpper(); }
            set { nombre = value; }
        }

        public string Domicilio { get; set; } = string.Empty;

        public int Edad { get; set; }

        //creamos una propiedad llamada DatosCompletos que concatena todos los datos del estudiante y los devuelve al llamarla
        public string DatosCompletos 
        {
            get { return $"Nombre: {Nombre}, Edad:{Edad}, Domicilio:{Domicilio}"; }
        }

        public void Saludar()
        {
            Console.WriteLine($"Hola, soy el estudiante {this.Nombre} y tengo {this.Edad} años");
        }

        public override void Hablar()
        {
            Console.WriteLine("Hola soy estudiante");
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
