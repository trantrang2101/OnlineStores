using System.Data;

#nullable disable

namespace Project.Models
{
    public partial class BillDetail
    {
        public BillDetail(DataRow row)
        {
            BillId = int.Parse(row["BillId"].ToString());
            ProductId = int.Parse(row["ProductId"].ToString());
            Quantity = int.Parse(row["Quantity"].ToString());
            Price = double.Parse(row["Price"].ToString());
        }

        public BillDetail(int billId, int productId, int quantity, double price)
        {
            BillId = billId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public int BillId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public virtual Bill Bill
        {
            get
            {
                return ADO.BillADO.GetBill(BillId);
            }
        }
        public virtual Product Product
        {
            get
            {
                return ADO.ProductADO.GetProduct(ProductId, null);
            }
        }
    }
}
