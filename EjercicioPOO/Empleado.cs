using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioPOO
{
    internal class Empleado
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double Salario { get; set; }
        public int ID { get; set; }
        public string CodigoMatricula { get; set; }


        public void MostrarInformacion()
        {
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Edad: " + Edad);
            Console.WriteLine("Salario: $" + Salario);
            Console.WriteLine("Matrícula: " + CodigoMatricula);
        }
    }
}
