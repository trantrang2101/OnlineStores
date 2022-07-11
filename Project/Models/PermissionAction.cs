using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace Project.Models
{
    public partial class PermissionAction
    {
        public int Id { get; set; }
        public int? PermissionId { get; set; }
        public int? ActionId { get; set; }
        public bool? Status { get; set; }

        public virtual Action Action { get; set; }
        public virtual Action GetAction()
        {
            if (Action == null)
                return ADO.ActionADO.GetAction(ActionId);
            else
                return Action;
        }

        public virtual Permission Permission { get; set; }
    }
}
