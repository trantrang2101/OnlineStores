using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public int PositionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
