using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioPOO
{
    internal class Diseñador : Empleado
    {
        public string HerramientaDiseño {  get; set; }
        public void Diseñar()
        {
            Console.WriteLine("El diseñador esta trabajando con " + HerramientaDiseño + ".");

        }
    }
}
