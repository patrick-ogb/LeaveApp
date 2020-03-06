using LeaveApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveApp.Service.ILeaveServices
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartment();
        Task<Department> GetDepartmentById(int Id);
        Task<Department> AddDepartment(Department department);
        Task<Department> DeleteDepartment(int Id);
        Task<Department> UpdateDepartment(Department departmentChange, int Id);
    }
}
