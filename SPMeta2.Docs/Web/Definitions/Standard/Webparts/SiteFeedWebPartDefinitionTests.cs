using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Attributes;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Consts;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Standard.Definitions.Webparts;
using SPMeta2.Standard.Syntax;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class SiteFeedWebPartDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
         Title = "Adding site feed web part",
         Description = "",
         Order = 50,
         CatagoryAlias = SampleCategory.SharePointStandard,
         GroupAlias = SampleGroups.SiteFeedWebPart)]


        [TestMethod]
        [TestCategory("Docs.SiteFeedWebPartDefinition")]
        public void CanDeploySimpleSiteFeedWebPartDefinition()
        {
            var siteFeed = new SiteFeedWebPartDefinition
            {
                Title = "Site Feed",
                Id = "m2SiteFeed",
                ZoneIndex = 10,
                ZoneId = "Main"
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 Site Feed provision",
                FileName = "site-feed-webpart-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                  .AddWebFeature(BuiltInWebFeatures.SiteFeed.Inherit().Enable())
                  .AddHostList(BuiltInListDefinitions.SitePages, list =>
                  {
                      list.AddWebPartPage(webPartPage, page =>
                      {
                          page.AddSiteFeedWebPart(siteFeed);
                      });
                  });
            });

            DeployModel(model);
        }

        #endregion
    }
}