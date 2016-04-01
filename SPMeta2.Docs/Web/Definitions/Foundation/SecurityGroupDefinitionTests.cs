using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Attributes;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Consts;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class SecurityGroupDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
          Title = "Adding security group",
          Description = "",
          Order = 700,
          CatagoryAlias = SampleCategory.SharePointFoundation,
          GroupAlias = SampleGroups.SiteCollection)]

        [TestMethod]
        [TestCategory("Docs.SecurityGroupDefinition")]
        public void CanDeploySimpleSecurityGroup()
        {
            var auditors = new SecurityGroupDefinition
            {
                Name = "External Auditors",
                Description = "External auditors group."
            };

            var reviewers = new SecurityGroupDefinition
            {
                Name = "External Reviewers",
                Description = "External reviewers group."
            };

            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddSecurityGroup(auditors)
                    .AddSecurityGroup(reviewers);
            });

            DeployModel(model);
        }

        [SampleMetadata(
            Title = "Adding multiple security groups",
            Description = "",
            Order = 700,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.SiteCollection)]

        [TestMethod]
        [TestCategory("Docs.SecurityGroupDefinition")]
        public void CanDeploySimpleSecurityGroups()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddSecurityGroup(DocSecurityGroups.ClientManagers)
                    .AddSecurityGroup(DocSecurityGroups.ClientSupport)
                    .AddSecurityGroup(DocSecurityGroups.Interns)
                    .AddSecurityGroup(DocSecurityGroups.OrderApprovers);
            });

            DeployModel(model);
        }

        #endregion
    }
}
