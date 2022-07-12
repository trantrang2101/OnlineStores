using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project.ADO
{
    public class CategoryADO
    {
        private static CategoryADO instance;

        public static CategoryADO Instance
        {
            get
            {
                if (CategoryADO.instance == null)
                {
                    CategoryADO.instance = new CategoryADO();

                }
                return CategoryADO.instance;
            }
            private set => instance = value;
        }

        private CategoryADO()
        {
        }
        public static Category GetCategory(int id, bool? status)
        {
            string sql = $"select * from [Category] where Id={id} " + (status == null ? "" : " and status=" + (status == true ? 1 : 0));
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                return new Category(data.Rows[0]);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<Category> GetList(int id, bool? status)
        {
            string sql = $"select * from [Category] where RestaurantId={id}" + (status == null ? "" : " and status=" + (status == true ? 1 : 0));
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                List<Category> list = new List<Category>();
                foreach (DataRow row in data.Rows)
                {
                    list.Add(new Category(row));
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
