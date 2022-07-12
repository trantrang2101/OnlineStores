using System.Collections.Generic;
using System.Data;

#nullable disable

namespace Project.Models
{
    public partial class Category
    {
        public Category(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
            Description = row["description"].ToString();
            Image = row["image"].ToString();
            RestaurantId = (int)row["restaurantId"];
            Status = bool.Parse(row["status"].ToString());
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int RestaurantId { get; set; }
        public bool? Status { get; set; }

        public virtual Restaurant Restaurant { get { return ADO.RestaurantADO.GetRestaurant(RestaurantId, null); } }
        public virtual ICollection<Product> GetProducts(bool? valid)
        {
            return ADO.ProductADO.GetList(Id, valid);
        }
    }
}
