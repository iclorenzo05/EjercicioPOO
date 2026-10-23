using Core.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coree
{
    internal class Log
    {
        public DateTime Fecha { get; set; }
        public Exception ex { get; set; }
        public Empleado empleado { get; set; }
        public int tipo { get; set; }
    }
}