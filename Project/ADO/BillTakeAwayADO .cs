using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project.ADO
{
    public class BillTakeAwayADO
    {
        private static BillTakeAwayADO instance;

        public static BillTakeAwayADO Instance
        {
            get
            {
                if (BillTakeAwayADO.instance == null)
                {
                    BillTakeAwayADO.instance = new BillTakeAwayADO();

                }
                return BillTakeAwayADO.instance;
            }
            private set => instance = value;
        }

        private BillTakeAwayADO()
        {
        }
        public static void UpdateShipper(int id, int userId)
        {
            String sql = $"Update bill_takeAway set shipperId={userId} where billId = {id}";
            DAO.ExecuteNonQuery(sql);
        }
        public static void Add(BillTakeAway bill)
        {
            if (bill != null)
            {
                String sql = $"INSERT INTO [dbo].[bill_takeAway] ([billId],[customerId],[fullName],[address],[phone]) VALUES({bill.BillId},{(bill.CustomerId==null?"null": bill.CustomerId)},N'{bill.FullName}',N'{bill.Address}','{bill.Phone}')";
                DAO.ExecuteNonQuery(sql);
            }
        }
        public static List<BillTakeAway> GetList(int? id)
        {
            string sql = $"select * from [bill_takeAway] where billId in (select billId from bill_detail " + (id == null ? "" : " where productId = (select productId from product, category where category.Id=product.categoryId and restaurantId=" + id + ")") + ")";
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                List<BillTakeAway> list = new List<BillTakeAway>();
                foreach (DataRow row in data.Rows)
                {
                    list.Add(new BillTakeAway(row));
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static BillTakeAway GetBill(int id)
        {
            string sql = $"select * from [bill_takeAway] where billId={id} ";
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                return new BillTakeAway(data.Rows[0]);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
