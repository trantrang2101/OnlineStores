#nullable disable

namespace Project.Models
{
    public partial class PermissionFeature
    {
        public int Id { get; set; }
        public int PermissionId { get; set; }
        public int FeatureId { get; set; }
        public bool? Status { get; set; }

        public virtual Feature GetFeature()
        {
            return ADO.FeatureADO.GetFeature(FeatureId);
        }

        public virtual Permission Permission()
        {
            return ADO.PermissionADO.GetPermission(PermissionId);
        }
    }
}
