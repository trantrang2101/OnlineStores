using Project.Models;
using System.Collections.Generic;
using System.Data;

namespace Project.ADO
{
    public class ProductImageADO
    {
        private static ProductImageADO instance;

        public static ProductImageADO Instance
        {
            get
            {
                if (ProductImageADO.instance == null)
                {
                    ProductImageADO.instance = new ProductImageADO();

                }
                return ProductImageADO.instance;
            }
            private set => instance = value;
        }

        private ProductImageADO()
        {
        }
        public static List<ProductImage> GetList(int id)
        {
            string sql = $"select * from [product_image] where product={id} ";
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                List<ProductImage> list = new List<ProductImage>();
                foreach (DataRow row in data.Rows)
                {
                    list.Add(new ProductImage(row));
                }
                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}
