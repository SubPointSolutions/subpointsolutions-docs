using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;
using SubPointSolutions.Docs.Code.Definitions;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class SecurityGroupDefinitionTests : ProvisionTestBase
    {
        #region methods

       
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
