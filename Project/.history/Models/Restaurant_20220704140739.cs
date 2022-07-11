using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Models
{
    public partial class Category
    {
        public Restaurant()
        {
            Categories = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Logo { get; set; }
        public virtual ICollection<Category> GetCategories(bool? valid)
        {
            if (valid == null)
            {
                return Categories;
            }
            else
            {
                ICollection<Category> categories = new HashSet<Category>();
                RestaurantContext context = new RestaurantContext();
                foreach(Category cate in context.Categories)
                {
                    if (cate.Status == valid)
                    {
                        categories.Add(cate);
                    }
                }
                return categories;
            }
        }
        public virtual ICollection<Product> Products(bool? valid)
        {
            List<Product> products = new List<Product>();
            foreach (Category cate in Categories)
            {
                if (valid == null)
                {
                    products.AddRange(cate.Products);
                }
                else
                {
                    foreach (Product product in cate.Products)
                    {
                        if (product.Status == valid)
                        {
                            products.Add(product);
                        }
                    }
                }
            }
            return products;
        }
        public virtual User Owner { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
