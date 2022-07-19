using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project.ADO
{
    public class ProductADO
    {
        private static ProductADO instance;

        public static ProductADO Instance
        {
            get
            {
                if (ProductADO.instance == null)
                {
                    ProductADO.instance = new ProductADO();

                }
                return ProductADO.instance;
            }
            private set => instance = value;
        }

        private ProductADO()
        {
        }
        public static Product GetProduct(int id, bool? status)
        {
            string and = status == null ? "" : " and status = " + (status == true ? 1 : 0);
            string sql = $"select * from [Product] where id={id} {and};";
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                Product result = new Product(data.Rows[0]);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<Product> GetList(int id, bool? status)
        {
            string and = status == null ? "" : " and status = " + (status == true ? 1 : 0);
            string sql = $"select * from [Product] where categoryId={id} {and};";
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                List<Product> result = new List<Product>();
                foreach (DataRow row in data.Rows)
                {
                    result.Add(new Product(row));
                }
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int ChangeProductStatus(int id,bool? status) {
            string sql = $"UPDATE [dbo].[product] SET [status] = {status} WHERE id = {id}";

            return DAO.ExecuteNonQuery(sql);
        }

        public static int UpdateProduct(Product product) {
            String sql = $"UPDATE [dbo].[product]" +
     $"   SET [name] = '{product.Name}' " +
     $"      ,[description] = '{product.Description}'" +
     $"      ,[price] = {product.Price}" +
     $"      ,[updated_at] = GETDATE()" +
     $"      ,[categoryId] = {product.CategoryId}" +
     $"      ,[status] ={product.Status}" +
     $" WHERE id = {product.Id}";
            return DAO.ExecuteNonQuery(sql);
        }

        public static int AddProduct(Product product) {
            String sql = $"INSERT INTO [dbo].[product]" +
                $"([name],[description],[price],[categoryId]," +
                $"[created_at],[status])" +
                $"VALUES('{product.Name}','{product.Description}',{product.Price},'{product.CategoryId}'," +
                $"GETDATE(),'{product.Status}')";
            return DAO.ExecuteNonQuery(sql);
        }
    }
}
