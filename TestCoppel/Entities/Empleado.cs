using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCoppel.Entities
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string NumeroEmpleado { get; set; }
        public int IdRol { get; set; }

    }
    public class Rol
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
    }
    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public decimal TotalMensualBruto { get; set; }
        public decimal TotalValesDespensa { get; set; }
        public decimal TotalISR { get; set; }
        public decimal TotalISRExtra { get; set; }
        public decimal TotalNETO { get; set; }
    }
}