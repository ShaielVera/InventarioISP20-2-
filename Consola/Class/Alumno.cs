using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Consola.Class
{
    public partial class Alumno
    {
        static int instancias_de_alumnos = 0; //variable estatica para contar las instancias de la clase Alumno
        string? nombre;
        string apellido;
        int dni;
        DateOnly fecha_nacimiento;

        //constructor de la clase Alumno
        public Alumno()
        {
                
        }
        public Alumno(string nombre, string apellido, int dni = 0, DateOnly fecha_nacimiento = new DateOnly())
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.fecha_nacimiento = fecha_nacimiento;
            instancias_de_alumnos++;
            //incrementamos la variable estatica cada vez que se crea una instancia de la clase Alumno
        }

        //metodo para imprimir la ficha de datos del alumno
        public string ImpresionFichaDeDatos()
        {
            Console.WriteLine("");
            return $"Nombre: {nombre} {apellido}\nDNI: {dni}\nFecha de nacimiento: {fecha_nacimiento}";
        }

        public override string ToString()
        {
            return apellido + " " + nombre;
        }

       

    }
}
