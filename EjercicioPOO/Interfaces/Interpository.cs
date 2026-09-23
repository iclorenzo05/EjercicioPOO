using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioPOO.Interfaces
{
    internal interface Interpository <T>
    {
        public void Registro( T empleado);
        public void Actualizar(T empleado);

        public void Borrar(T empleado);
    }
}
