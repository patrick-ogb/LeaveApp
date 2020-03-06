using LeaveApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApp.Core.Contexts
{
  public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> Employeetbl { get; set; }
        public DbSet<Department> Departmentbl { get; set; }
        public DbSet<Level> Leveltbl { get; set; }
        public DbSet<LeaveRequest> LeaveRequesttbl { get; set; }
        public DbSet<LeaveType> LeaveTypetbl { get; set; }
    }
}
