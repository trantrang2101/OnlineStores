using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project.ADO
{
    public class UserADO
    {
        private static UserADO instance;

        public static UserADO Instance
        {
            get
            {
                if (UserADO.instance == null)
                {
                    UserADO.instance = new UserADO();

                }
                return UserADO.instance;
            }
            private set => instance = value;
        }

        private UserADO()
        {
        }
        public static List<User> GetList(bool? status)
        {
            string sql = $"select * from [user] " + (status == null ? "" : " where status=" + (status == true ? 1 : 0));
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                List<User> list = new List<User>();
                foreach (DataRow row in data.Rows)
                {
                    list.Add(new User(row));
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static User GetUser(int id, bool? status)
        {
            string sql = $"select * from [user] where Id={id} " + (status == null ? "" : " and status=" + (status == true ? 1 : 0));
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                User result = new User(data.Rows[0]);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static User LoginUser(string email, string password)
        {
            string sql = $"select * from [user] where email = '{email}' and is_Active=1;";
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                User result = new User(data.Rows[0]);
                if(BCrypt.Net.BCrypt.Verify(password, result.Password)) { return result; }
            }
            catch
            {

            }
            return null;
        }
    }
}
