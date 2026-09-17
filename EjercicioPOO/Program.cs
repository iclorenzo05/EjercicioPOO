using EjercicioPOO;
using System;
class Program
{
    static void Main(string[] args)
    {
        Programador programador = new Programador();
        programador.Nombre = "Limi";
        programador.Edad = 26;
        programador.Salario = 25000;
        programador.LenguajeProgrmacion = "C#";

        Console.WriteLine();

        programador.MostrarInformacion();
        programador.Programar();
        programador.Programar();

        Console.WriteLine();

        Diseñador diseñador = new Diseñador();

        diseñador.Nombre = "Ana";
        diseñador.Edad = 28;
        diseñador.Salario = 16000;
        diseñador.HerramientaDiseño = "Photoshop";

        Console.WriteLine();

        diseñador.MostrarInformacion();
        diseñador.Diseñar();
        diseñador.Diseñar();

        Console.ReadKey();
    }
}