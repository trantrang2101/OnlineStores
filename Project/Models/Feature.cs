using System.Collections.Generic;
using System.Data;

#nullable disable

namespace Project.Models
{
    public partial class Feature
    {
        public Feature()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public bool? Status { get; set; }

        public Feature(DataRow row)
        {
            Id = (int)row["id"];
            Title = row["title"].ToString();
            Icon = row["icon"].ToString();
            Status = bool.Parse(row["status"].ToString());
        }

    }
}
