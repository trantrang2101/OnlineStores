using System.Data;

#nullable disable

namespace Project.Models
{
    public partial class BillTakeAway
    {
        public int BillId { get; set; }
        public int? CustomerId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? ShipperId { get; set; }
        public BillTakeAway(DataRow row)
        {
            BillId = int.Parse(row["BillId"].ToString());
            CustomerId = int.Parse(row["customerId"].ToString());
            FullName = row["FullName"].ToString();
            Address = row["Address"].ToString();
            Phone = row["Phone"].ToString();
            ShipperId = int.Parse(row["ShipperId"].ToString());
        }
        public BillTakeAway(int bill, int? customerId, string fullName, string address, string phone)
        {
            BillId = bill;
            CustomerId = customerId;
            FullName = fullName;
            Address = address;
            Phone = phone;
        }
        public virtual Bill Bill { get; set; }
        public virtual User Customer { get; set; }
        public virtual Shipper Shipper { get; set; }
    }
}
