using Project.Models;
using System.Data;
using System;
using System.Collections.Generic;

namespace Project.ADO
{
    public class ShipperADO
    {
        private static ShipperADO instance;

        public static ShipperADO Instance
        {
            get
            {
                if (ShipperADO.instance == null)
                {
                    ShipperADO.instance = new ShipperADO();

                }
                return ShipperADO.instance;
            }
            private set => instance = value;
        }

        private ShipperADO()
        {
        }
        public static List<Shipper> GetList(bool? status)
        {
            string sql = $"select * from [Shipper] " + (status == null ? "" : " where status=" + (status==true?1:0));
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                List<Shipper> list = new List<Shipper>();
                foreach (DataRow row in data.Rows)
                {
                    list.Add(new Shipper(row));
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static Shipper GetShipper(int id, bool? status)
        {
            string sql = $"select * from [Shipper] where userId={id} " + (status == null ? "" : " and status=" + (status==true?1:0));
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                return new Shipper(data.Rows[0]);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
