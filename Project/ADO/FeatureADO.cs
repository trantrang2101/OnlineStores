using Project.Models;
using System.Collections.Generic;
using System.Data;

namespace Project.ADO
{
    public class FeatureADO
    {
        private static FeatureADO instance;

        public static FeatureADO Instance
        {
            get
            {
                if (FeatureADO.instance == null)
                {
                    FeatureADO.instance = new FeatureADO();

                }
                return FeatureADO.instance;
            }
            private set => instance = value;
        }

        private FeatureADO()
        {
        }
        public static List<Feature> GetList(int? permissionId)
        {
            string sql = $"select * from [Feature],permission_feature where Feature.Id=[permission_feature].FeatureId "+(permissionId==null?"":" and permissionId="+permissionId);
            DataTable data = DAO.GetDataBySql(sql);
            try
            {
                List<Feature> list = new List<Feature>();
                foreach (DataRow row in data.Rows)
                {
                    list.Add(new Feature(row));
                }
                return list;
            }
            catch
            {
                return null;
            }
        }
        public static Feature GetFeature(int id)
        {
            string sql = $"select * from Feature where Id={id}";

            DataTable data = DAO.GetDataBySql(sql);
            if (data != null)
            {
                return new Feature(data.Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}
