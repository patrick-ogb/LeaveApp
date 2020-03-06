using LeaveApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveApp.Service.ILeaveServices
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveType>> GetAllLeaveType();
        Task<LeaveType> GetLeaveTypeById(int Id);
        Task<LeaveType> AddLeaveType(LeaveType leaveType);
        Task<LeaveType> DeleteLeaveType(int Id);
        Task<LeaveType> UpdateLeaveType(LeaveType leaveChange, int Id);
    }
}
