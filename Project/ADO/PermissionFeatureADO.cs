namespace Project.ADO
{
    public class PermissionFeatureADO
    {
        private static PermissionFeatureADO instance;

        public static PermissionFeatureADO Instance
        {
            get
            {
                if (PermissionFeatureADO.instance == null)
                {
                    PermissionFeatureADO.instance = new PermissionFeatureADO();

                }
                return PermissionFeatureADO.instance;
            }
            private set => instance = value;
        }

        private PermissionFeatureADO()
        {
        }
    }
}
