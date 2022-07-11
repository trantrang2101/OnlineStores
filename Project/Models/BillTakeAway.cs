using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Models
{
    public partial class BillTakeAway
    {
        public int BillId { get; set; }
        public int? CustomerId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? ShipperId { get; set; }

        public virtual Bill Bill { get; set; }
        public virtual User Customer { get; set; }
        public virtual Shipper Shipper { get; set; }
    }
}
