using LeaveApp.Core.Contexts;
using LeaveApp.Core.Entities;
using LeaveApp.Service.ILeaveServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveApp.Service.LeaveServices
{
   public class LeaveRequestService : ILeaveRequestService
    {
        private readonly AppDbContext context;

        public LeaveRequestService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<LeaveRequest> AddLeaveRequest(LeaveRequest leaveRequest)
        {
            context.LeaveRequesttbl.Add(leaveRequest);
            await context.SaveChangesAsync();
            return leaveRequest;
        }

        public async Task<LeaveRequest> DeleteLeaveRequest(int Id)
        {
            var leaveRequest = context.LeaveRequesttbl.FirstOrDefault(emp => emp.Id == Id);
            context.LeaveRequesttbl.Remove(leaveRequest);
            await context.SaveChangesAsync();
            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetAllLeaveRequest()
        {
            return await context.LeaveRequesttbl.ToListAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestById(int Id)
        {
            return await context.LeaveRequesttbl.FirstOrDefaultAsync(emp => emp.Id == Id);
           
        }

        public async Task<LeaveRequest> UpdateLeaveRequest(LeaveRequest leaveRequestChange, int Id)
        {
            context.LeaveRequesttbl.Update(leaveRequestChange);
            await context.SaveChangesAsync();
            return leaveRequestChange;
        }
    }
}
