using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class EmployeeStatus
    {
        public int? EmpId { get; set; }
        public int? Attendance { get; set; }
        public DateTime? LastAttend { get; set; }
        public int? Strikes { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
