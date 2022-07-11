using Project.Models;
using System.Data;
using Project.ADO;
using System;
using System.Collections.Generic;

namespace Project.ADO
{
    public class PermissionADO
    {
        private static PermissionADO instance;

        public static PermissionADO Instance
        {
            get
            {
                if (PermissionADO.instance == null)
                {
                    PermissionADO.instance = new PermissionADO();

                }
                return PermissionADO.instance;
            }
            private set => instance = value;
        }

        private PermissionADO()
        {
        }
        public static Permission GetPermission(string title,bool? status)
        {
            string sql = $"select * from [Permission] where Name='{title}'" + (status == null ? "" : " and status=" + (status==true?1:0));
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                return new Permission(data.Rows[0]);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Permission> GetList(bool? status)
        {
            string sql = $"select * from [Permission] " + (status == null ? "" : " where status=" + (status==true?1:0));
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                List<Permission> list = new List<Permission>();
                foreach (DataRow row in data.Rows)
                {
                    list.Add(new Permission(row));
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
