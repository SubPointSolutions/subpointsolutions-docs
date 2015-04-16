using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Attributes;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Consts;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class SecurityRoleDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.SecurityRoleDefinition")]

        [SampleMetadata(
           Title = "Adding security roles",
           Description = "",
           Order = 800,
           CatagoryAlias = SampleCategory.SharePointFoundation,
           GroupAlias = SampleGroups.SiteCollection)]
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