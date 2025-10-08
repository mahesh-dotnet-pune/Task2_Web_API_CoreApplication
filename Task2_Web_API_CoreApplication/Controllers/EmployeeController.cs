using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task2_Web_API_CoreApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace Task2_Web_API_CoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>();
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(employees);
        }

        [HttpGet("GetEmployeeByID/{id}")]
        public IActionResult GetEmployeeByID(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet("GetEmployeeByDepartment/{department}")]
        public IActionResult GetEmployeeByDepartment(string department)
        {
            var deptEmployees = employees.Where(e => e.Department.Equals(department, System.StringComparison.OrdinalIgnoreCase)).ToList();
            if (!deptEmployees.Any())
            {
                return NotFound();
            }
            return Ok(deptEmployees);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();
            employees.Add(employee);
            return CreatedAtAction(nameof(GetEmployeeByID), new { id = employee.Id }, employee);
        }

        [HttpPut("UpdateEmployeeByID/{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();
            employee.Name = updatedEmployee.Name;
            employee.Department = updatedEmployee.Department;
            employee.MobileNo = updatedEmployee.MobileNo;
            employee.Email = updatedEmployee.Email;
            return NoContent();
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();
            employees.Remove(employee);
            return NoContent();
        }

        
        [HttpPatch("UpdateEmail/{id}")]
        public IActionResult UpdateEmployeeEmail(int id, [FromBody] string email)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();
            employee.Email = email;
            return NoContent();
        }
    }
}
