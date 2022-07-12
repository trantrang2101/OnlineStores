using System.Data;

#nullable disable

namespace Project.Models
{
    public partial class Action
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int FeatureId { get; set; }
        public bool? Status { get; set; }

        public Action()
        {
        }

        public Action(DataRow row)
        {
            Id = (int)row["id"];
            Title = row["title"].ToString();
            FeatureId = (int)row["featureId"];
            Status = bool.Parse(row["status"].ToString());
        }

        public virtual Feature Feature { get; set; }
    }
}
