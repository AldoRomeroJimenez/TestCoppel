using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DBConnect;
using TestCoppel.Entities;

namespace TestCoppel.Data
{
    public class EmpleadosData
    {
        public async Task<List<Empleado>> Listar(int? Id,string Nombre)
        {
            try
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@IdEmpleado", Id);
                parametros.Add("@Nombre", Nombre);
                var table = await Connection.ReadTableAsync("SP_ListarEmpleados", parametros, "Mks");
                return await table.ToListAsync<Empleado>();
            }
            catch (Exception)
            {                
                throw;
            }
        }
        public async Task<List<Empleado>> GetEmpleadoByNumero(string Numero)
        {
            try
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@NumeroEmpleado", Numero);
                var table = await Connection.ReadTableAsync("SP_ListarEmpleadosByNumero", parametros, "Mks");
                return (await table.ToListAsync<Empleado>());
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<Empleado> GetEmpleado(int Id)
        {
            try
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@IdEmpleado", Id);
                var table = await Connection.ReadTableAsync("SP_ListarEmpleadosByID", parametros, "Mks");
                return (await table.ToListAsync<Empleado>()).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<Empleado>Insertar(Empleado empleado)
        {
            try
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@Nombre", empleado.Nombre);
                parametros.Add("@NumeroEmpleado", empleado.NumeroEmpleado);
                parametros.Add("@IdRol", empleado.IdRol);
                var result = await Connection.ReadTableAsync("SP_InsertarEmpleado", parametros, "Mks");
                return (result.ToList<Empleado>()).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Empleado> Actualizar(Empleado empleado)
        {
            try
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@IdEmpleado", empleado.IdEmpleado);
                parametros.Add("@Nombre", empleado.Nombre);
                parametros.Add("@NumeroEmpleado", empleado.NumeroEmpleado);
                parametros.Add("@IdRol", empleado.IdRol);
                var result = await Connection.ReadTableAsync("SP_ActualizarEmpleado", parametros, "Mks");
                return (result.ToList<Empleado>()).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Eliminar(int IdEmpleado)
        {
            try
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@IdEmpleado", IdEmpleado);
                Connection.ExecuteNonQuery("SP_EliminarEmpleado", parametros, "Mks");
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public List<Rol> GetRoles()
        {
            List<Rol> roles = new List<Rol>();
            roles.Add(new Rol {IdRol=1,Nombre="Chofer"});
            roles.Add(new Rol {IdRol=2,Nombre="Cargador"});
            roles.Add(new Rol {IdRol=3,Nombre="Auxiliar"});
            return roles;
        }
        public async Task<Movimiento>RealizarCalculo(int IdEmpleado,int Mes,int CantidadEntregas)
        {
            try
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@IdEmpleado", IdEmpleado);
                parametros.Add("@Mes", Mes);
                parametros.Add("@CantidadEntregas", CantidadEntregas);
                var result = await Connection.ReadTableAsync("CalcularEmpleadoMovmientoMes", parametros, "Mks");
                return (result.ToList<Movimiento>()).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}