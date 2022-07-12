using System;
using System.Collections.Generic;
using System.Data;

#nullable disable

namespace Project.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Status { get; set; }

        public Product(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
            Description = row["Description"].ToString();
            Price = double.Parse(row["price"].ToString());
            CategoryId = (int)row["categoryId"];
            CreatedAt = String.IsNullOrEmpty(row["Created_At"].ToString()) ? null : DateTime.Parse(row["Created_At"].ToString());
            UpdatedAt = String.IsNullOrEmpty(row["Updated_At"].ToString()) ? null : DateTime.Parse(row["Updated_At"].ToString());
            Status = bool.Parse(row["status"].ToString());
        }

        public virtual int RestaurantId { get { return Category.RestaurantId; } }
        public virtual Restaurant Restaurant { get { return Category.Restaurant; } }
        public virtual Category Category
        {
            get
            {
                return ADO.CategoryADO.GetCategory(CategoryId, null);
            }
        }
        public virtual List<ProductImage> ProductImages
        {
            get
            {
                return ADO.ProductImageADO.GetList(Id);
            }
        }
    }
}
