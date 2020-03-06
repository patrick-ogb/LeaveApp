using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LeaveApp.Core.Entities
{
   public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required] //FOREIGN KEY
        public Int32 DepartmentId { get; set; }
        [Required] //FOREIGN KEY
        public int LevelId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        [ForeignKey("EmployeeId")]
        public ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}
