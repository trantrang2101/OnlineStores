using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Models
{
    public partial class BillStatus
    {
        public BillStatus()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
