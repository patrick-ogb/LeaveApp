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
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        // GET: api/Department
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                var departments = await departmentService.GetAllDepartment();
                if (departments == null)
                {
                    return NotFound();
                }
                return Ok(departments);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            try
            {
                var department = await departmentService.GetDepartmentById(id);
                if (department == null)
                {
                    return NotFound();
                }
                return Ok(department);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // POST: api/Department
        [HttpPost]
        public async Task<IActionResult> PostDepartment([FromBody] Department department)
        {
            try
            {
                var dept = await departmentService.AddDepartment(department);
                if (dept.Id > 0)
                {
                    return Ok(dept);
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
        public async Task<IActionResult> PutDepartment(int id, [FromBody] Department department)
        {
            try
            {
                var dept = await departmentService.UpdateDepartment(department, id);
                if (dept.Id > 0)
                {
                    return Ok(dept);
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
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                if (id != 0)
                {
                    var dept = await departmentService.DeleteDepartment(id);
                    return Ok(dept);
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