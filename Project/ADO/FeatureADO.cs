using Project.Models;
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
        public static Feature GetFeature(Models.Action action)
        {
            string sql = $"select distinct Feature.Id,Feature.title,Feature.icon,Feature.status from Feature, action where action.Id={action.Id} and action.featureId=feature.Id";

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
