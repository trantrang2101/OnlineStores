using System;
using System.Collections.Generic;
using System.Data;

#nullable disable

namespace Project.Models
{
    public partial class Shipper
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool? Status { get; set; }

        public Shipper(DataRow row)
        {
            Id = (int)row["id"];
            UserId = (int)row["userId"];
            Status = bool.Parse(row["status"].ToString());
        }

        public virtual User User { 
            get
            {
                return ADO.UserADO.GetUser(UserId, true);
            }
        }
    }
}
