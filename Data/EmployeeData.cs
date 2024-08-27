using ApiRestFull_Employees.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Globalization;

namespace ApiRestFull_Employees.Data
{
    public class EmployeeData
    {
        private readonly ApiRestDBContext _context;

        public EmployeeData(ApiRestDBContext context)
        {
            _context = context;
        }

        //Obtener lista de empleados
        public async Task<(bool Success, List<Employee> Employee, string Message)> EmployeesList()
        {
            try
            {
                var employees = await _context.Employee.FromSqlRaw("EXEC spListEmployees").ToListAsync();
                return employees.Count > 0 ? (true, employees, "success") : (false, null, "No se encuentran empleados en la lista.");
            }
            catch (Exception ex) {
                return (false, null, ex.Message);
            }
            
        }

        //Buscar empleado por id
        public async Task<(bool Success, Employee Employee, string Message)> FindEmployeeById(int id)
        {
            try
            {
                var employee = _context.Employee.FromSqlRaw("EXEC spFindEmployeeById @p0", id).AsEnumerable().FirstOrDefault();
                return employee != null ? (true, employee, "success") : (false, null, "Empleado no encontrado.");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }


        //Crear empleado
        public async Task<(bool Success, string Message)> NewEmployee(string firstName, string lastName, string email, string phoneNumber, DateTime hireDate)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC spNewEmployee @p0, @p1, @p2, @p3, @p4", firstName, lastName, email, phoneNumber, hireDate);
                return (true, "Empleado creado correctamente");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

        }

        //Actualizar datos de un empleado
        public async Task<(bool Success, string Message)> updateEmployee(int employeeId, string firstName, string lastName, string email, string phoneNumber, DateTime hireDate)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC spUpdateEmployee @p0, @p1, @p2, @p3, @p4, @p5", employeeId, firstName, lastName, email, phoneNumber, hireDate);
                return (true, "Datos actualizados correctamente");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

        }

        //Eliminar empleado
        public async Task<(bool Success, string Message)> deleteEmployee(int employeeId)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC spDeleteEmployee @p0", employeeId);
                return (true, "Empleado eliminado correactamente");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

        }

        //Obtener lista de empleados por filtro de fecha
        public async Task<(bool Success, List<Employee> Employee, string Message)> EmployeesListByDate(string hireDate)
        {
            try
            {
                DateTime parsedHireDate = DateTime.ParseExact(hireDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var employees = await _context.Employee.FromSqlRaw("EXEC spListEmployeesByDate @p0", parsedHireDate).ToListAsync();
                return employees.Count > 0 ? (true, employees, "success") : (false, null, "No se encuentran empleados en la lista.");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }

        }

    }

}
