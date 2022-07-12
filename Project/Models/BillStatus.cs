using System.Collections.Generic;
using System.Data;

#nullable disable

namespace Project.Models
{
    public partial class BillStatus
    {
        public BillStatus()
        {
            Bills = new HashSet<Bill>();
        }

        public BillStatus(DataRow row)
        {
            Id = int.Parse(row["Id"].ToString());
            Name = row["Name"].ToString();
            Status = bool.Parse(row["status"].ToString());
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
