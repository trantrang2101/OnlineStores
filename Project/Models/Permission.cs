using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

#nullable disable

namespace Project.Models
{
    public partial class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }

        public Permission(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
            Status = bool.Parse(row["status"].ToString());
        }

        public virtual ICollection<Feature> Features
        {
            get
            {
                return ADO.FeatureADO.GetList(Id);
            }
        }
    }
}
