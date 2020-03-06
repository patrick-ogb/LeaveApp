using System;
using System.Threading.Tasks;
using LeaveApp.Core.Entities;
using LeaveApp.Service.ILeaveServices;
using Microsoft.AspNetCore.Mvc;

namespace LeaveApp.API.LeaveAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : Controller
    {
        private readonly ILeaveTypeService leaveTypeService;

        public LeaveTypeController(ILeaveTypeService leaveTypeService)
        {
            this.leaveTypeService = leaveTypeService;
        }
        // GET: api/LeaveType
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetLeaveTypes()
        {
            try
            {
                var leaveTypes = await leaveTypeService.GetAllLeaveType();
                if (leaveTypes == null)
                {
                    return NotFound();
                }
                return Ok(leaveTypes);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        // GET: api/LeaveType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeaveType(int id)
        {
            try
            {
                var leaveType = await leaveTypeService.GetLeaveTypeById(id);
                if (leaveType == null)
                {
                    return NotFound();
                }
                return Ok(leaveType);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        // POST: api/LeaveType
        [HttpPost]
        public async Task<IActionResult> PostLeaveType([FromBody] LeaveType leaveType)
        {
            try
            {
                var lvlType = await leaveTypeService.AddLeaveType(leaveType);
                if (lvlType.Id > 0)
                {
                    return Ok(lvlType);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        // PUT: api/LeaveType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveType(int id, [FromBody] LeaveType leaveType)
        {
            try
            {
                var lvlType = await leaveTypeService.UpdateLeaveType(leaveType, id);
                if (lvlType.Id > 0)
                {
                    return Ok(lvlType);
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
        public async Task<IActionResult> DeleteLeaveType(int id)
        {
            try
            {
                if (id != 0)
                {
                    var leaveType = await leaveTypeService.DeleteLeaveType(id);
                    return Ok(leaveType);
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