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
        Title = "Adding web part pages",
            Description = "",
            Order = 10,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.WebPartPages)]

        [TestMethod]
        [TestCategory("Docs.WebPartPageDefinition")]
        public void CanDeploySimpleWebPartPageDefinition()
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

        #endregion
    }
}