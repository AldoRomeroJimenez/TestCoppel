using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCoppel.Models
{
    public class EmpleadoModel
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string NumeroEmpleado { get; set; }
        public string RolName { get; set; }
    }
    public class MovimientoModel
    {
        public int Id { get; set; }
        public string IdEmpleado { get; set; }
        public string Fecha { get; set; }
        public int CantidadEntrega { get; set; }
    }
}