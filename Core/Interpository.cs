using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface Interpository<T>
    {
        void Registro(T empleado);
        void Actualizar(T empleado);
        void Borrar(T empleado);
        List<T> Lista();
        List<T> Buscar(string nombre);

    }
}