using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project.ADO
{
    public class RestaurantADO
    {
        private static RestaurantADO instance;

        public static RestaurantADO Instance
        {
            get
            {
                if (RestaurantADO.instance == null)
                {
                    RestaurantADO.instance = new RestaurantADO();

                }
                return RestaurantADO.instance;
            }
            private set => instance = value;
        }

        private RestaurantADO()
        {
        }
        public static Restaurant GetRestaurant(int id, bool? status)
        {
            string sql = $"select * from [Restaurant] where Id={id} " + (status == null ? "" : " and is_active=" + (status == true ? 1 : 0));
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                return new Restaurant(data.Rows[0]);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<Restaurant> GetList(bool? status)
        {
            string sql = $"select * from [Restaurant] " + (status == null ? "" : " where is_active=" + (status == true ? 1 : 0));
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                List<Restaurant> list = new List<Restaurant>();
                foreach (DataRow row in data.Rows)
                {
                    list.Add(new Restaurant(row));
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
