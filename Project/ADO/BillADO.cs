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
        public static void UpdateServedBy(int id, int userId)
        {
            String sql = $"Update bill set servered_by={userId} where id = {id}";
            DAO.ExecuteNonQuery(sql);
        }
        public static void UpdateStatus(int id,int status)
        {
            String sql = $"Update bill set status={status} where id = {id}";
            DAO.ExecuteNonQuery(sql);
        }
        public static List<Bill> GetListShip(int? shipperId)
        {
            string sql = $"select * from [Bill] where (is_TakeAway=0 and servered_by is not null and Id in (select billId from bill_takeAway where shipperId={shipperId} or shipperId is null ))" + " order by createdAt desc";
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
        public static List<Bill> GetList(int? userId)
        {
            string sql = $"select * from [Bill] {(userId!=null?" where Id in (select BillId from bill_takeaway where customerId="+userId+")":"")} order by createdAt desc";
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
        public static List<Bill> GetListRestaurant(int? userId)
        {
            string sql = $"select * from [Bill] where Id in (select billId from bill_detail where productId in (select product.Id from product, category where category.Id=product.categoryId and restaurantId in (select Id from restaurant where ownerId = " + userId + " or Id in( select restaurantId from restaurant_user,restaurant where restaurantId=Id" + (userId == null ? "" : " and (userId = " + userId + ")))") + "))" + " order by createdAt desc";
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
