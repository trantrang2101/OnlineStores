using Project.Models;
using System.Data;
using System;
using System.Collections.Generic;

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
        public static List<RestaurantUser> GetList(int id, bool? status)
        {
            string sql = $"select * from [restaurant_user] where restaurantId={id} " + (status == null ? "" : " and status=" + (status==true?1:0));
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
        public static RestaurantUser GetUser(int id,int restaurant, bool? status)
        {
            string sql = $"select * from [restaurant_user] where restaurantId={restaurant} and userId={id} " +(status == null ? "" : " and status=" + (status==true?1:0));
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
