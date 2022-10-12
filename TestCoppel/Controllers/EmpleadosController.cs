using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestCoppel.Data;
using TestCoppel.Entities;
using TestCoppel.Models;

namespace TestCoppel.Controllers
{
    public class EmpleadosController : Controller
    {
        public EmpleadosData _empleadosContext = new EmpleadosData();
        // GET: Empleados
        public async Task<ActionResult> Index()
        {
            List<Empleado> empleados = await _empleadosContext.Listar(0, "");
            List<Rol> roles = _empleadosContext.GetRoles();
            List<EmpleadoModel> model = (from em in empleados 
                                        join ro in roles on em.IdEmpleado equals ro.IdRol                                        
                                        select new EmpleadoModel { IdEmpleado = em.IdEmpleado,
                                                     Nombre=em.Nombre,
                                                     NumeroEmpleado = em.NumeroEmpleado,
                                                     RolName = ro.Nombre.ToString(),
                                        }).ToList();
            return View(model);
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Roles = _empleadosContext.GetRoles();
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        public async Task<ActionResult> Create(Empleado empleado)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(empleado);
                }

                var result = await _empleadosContext.Insertar(empleado);
                if (result == null)
                {
                    return View(empleado);
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var model = await _empleadosContext.GetEmpleado(id);
                ViewBag.Roles = _empleadosContext.GetRoles();
                if (model != null)  
                    return View(model);
                else
                    return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Empleado empleado)
        {
            try
            {
                var result = await _empleadosContext.Actualizar(empleado);
                if (result == null)
                {
                    return View(empleado);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var model = await _empleadosContext.GetEmpleado(id);
                if (model != null)
                    return View(model);
                else
                    return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        // POST: Empleados/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Empleado empleado)
        {
            try
            {
                _empleadosContext.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
