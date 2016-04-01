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
    public class TopNavigationNodeDefinitionTests : ProvisionTestBase
    {
        [SampleMetadata(
             Title = "Adding top navigation",
             Description = "",
             Order = 100,
             CatagoryAlias = SampleCategory.SharePointFoundation,
             GroupAlias = SampleGroups.Navigation)]

        [TestMethod]
        [TestCategory("Docs.TopNavigationNodeDefinition")]
        public void CaDeployFlatTopNavigation()
        {
            var ourCompany = new TopNavigationNodeDefinition
            {
                Title = "Our Company",
                Url = "our-company.aspx",
                IsExternal = true
            };

            var ourServices = new TopNavigationNodeDefinition
            {
                Title = "Our Services",
                Url = "our-services.aspx",
                IsExternal = true
            };

            var ourTeam = new TopNavigationNodeDefinition
            {
                Title = "Our Team",
                Url = "our-team.aspx",
                IsExternal = true
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddTopNavigationNode(ourCompany)
                    .AddTopNavigationNode(ourServices)
                    .AddTopNavigationNode(ourTeam);
            });

            DeployModel(model);
        }

        [SampleMetadata(
            Title = "Adding two level top navigation",
            Description = "",
            Order = 110,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.Navigation)]

        [TestMethod]
        [TestCategory("Docs.TopNavigationNodeDefinition")]
        public void CaDeployHierarchicalTopNavigation()
        {
            // top level departments node
            var departments = new TopNavigationNodeDefinition
            {
                Title = "Our Departments",
                Url = "our-departments.aspx",
                IsExternal = true
            };

            var hr = new TopNavigationNodeDefinition
            {
                Title = "HR Team",
                Url = "hr-team.aspx",
                IsExternal = true
            };

            var it = new TopNavigationNodeDefinition
            {
                Title = "IT Team",
                Url = "it-team.aspx",
                IsExternal = true
            };

            // top level clients node
            var partners = new TopNavigationNodeDefinition
            {
                Title = "Our Partners",
                Url = "our-partners.aspx",
                IsExternal = true
            };

            var microsoft = new TopNavigationNodeDefinition
            {
                Title = "Microsoft",
                Url = "microsfot.aspx",
                IsExternal = true
            };

            var apple = new TopNavigationNodeDefinition
            {
                Title = "Apple",
                Url = "apple.aspx",
                IsExternal = true
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddTopNavigationNode(departments, node =>
                    {
                        node
                            .AddTopNavigationNode(hr)
                            .AddTopNavigationNode(it);
                    })
                    .AddTopNavigationNode(partners, node =>
                    {
                        node
                          .AddTopNavigationNode(microsoft)
                          .AddTopNavigationNode(apple);
                    });
            });

            DeployModel(model);
        }
    }
}