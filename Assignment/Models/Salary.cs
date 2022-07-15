using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class Salary
    {
        public int? EmpId { get; set; }
        public int? BaseSal { get; set; }
        public int? Extra { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
