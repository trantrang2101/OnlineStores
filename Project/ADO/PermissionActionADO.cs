namespace Project.ADO
{
    public class PermissionActionADO
    {
        private static PermissionActionADO instance;

        public static PermissionActionADO Instance
        {
            get
            {
                if (PermissionActionADO.instance == null)
                {
                    PermissionActionADO.instance = new PermissionActionADO();

                }
                return PermissionActionADO.instance;
            }
            private set => instance = value;
        }

        private PermissionActionADO()
        {
        }
    }
}
