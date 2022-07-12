using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project.ADO
{
    public class BillADO
    {
        private static BillADO instance;

        public static BillADO Instance
        {
            get
            {
                if (BillADO.instance == null)
                {
                    BillADO.instance = new BillADO();

                }
                return BillADO.instance;
            }
            private set => instance = value;
        }

        private BillADO()
        {
        }
        public static Bill Add(Bill bill)
        {
            if (bill != null)
            {
                String sql = "INSERT INTO [dbo].[Bill] ([is_takeAway],[is_transfer],[status]) VALUES("+(bill.IsTakeAway == true ? 1 : 0) +","+(bill.IsTransfer == true ? 1 : 0) +$",{bill.Status})";
                DAO.ExecuteNonQuery(sql);
                sql = "select * from bill order by id desc";
                DataTable data = DAO.GetDataBySql(sql);
                try
                {
                    Bill result = new Bill(data.Rows[0]);
                    return result;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }
        public static List<Bill> GetList(int? id,int? userId)
        {
            string sql = $"select * from [Bill] where Id in (select billId from bill_detail " + (id == null ? "" : " where productId = (select productId from product, category where category.Id=product.categoryId and restaurantId=" + id + ")") + ")" + (userId==null?"":" and id in (select billId from bill_takeAway where customer_id = "+userId+")") + " order by createdAt desc";
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                List<Bill> list = new List<Bill>();
                foreach (DataRow row in data.Rows)
                {
                    list.Add(new Bill(row));
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static Bill GetBill(int id)
        {
            string sql = $"select * from [Bill] where Id={id} ";
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                Bill result = new Bill(data.Rows[0]);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
