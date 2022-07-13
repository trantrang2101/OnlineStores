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
            try
            {
                ServeredBy = int.Parse(row["servered_by"].ToString());
            }
            catch
            {
                ServeredBy = null;
            }
            IsTakeAway = bool.Parse(row["is_takeAway"].ToString());
            IsTransfer = bool.Parse(row["is_transfer"].ToString());
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
        public virtual BillStatus BillStatus()
        {
            return ADO.BillStatusADO.GetBillStatus(Status, true);
        }
        public virtual BillTakeAway BillTakeAway()
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
        public Restaurant Restaurant()
        {
            try
            {
                return BillDetails()[0].Product.Restaurant;
            }
            catch
            {
                return null;
            }
        }
        public virtual List<BillDetail> BillDetails()
        {
            return ADO.BillDetailADO.GetList(Id);
        }
    }
}
