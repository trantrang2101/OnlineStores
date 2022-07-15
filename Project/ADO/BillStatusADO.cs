using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project.ADO
{
    public class BillStatusADO
    {
        private static BillStatusADO instance;

        public static BillStatusADO Instance
        {
            get
            {
                if (BillStatusADO.instance == null)
                {
                    BillStatusADO.instance = new BillStatusADO();

                }
                return BillStatusADO.instance;
            }
            private set => instance = value;
        }

        private BillStatusADO()
        {
        }
        public static BillStatus GetBillStatus(string title)
        {
            string sql = $"select * from [Bill_Status] where Name like '%{title}%'";
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                return new BillStatus(data.Rows[0]);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static BillStatus GetBillStatus(int id, bool? status)
        {
            string sql = $"select * from [Bill_Status] where Id={id} " + (status == null ? "" : " and status=" + (status == true ? 1 : 0));
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                return new BillStatus(data.Rows[0]);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<BillStatus> GetList(bool? status)
        {
            string sql = $"select * from [Bill_Status]" + (status == null ? "" : " where status=" + (status == true ? 1 : 0));
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                List<BillStatus> list = new List<BillStatus>();
                foreach (DataRow row in data.Rows)
                {
                    list.Add(new BillStatus(row));
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
