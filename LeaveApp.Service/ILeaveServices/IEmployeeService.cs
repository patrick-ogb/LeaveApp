using LeaveApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveApp.Service.ILeaveServices
{
  public  interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int Id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int Id);
        Task<Employee> UpdateEmployee(Employee employeeChange, int Id);
    }
}
