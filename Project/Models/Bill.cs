using System;
using System.Collections.Generic;
using System.Data;

#nullable disable

namespace Project.Models
{
    public partial class Bill
    {
        public Bill()
        {
            Feedbacks = new HashSet<Feedback>();
        }
        public Bill(bool? isTakeAway, bool? isTransfer, int status)
        {
            IsTakeAway = isTakeAway;
            IsTransfer = isTransfer;
            Status = status;
        }

        public Bill(DataRow row)
        {
            Id = int.Parse(row["Id"].ToString());
            ServeredBy = row["ServeredBy"] == null ? null : int.Parse(row["ServeredBy"].ToString());
            IsTakeAway = bool.Parse(row["IsTakeAway"].ToString());
            IsTransfer = bool.Parse(row["IsTransfer"].ToString());
            Status = int.Parse(row["Status"].ToString());
            CreatedAt = DateTime.Parse(row["CreatedAt"].ToString());
        }
        public int Id { get; set; }
        public int? ServeredBy { get; set; }
        public bool? IsTakeAway { get; set; }
        public bool? IsTransfer { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual User ServeredByNavigation { get; set; }
        public virtual BillStatus BillStatus
        {
            get
            {
                return ADO.BillStatusADO.GetBillStatus(Status, true);
            }
        }
        public virtual BillTakeAway BillTakeAway
        {
            get
            {
                if (IsTakeAway == true)
                {
                    return null;
                }
                else
                {
                    return ADO.BillTakeAwayADO.GetBill(Id);
                }
            }
        }
        public Restaurant Restaurant
        {
            get
            {
                return BillDetails[0].Product.Restaurant;
            }
        }
        public virtual List<BillDetail> BillDetails
        {
            get
            {
                return ADO.BillDetailADO.GetList(Id);
            }
        }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
