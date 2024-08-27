using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRestFull_Employees.Models;
using ApiRestFull_Employees.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Globalization;

namespace ApiRestFull_Employees.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeData _employeeData;

        public EmployeeController(EmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        // Obtener empleados GET:/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee() 
        { 
            var result = await _employeeData.EmployeesList();

            return result.Success ? Ok(result.Employee) : BadRequest(result.Message);
        }

        //Obtener empleado por id GET:/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> FindEmployee(int id)
        {
            var result = await _employeeData.FindEmployeeById(id);

            return result.Success ? Ok(result.Employee) : NotFound(result.Message);
        }

        //Crear empleado POST:/Employee
        [HttpPost]
        public async Task<ActionResult> PostEmployee([FromBody] Employee employee)
        {
            var result = await _employeeData.NewEmployee(employee.FirstName,employee.LastName,employee.Email,employee.PhoneNumber, employee.HireDate);

            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        //Actualizar datos de un empleado por Id PUT: /Employee/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Employee employee)
        {
            var result = await _employeeData.updateEmployee(id, employee.FirstName, employee.LastName, employee.Email, employee.PhoneNumber, employee.HireDate);

            return result.Success ? Ok(result.Message) : BadRequest(result.Message); ;
        }

        //Eliminar datos de un empleado por Id DELETE: /Employee/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _employeeData.deleteEmployee(id);

            return result.Success ? Ok(result.Message) : BadRequest(result.Message); ;
        }


        //Obtener lista de empleados por filtro de fecha POST: /Employee/bydate
        [HttpPost("bydate")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByDate([FromBody] EmployeeRequest request)
        {
            var result = await _employeeData.EmployeesListByDate(request.HireDate);
            return result.Success ? Ok(result.Employee) : BadRequest(result.Message);
        }

    }
}
