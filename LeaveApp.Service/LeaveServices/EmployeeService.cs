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
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext context;

        public EmployeeService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            context.Employeetbl.Add(employee);
           await context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteEmployee(int Id)
        {
            var employee = context.Employeetbl.FirstOrDefault(emp => emp.Id == Id);
            context.Employeetbl.Remove(employee);
           await context.SaveChangesAsync();
            return employee;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await context.Employeetbl.ToListAsync() ;
        }

        public async Task<Employee> GetEmployeeById(int Id)
        {
            return await context.Employeetbl.FirstOrDefaultAsync(emp => emp.Id == Id);
            
        }

        public async Task<Employee> UpdateEmployee(Employee employeeChange, int Id)
        {
            context.Employeetbl.Update(employeeChange);
           await context.SaveChangesAsync();
            return employeeChange;
        }
    }
}
