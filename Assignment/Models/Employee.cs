using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Fines = new HashSet<Fine>();
        }

        public int EmpId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? DepartmentId { get; set; }
        public int? PositionId { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public int? Holidays { get; set; }
        public bool? IsAdmin { get; set; }
        public string Password { get; set; }

        public virtual Department Department { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<Fine> Fines { get; set; }
    }
}
