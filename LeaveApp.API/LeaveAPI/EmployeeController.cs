using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveApp.Core.Entities;
using LeaveApp.Service.ILeaveServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveApp.API.LeaveAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await employeeService.GetAllEmployees();
                if (employees == null)
                {
                    return NotFound();
                }
                return Ok(employees);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var emp = await employeeService.GetEmployeeById(id);
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] Employee employee)
        {
            try
            {
                var emp = await employeeService.AddEmployee(employee);
                if (emp.Id > 0)
                {
                    return Ok(emp);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, [FromBody] Employee employee)
        {
            try
            {
                var emplo = await employeeService.UpdateEmployee(employee, id);
                if (emplo.Id > 0)
                {
                    return Ok(emplo);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpoyee(int id)
        {
            try
            {
                if (id != 0)
                {
                    var emp = await employeeService.DeleteEmployee(id);
                    return Ok(emp);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}