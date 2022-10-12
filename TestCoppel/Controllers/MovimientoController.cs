using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestCoppel.Data;
using TestCoppel.Entities;
using TestCoppel.Models;

namespace TestCoppel.Controllers
{
    public class MovimientoController : Controller
    {
        private EmpleadosData _empleadoContext = new EmpleadosData();
        // GET: Movimiento
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> BuscarEmpleado(string numero)
        {
            var empleado = await _empleadoContext.GetEmpleadoByNumero(numero);
            var rols = _empleadoContext.GetRoles();
            var result = (from emp in empleado
                          join rol in rols on emp.IdRol equals rol.IdRol
                          select new EmpleadoModel
                          {
                              IdEmpleado = emp.IdEmpleado,
                              Nombre = emp.Nombre,
                              NumeroEmpleado = emp.NumeroEmpleado,
                              RolName = rol.Nombre.ToString()
                          }).FirstOrDefault();


            var lista = Json(result, JsonRequestBehavior.DenyGet);
            return lista;
        }
        public async Task<JsonResult> RealizarCalculo(int IdEmpleado, int Mes, int CantidadEntregas)
        {
            var result = await _empleadoContext.RealizarCalculo(IdEmpleado, Mes, CantidadEntregas);
            return Json(result,JsonRequestBehavior.DenyGet);    
        }

    }
}