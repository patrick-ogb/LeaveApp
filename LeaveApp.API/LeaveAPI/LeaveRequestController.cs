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
    public class LeaveRequestController : Controller
    {
        private readonly ILeaveRequestService leaveRequestService;

        public LeaveRequestController(ILeaveRequestService leaveRequestService)
        {
            this.leaveRequestService = leaveRequestService;
        }
        // GET: api/LeaveRequest
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetLeaveRequests()
        {
            try
            {
                var leaveRequests = await leaveRequestService.GetAllLeaveRequest();
                if (leaveRequests == null)
                {
                    return NotFound();
                }
                return Ok(leaveRequests);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        // GET: api/LeaveRequest/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeaveRequest(int id)
        {
            try
            {
                var leaveRequest = await leaveRequestService.GetLeaveRequestById(id);
                if (leaveRequest == null)
                {
                    return NotFound();
                }
                return Ok(leaveRequest);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        // POST: api/LeaveRequest
        [HttpPost]
        public async Task<IActionResult> PostLeaveRequest([FromBody] LeaveRequest leaveRequest)
        {
            try
            {
                var request = await leaveRequestService.AddLeaveRequest(leaveRequest);
                if (request.Id > 0)
                {
                    return Ok(request);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        // PUT: api/LeaveRequest/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveRequest(int id, [FromBody] LeaveRequest leaveRequest)
        {
            try
            {
                var request = await leaveRequestService.UpdateLeaveRequest(leaveRequest, id);
                if (request.Id > 0)
                {
                    return Ok(request);
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
        public async Task<IActionResult> DeleteLeaveRequest(int id)
        {
            try
            {
                if (id != 0)
                {
                    var leaveRequest = await leaveRequestService.DeleteLeaveRequest(id);
                    return Ok(leaveRequest);
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