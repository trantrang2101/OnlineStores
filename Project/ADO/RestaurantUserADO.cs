using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project.ADO
{
    public class RestaurantUserADO
    {
        private static RestaurantUserADO instance;

        public static RestaurantUserADO Instance
        {
            get
            {
                if (RestaurantUserADO.instance == null)
                {
                    RestaurantUserADO.instance = new RestaurantUserADO();

                }
                return RestaurantUserADO.instance;
            }
            private set => instance = value;
        }

        private RestaurantUserADO()
        {
        }
        public static List<RestaurantUser> GetList(int id)
        {
            string sql = $"select * from [restaurant_user] where restaurantId={id} ";
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                List<RestaurantUser> list = new List<RestaurantUser>();
                foreach (DataRow row in data.Rows)
                {
                    list.Add(new RestaurantUser(row));
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static RestaurantUser GetUser(int id, int restaurant)
        {
            string sql = $"select * from [restaurant_user] where restaurantId={restaurant} and userId={id} ";
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                return new RestaurantUser(data.Rows[0]);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
