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

        public static int ChangeRestaurantStatus(int id,bool? status) {
            string sql = $"UPDATE [dbo].[restaurant] SET [is_active] = {status} WHERE id = {id}";

            return DAO.ExecuteNonQuery(sql);
        }

        public static int UpdateRestaurant(Restaurant restaurant) {
            String sql = $"UPDATE [dbo].[restaurant]" +
     $"   SET [name] = '{restaurant.Name}' " +
     $"      ,[description] = '{restaurant.Description}'" +
     $"      ,[ownerId] = {restaurant.Id}" +
     $"      ,[phone] = '{restaurant.Phone}'" +
     $"      ,[address] = '{restaurant.Address}'" +
     $"      ,[email] = '{restaurant.Email}'" +
     $"      ,[is_active] = {restaurant.IsActive}" +
     $"      ,[updated_at] = GETDATE() " +
     $"      ,[logo] = {restaurant.Logo}" +
     $"      ,[bank] = {restaurant.Bank}" +
     $"      ,[accountNumber] ={restaurant.AccountNumber}" +
     $" WHERE id = {restaurant.Id}";
            return DAO.ExecuteNonQuery(sql);
        }

        public static int AddRestaurant(Restaurant restaurant) {
            String sql = $"INSERT INTO [dbo].[restaurant]" +
                $"([name],[description],[ownerId],[phone],[address],[email]," +
                $"[is_active],[created_at],[logo],[bank],[accountNumber])" +
                $"VALUES('{restaurant.Name}','{restaurant.Description}',{restaurant.Id},'{restaurant.Phone}'," +
                $" '{restaurant.Address}','{restaurant.Email}',{restaurant.IsActive},GETDATE(),'{restaurant.Logo}'" +
                $"'{restaurant.Bank}','{restaurant.AccountNumber}')";
            return DAO.ExecuteNonQuery(sql);
        }
    }
}
