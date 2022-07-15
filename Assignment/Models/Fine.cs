using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class Fine
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? Fine1 { get; set; }
        public string Desc { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
