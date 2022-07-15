using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

#nullable disable

namespace Project.Models
{
    public partial class RestaurantUser
    {
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        public RestaurantUser(DataRow row)
        {
            RestaurantId = (int)row["restaurantId"];
            UserId = (int)row["userId"];
            PermissionId = (int)row["permissionId"];
        }

        [ForeignKey("PermissionId")]
        public virtual Permission Permission { get; set; }
        [ForeignKey("RestaurantId")]
        public virtual Restaurant Restaurant { get; set; }
        [ForeignKey("UserId")]
        public virtual User User
        {
            get
            {
                return ADO.UserADO.GetUser(UserId, null);
            }
        }
    }
}
