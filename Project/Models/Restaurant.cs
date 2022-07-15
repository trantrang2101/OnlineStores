using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

#nullable disable

namespace Project.Models
{
    public partial class Restaurant
    {
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
        public string Bank { get; set; }
        public string AccountNumber { get; set; }

        public Restaurant(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
            Description = row["description"].ToString();
            OwnerId = (int)row["ownerId"];
            Phone = row["phone"].ToString();
            Address = row["address"].ToString();
            Email = row["email"].ToString();
            IsActive = string.IsNullOrEmpty(row["is_Active"].ToString()) ? null : bool.Parse(row["is_Active"].ToString());
            CreatedAt = string.IsNullOrEmpty(row["Created_At"].ToString()) ? null : DateTime.Parse(row["Created_At"].ToString());
            UpdatedAt = string.IsNullOrEmpty(row["Updated_At"].ToString()) ? null : DateTime.Parse(row["Updated_At"].ToString());
            Logo = row["logo"].ToString();
            Bank = row["bank"].ToString();
            AccountNumber = row["accountNumber"].ToString();
        }

        public virtual User Owner { get; set; }
        public virtual ICollection<Product> Products(bool? value)
        {
            ICollection<Product> products = new List<Product>();
            foreach (Category category in Categories(true))
            {
                foreach (Product product in category.GetProducts(value))
                {
                    products.Add(product);
                }
            }
            return products;
        }
        public virtual ICollection<User> Users()
        {
            return ADO.RestaurantUserADO.GetList(Id).Select(x=>x.User).ToList();
        }
        public virtual Permission Permission(int UserId)
        {
            if (OwnerId == UserId)
            {
                return ADO.PermissionADO.GetPermission("owner", true);
            }
            if (ADO.RestaurantUserADO.GetUser(UserId, Id) != null)
            {
                return ADO.PermissionADO.GetPermission("waiter", true);
            }
            return null;
        }
        public virtual ICollection<Category> Categories(bool? value)
        {
            return ADO.CategoryADO.GetList(Id, value);
        }
    }
}
