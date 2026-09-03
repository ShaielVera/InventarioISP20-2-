using Consola.Class;

public class Program
{
    private static void Main(string[] args)
    {
        //CreamosVariables();
        //CreamosMatricesYVectores();

        //Console.WriteLine("Probando imprimir algo en la pantalla");

        //ImpresionDeParametros(args);

        //CapturaDeValoresDelUsuario();
        //CreamosAlumnosEImprimimosSuFichaDeDatos();
        //CreamosEstudiantesEImprimimosSuSaludo();
        //ProbamosMetodosConDiferentesValoresDeRetorno();

        //Ejercicio1();
        //Ejercicio2();
        EjercicioFinal();
    }

    private static void EjercicioFinal()
    {
        Persona[] grupo = new Persona[2];
        Persona persona1 = new();
        Estudiante estudiante1= new();
        grupo[0]= persona1;
        grupo[1]= estudiante1;
        estudiante1.Nombre = "Alejandro";
        foreach(Persona persona in grupo)
        {
            persona.Hablar();
        }
        Console.WriteLine(Environment.NewLine+"Probando probando");
        Object prueba=new Object();
        DateTime ahora=new DateTime();
        ahora=DateTime.Now;
        Console.WriteLine(ahora);
        Console.WriteLine(estudiante1);

    }

    private static void Ejercicio2()
    {
        Bicicleta bicicleta1 = new();
        bicicleta1.velocidad = 20;
        bicicleta1.TieneCampanilla = true;
        Console.WriteLine($"La bicicleta tiene una velocidad de {bicicleta1.velocidad} y {(!bicicleta1.TieneCampanilla?"no":"")} tiene campanilla");
    }

    private static void Ejercicio1()
    {
        Persona persona1 = new();
        persona1.nombre = "Enzo Lovino";
        //persona1.edad = 20;
        Console.WriteLine($"La persona es {persona1.nombre}"/*, y su edad es {persona1.edad}"*/);
        persona1.CumplirAnios();
    }

    private static void ProbamosMetodosConDiferentesValoresDeRetorno()
    {
        AlumnoCurso alumno1 = new AlumnoCurso("Lucía", "Gómez", 19);

        alumno1.AgregarNota(8);
        alumno1.AgregarNota(7.5);
        alumno1.AgregarNota(9);
        alumno1.AgregarNota(3);
        alumno1.AgregarNota(5);

        string nombreCompleto = alumno1.ObtenerNombreCompleto();
        int cantidadNotas = alumno1.ObtenerCantidadDeNotas();
        double promedio = alumno1.CalcularPromedio();
        bool aprobado = alumno1.EstaAprobado();
        char inicial = alumno1.ObtenerInicial();
        int materiasDesaprobadas= alumno1.ContarMateriasDesaprobadas();
        DateTime fechaConsulta = alumno1.ObtenerFechaConsulta();
        List<double> notas = alumno1.ObtenerNotas();

        Console.WriteLine("Nombre completo: " + nombreCompleto);
        Console.WriteLine("Cantidad de notas: " + cantidadNotas);
        Console.WriteLine("Promedio: " + promedio);
        Console.WriteLine("¿Está aprobado?: " + aprobado);
        Console.WriteLine("Inicial: " + inicial);
        Console.WriteLine("Fecha de consulta: " + fechaConsulta);
        Console.WriteLine("Materias desaprobadas:"+ materiasDesaprobadas);
    }

    private static void CreamosEstudiantesEImprimimosSuSaludo()
    {
        Estudiante estudiante1=new Estudiante();
        estudiante1.Nombre = "Alejandro Ramirez";
        estudiante1.Edad = 49;
        estudiante1.Domicilio = "Bv. Roque Saenz Peña 2712";
        //estudiante1.Saludar();
        Console.WriteLine(estudiante1.DatosCompletos);
    }

    private static void CreamosAlumnosEImprimimosSuFichaDeDatos()
    {
        Alumno alumno = new Alumno("Tobias", "Orecchia", 12345678, new DateOnly(2000, 1, 9));
        Console.WriteLine(alumno.ImpresionFichaDeDatos());
        Alumno alumno2 = new Alumno("Enzo", "Lovino", 87654321, new DateOnly(2001, 2, 10));
        Console.WriteLine(alumno2.ImpresionFichaDeDatos());
        Alumno alumno3 = new Alumno("Aquiles", "Fuster", 11223344, new DateOnly(2002, 3, 11));
        Console.WriteLine(alumno3.ImpresionFichaDeDatos());

        Console.WriteLine(Alumno.ImprimirCantidadDeInstancias());
    }

    private static void CreamosMatricesYVectores()
    {
        //creamos un vector de tipo string con 12 elementos
        string[] meses= new string[12] {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"};
        meses[0] = "ENERO";
        meses[11]= "DICIEMBRE";
        //creamos una matriz de tipo string con 3 filas y 2 columnas
        string[,] nosotros= new string[3,2] {{"Alejandro", "Ramirez"},{"Enzo", "Lovino"},{"Aquiles", "Fuster"}};
        nosotros[0, 0] = "Tobias";
        nosotros[2, 1] = "Orecchia";
        int[] edades= new int[3] {20, 21, 22};
    }

    private static void CapturaDeValoresDelUsuario()
    {
        Console.Write("Ingrese el año de su nacimiento: ");
        string? anio_nacimiento = Console.ReadLine();
        int anio= Convert.ToInt32(anio_nacimiento);
        int edad = DateTime.Now.Year - anio;
        Console.WriteLine($"Usted tiene {edad} años aproximadamente");
    }

    private static void ImpresionDeParametros(string[] args)
    {
        if (args.Length > 1)
            Console.WriteLine($"Hola {args[0]} {args[1]}");
    }

    private static void CreamosVariables()
    {
        //declaración una variable de entera y le asignamos un valor
        int numero1 = 10;
        // Declaracion de una variable de tipo string 
        int numero2;
        // Asignamos un valor a la variable numero2
        numero2 = 20;
        int numero3 = 30;
    }
}