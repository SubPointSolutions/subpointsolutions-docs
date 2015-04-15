using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
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
    public class WebPartPageDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
        Title = "Adding pages",
            Description = "",
            Order = 10,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.WebPartPages)]

        [TestMethod]
        [TestCategory("Docs.WebPartPageDefinition")]
        public void CanDeployWebPartPages()
        {
            var customersReportPage = new WebPartPageDefinition
            {
                FileName = "Customers-report.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var parthesReportPage = new WebPartPageDefinition
            {
                FileName = "Parthers-report.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd2
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.SitePages, list =>
                {
                    list
                        .AddWebPartPage(customersReportPage)
                        .AddWebPartPage(parthesReportPage);
                });
            });

            DeployModel(model);
        }


        [SampleMetadata(
        Title = "Adding page with custom layout",
            Description = "",
            Order = 20,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.WebPartPages)]

        [TestMethod]
        [TestCategory("Docs.WebPartPageDefinition")]
        public void CanDeployWebPartPageWithCustomTemplate()
        {
            var customizedWebPartPage = new WebPartPageDefinition
            {
                FileName = "Customers-report.aspx",
                CustomPageLayout = "___ a custom web part page template here ___ "
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.SitePages, list =>
                {
                    list
                        .AddWebPartPage(customizedWebPartPage);
                });
            });

            DeployModel(model);
        }

        [SampleMetadata(
        Title = "Adding pages under folders",
            Description = "",
            Order = 30,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.WebPartPages)]

        [TestMethod]
        [TestCategory("Docs.WebPartPageDefinition")]
        public void CanDeployWebPartPagesUnderFolders()
        {
            // clients folder and pages
            var clientsFolder = new FolderDefinition()
            {
                Name = "Customers"
            };

            var clientMay2015Page = new WebPartPageDefinition
            {
                FileName = "May-2015-analytics.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var clientJune2015Page = new WebPartPageDefinition
            {
                FileName = "June-2015-analytics.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            // parthers folder and pages
            var parthersFolder = new FolderDefinition()
            {
                Name = "Parthers"
            };

            var parther2014AnnualReport = new WebPartPageDefinition
            {
                FileName = "Annual-report-2014.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var parther2015AnnualReport = new WebPartPageDefinition
            {
                FileName = "Annual-report-2015.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1,
            };

            // linking everything together
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.SitePages, list =>
                {
                    list
                        .AddFolder(clientsFolder, folder =>
                        {
                            folder
                                .AddWebPartPage(clientMay2015Page)
                                .AddWebPartPage(clientJune2015Page);
                        })
                        .AddFolder(parthersFolder, folder =>
                        {
                            folder
                              .AddWebPartPage(parther2014AnnualReport)
                              .AddWebPartPage(parther2015AnnualReport);
                        });
                });
            });

            DeployModel(model);
        }

        #endregion
    }
}