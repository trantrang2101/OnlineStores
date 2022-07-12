using System.Data;

#nullable disable

namespace Project.Models
{
    public partial class ProductImage
    {
        public ProductImage(DataRow dataRow)
        {
            ProductId = int.Parse(dataRow["ProductId"].ToString());
            Image = dataRow["image"].ToString();
        }

        public int ProductId { get; set; }
        public string Image { get; set; }
        public virtual Product Product { get; set; }
    }
}
