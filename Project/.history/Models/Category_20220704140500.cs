using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int RestaurantId { get; set; }
        public bool? Status { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
