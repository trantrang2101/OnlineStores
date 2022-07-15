using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class StaffTask
    {
        public int? Id { get; set; }
        public int? EmpId { get; set; }
        public bool? Seen { get; set; }
        public int? Mark { get; set; }

        public virtual Employee Emp { get; set; }
        public virtual TaskInfo IdNavigation { get; set; }
    }
}
