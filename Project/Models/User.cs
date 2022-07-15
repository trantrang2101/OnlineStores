using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

#nullable disable

namespace Project.Models
{
    public partial class User
    {
        public User()
        {
            Bills = new HashSet<Bill>();
            Restaurants = new HashSet<Restaurant>();
            Shippers = new HashSet<Shipper>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Phone { get; set; }
        public bool? Gender { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public User(DataRow row)
        {
            Id = (int)row["Id"];
            Email = row["email"].ToString();
            Password = row["password"].ToString();
            FullName = row["full_Name"].ToString();
            Birthday = String.IsNullOrEmpty(row["birthday"].ToString()) ? null : DateTime.Parse(row["birthday"].ToString());
            Phone = row["phone"].ToString();
            Gender = bool.Parse(row["gender"].ToString());
            IsAdmin = bool.Parse(row["Is_Admin"].ToString());
            IsActive = bool.Parse(row["Is_Active"].ToString());
            CreatedAt = String.IsNullOrEmpty(row["Created_At"].ToString()) ? null : DateTime.Parse(row["Created_At"].ToString());
            UpdatedAt = String.IsNullOrEmpty(row["Updated_At"].ToString()) ? null : DateTime.Parse(row["Updated_At"].ToString());
            Avatar = row["avatar"].ToString();
            Address = row["Address"].ToString();
        }

        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
        public virtual ICollection<Shipper> Shippers { get; set; }

        public virtual Permission Permission
        {
            get
            {
                if (IsAdmin == true)
                {
                    return ADO.PermissionADO.GetPermission("admin", true);
                }
                else
                {
                    foreach (Restaurant res in ADO.RestaurantADO.GetList(null))
                    {
                        if (res.OwnerId == Id)
                        {
                            return ADO.PermissionADO.GetPermission("owner", true);
                        }
                        else
                        {
                            RestaurantUser get = ADO.RestaurantUserADO.GetUser(Id, res.Id);
                            if (get != null)
                            {
                                return ADO.PermissionADO.GetPermission("waiter", true);
                            }
                        }
                    }
                    Shipper ship = ADO.ShipperADO.GetShipper(Id, true);
                    if (ship != null)
                    {
                        return ADO.PermissionADO.GetPermission("shipper", true);
                    }
                }
                return ADO.PermissionADO.GetPermission("customer", true);
            }

        }
        public List<Feature> Features()
        {
            return Permission.Features.ToList();
        }
    }
}
