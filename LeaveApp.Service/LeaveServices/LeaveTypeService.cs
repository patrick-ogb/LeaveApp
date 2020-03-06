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
    class LeaveTypeService : ILeaveTypeService
    {
        private readonly AppDbContext context;

        public LeaveTypeService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<LeaveType> AddLeaveType(LeaveType leaveType)
        {
            context.LeaveTypetbl.Add(leaveType);
            await context.SaveChangesAsync();
            return leaveType;
        }

        public async Task<LeaveType> DeleteLeaveType(int Id)
        {
            var leaveType = context.LeaveTypetbl.FirstOrDefault(levlType => levlType.Id == Id);
            context.LeaveTypetbl.Remove(leaveType);
           await context.SaveChangesAsync();
            return leaveType;
        }

        public async Task<List<LeaveType>> GetAllLeaveType()
        {
            return await context.LeaveTypetbl.ToListAsync();
        }

        public async Task<LeaveType> GetLeaveTypeById(int Id)
        {
            return await context.LeaveTypetbl.FirstOrDefaultAsync(lvType => lvType.Id == Id);
            
        }

        public async Task<LeaveType> UpdateLeaveType(LeaveType leaveChange, int Id)
        {
            context.LeaveTypetbl.Update(leaveChange);
           await context.SaveChangesAsync();
            return leaveChange;
        }
    }
}
