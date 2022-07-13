using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project.ADO
{
    public class BillDetailADO
    {
        private static BillDetailADO instance;

        public static BillDetailADO Instance
        {
            get
            {
                if (BillDetailADO.instance == null)
                {
                    BillDetailADO.instance = new BillDetailADO();

                }
                return BillDetailADO.instance;
            }
            private set => instance = value;
        }

        private BillDetailADO()
        {
        }
        public static void Add(BillDetail bill)
        {
            if (bill != null)
            {
                String sql = $"INSERT INTO [dbo].[bill_detail] ([billId],[productId],[quantity],[price]) VALUES({bill.BillId},{bill.ProductId},{bill.Quantity},{bill.Price})";
                DAO.ExecuteNonQuery(sql);
            }
        }
        public static List<BillDetail> GetList(int? id)
        {
            string sql = $"select * from [bill_detail]" + (id == null ? "" : " where billId=" + id);
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                List<BillDetail> list = new List<BillDetail>();
                foreach (DataRow row in data.Rows)
                {
                    list.Add(new BillDetail(row));
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
