using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Models
{
    public partial class Bill
    {
        public Bill()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public int Id { get; set; }
        public int? ServeredBy { get; set; }
        public bool? IsTakeAway { get; set; }
        public bool? IsTransfer { get; set; }
        public int Status { get; set; }

        public virtual User ServeredByNavigation { get; set; }
        public virtual BillStatus StatusNavigation { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
