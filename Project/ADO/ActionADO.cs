using Project.Models;
using System.Data;
using Project.ADO;
using System;
using System.Collections.Generic;

namespace Project.ADO
{
    public class ActionADO
    {
        private static ActionADO instance;

        public static ActionADO Instance
        {
            get
            {
                if (ActionADO.instance == null)
                {
                    ActionADO.instance = new ActionADO();

                }
                return ActionADO.instance;
            }
            private set => instance = value;
        }

        private ActionADO()
        {
        }

        public static List<Models.Action> GetList(int? permissionId,bool? status)
        {
            string sql = $"select Action.Id,Action.Title,Action.FeatureId,Action.Status from [Action],[permission_action] where Action.Id=[permission_action].actionId" +(permissionId==null?"": " and permissionId="+ permissionId) + (status == null ? "" : " and action.status=" + (status==true?1:0));
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                List<Models.Action> list = new List<Models.Action>();
                foreach (DataRow row in data.Rows)
                {
                    list.Add(new Models.Action(row));
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static Models.Action GetAction(int? id)
        {
            string sql = $"select * from [action] where Id = {id}";
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                Models.Action result = new Models.Action(data.Rows[0]);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
