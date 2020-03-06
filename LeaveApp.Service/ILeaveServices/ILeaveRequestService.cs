using LeaveApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveApp.Service.ILeaveServices
{
   public interface ILeaveRequestService
    {
        Task<List<LeaveRequest>> GetAllLeaveRequest();
        Task<LeaveRequest> GetLeaveRequestById(int Id);
        Task<LeaveRequest> AddLeaveRequest(LeaveRequest level);
        Task<LeaveRequest> DeleteLeaveRequest(int Id);
        Task<LeaveRequest> UpdateLeaveRequest(LeaveRequest leaveRequestChange, int Id);
    }
}
