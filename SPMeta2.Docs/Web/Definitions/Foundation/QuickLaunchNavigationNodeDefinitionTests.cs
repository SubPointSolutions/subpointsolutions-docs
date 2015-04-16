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
    public class QuickLaunchNavigationNodeDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
            Title = "Adding quick navigation",
            Description = "",
            Order = 10,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.Navigation)]

        [TestMethod]
        [TestCategory("Docs.QuickLaunchNavigationNodeDefinition")]
        public void CaDeployFlatQuickLaunchNavigation()
        {
            var aboutUs = new QuickLaunchNavigationNodeDefinition
            {
                Title = "About us",
                Url = "about-us.aspx",
                IsExternal = true
            };

            var services = new QuickLaunchNavigationNodeDefinition
            {
                Title = "Services",
                Url = "services.aspx",
                IsExternal = true
            };

            var contacts = new QuickLaunchNavigationNodeDefinition
            {
                Title = "Contacts",
                Url = "contacts.aspx",
                IsExternal = true
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddQuickLaunchNavigationNode(aboutUs)
                    .AddQuickLaunchNavigationNode(services)
                    .AddQuickLaunchNavigationNode(contacts);
            });

            DeployModel(model);
        }

        [SampleMetadata(
            Title = "Adding two level quick navigation",
            Description = "",
            Order = 10,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.Navigation)]

        [TestMethod]
        [TestCategory("Docs.QuickLaunchNavigationNodeDefinition")]
        public void CaDeployHierarchicalQuickLaunchNavigation()
        {
            // top level departments node
            var departments = new QuickLaunchNavigationNodeDefinition
            {
                Title = "Departments",
                Url = "departments.aspx",
                IsExternal = true
            };

            var hr = new QuickLaunchNavigationNodeDefinition
            {
                Title = "HR",
                Url = "hr.aspx",
                IsExternal = true
            };

            var it = new QuickLaunchNavigationNodeDefinition
            {
                Title = "IT",
                Url = "it.aspx",
                IsExternal = true
            };

            // top level clients node
            var clients = new QuickLaunchNavigationNodeDefinition
            {
                Title = "Clients",
                Url = "clients.aspx",
                IsExternal = true
            };

            var microsoft = new QuickLaunchNavigationNodeDefinition
            {
                Title = "Microsoft",
                Url = "microsfot.aspx",
                IsExternal = true
            };

            var apple = new QuickLaunchNavigationNodeDefinition
            {
                Title = "Apple",
                Url = "apple.aspx",
                IsExternal = true
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddQuickLaunchNavigationNode(departments, node =>
                    {
                        node
                            .AddQuickLaunchNavigationNode(hr)
                            .AddQuickLaunchNavigationNode(it);
                    })
                    .AddQuickLaunchNavigationNode(clients, node =>
                    {
                        node
                          .AddQuickLaunchNavigationNode(microsoft)
                          .AddQuickLaunchNavigationNode(apple);
                    });
            });

            DeployModel(model);
        }

        #endregion
    }
}