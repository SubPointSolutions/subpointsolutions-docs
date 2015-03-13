using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.Definitions;

namespace SPMeta2.Docs.ProvisionSamples.Definitions
{
    public static class DocSecurityGroups
    {
        #region properties

        public static SecurityGroupDefinition ClientManagers = new SecurityGroupDefinition
        {
            Name = "Client Managers"
        };

        public static SecurityGroupDefinition Interns = new SecurityGroupDefinition
        {
            Name = "Interns"
        };

        public static SecurityGroupDefinition ClientSupport = new SecurityGroupDefinition
        {
            Name = "Client Support"
        };

        public static SecurityGroupDefinition OrderApprovers = new SecurityGroupDefinition
        {
            Name = "Order Approvers"
        };

        #endregion
    }
}
