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
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext context;

        public DepartmentService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Department> AddDepartment(Department department)
        {
            context.Departmentbl.Add(department);
           await context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> DeleteDepartment(int Id)
        {
            var department = context.Departmentbl.FirstOrDefault(dept => dept.Id == Id);
            context.Departmentbl.Remove(department);
            await context.SaveChangesAsync();
            return department;
        }

        public async Task<List<Department>> GetAllDepartment()
        {
            return await context.Departmentbl.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int Id)
        {
            return await context.Departmentbl.FirstOrDefaultAsync(dept => dept.Id == Id);
            
        }

        public async Task<Department> UpdateDepartment(Department departmentChange, int Id)
        {
            context.Departmentbl.Update(departmentChange);
            await context.SaveChangesAsync();
            return departmentChange;
        }
    }
}
