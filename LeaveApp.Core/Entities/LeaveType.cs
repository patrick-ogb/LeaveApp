using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LeaveApp.Core.Entities
{
   public class LeaveType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfDays { get; set; }
        public string Discription { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        [ForeignKey("LeaveTypeId")]
        public ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}
