using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;
using SubPointSolutions.Docs.Code.Enumerations;
using SubPointSolutions.Docs.Code.Metadata;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]

    

   [Category("Category=Site Collection Model/Security")]
    //[Browsable(false)]
    public class SecurityRoleDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.SecurityRoleDefinition")]

        [DisplayName("Add security role")]
        //[Browsable(false)]

        public void CanDeploySimpleSecurityRoleDefinition()
        {
            var customerEditors = new SecurityRoleDefinition
            {
                Name = "Customer editors",
                BasePermissions = new Collection<string>
                {
                    BuiltInBasePermissions.EditListItems,
                    BuiltInBasePermissions.UseClientIntegration
                }
            };

            var customerApprovers = new SecurityRoleDefinition
            {
                Name = "Customer approvers",
                BasePermissions = new Collection<string>
                {
                    BuiltInBasePermissions.EditListItems,
                    BuiltInBasePermissions.DeleteListItems,
                    BuiltInBasePermissions.UseClientIntegration
                }
            };

            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddSecurityRole(customerEditors)
                    .AddSecurityRole(customerApprovers);
            });

            DeployModel(model);
        }

        #endregion
    }
}