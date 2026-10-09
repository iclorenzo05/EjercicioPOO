using System;
using Core.clases;

namespace Core.clases
{
    internal class Diseñador : Empleado
    {
        public string HerramientaDiseño { get; set; }

    public void Diseñar()
        {
            Console.WriteLine("El diseñador está trabajando con " + HerramientaDiseño + ".");
        }
    }

}
