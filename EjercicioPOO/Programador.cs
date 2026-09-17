using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioPOO
{
    internal class Programador : Empleado
    {
        public string LenguajeProgrmacion {  get; set; }
        public void Programar()
        {
            Console.WriteLine("El programador esta programando en " + LenguajeProgrmacion + ".");


        }
    }
}
