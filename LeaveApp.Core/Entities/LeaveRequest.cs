using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeaveApp.Core.Entities
{
  public  class LeaveRequest
    {
        public int Id { get; set; }
        [Required] //FOREIGN KEY
        public int EmployeeId { get; set; }
        [Required] //FOREIGN KEY
        public int LeaveTypeId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string ApprovedBy { get; set; }
    }
}

    