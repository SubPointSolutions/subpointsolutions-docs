using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Standard.Definitions;
using SPMeta2.Standard.Enumerations;
using SPMeta2.Syntax.Default;
using SPMeta2.Standard.Syntax;
using SubPointSolutions.Docs.Code.Enumerations;
using SubPointSolutions.Docs.Code.Metadata;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]

    [Category("Category=Web Model/Web site")]
    //[Browsable(false)]
    public class PageLayoutAndSiteTemplateSettingsDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.PageLayoutAndSiteTemplateSettingsDefinition")]

        [DisplayName("Setup default web templates")]
        //[Browsable(false)]
        public void CanDeploySimplePageLayoutAndSiteTemplateSettingsDefinition()
        {
            var sitePublishingInfrastructureFeature = BuiltInSiteFeatures.SharePointServerPublishingInfrastructure.Inherit(def =>
            {
                def.Enable();
            });

            var webPublishingInfrastructureFeature = BuiltInWebFeatures.SharePointServerPublishing.Inherit(def =>
            {
                def.Enable();
            });

            var settings = new PageLayoutAndSiteTemplateSettingsDefinition
            {
                // setup web templates
                UseDefinedWebTemplates = true,
                DefinedWebTemplates = new Collection<string>
                {
                    BuiltInWebTemplates.Collaboration.BlankSite,
                    BuiltInWebTemplates.Collaboration.Blog,
                    BuiltInWebTemplates.Collaboration.TeamSite
                },

                // setup page layouts
                UseDefinedPageLayouts = true,
                DefinedPageLayouts = new Collection<string>
                {
                    BuiltInPublishingPageLayoutNames.ArticleLeft,
                    BuiltInPublishingPageLayoutNames.ArticleRight,
                    BuiltInPublishingPageLayoutNames.ArticleLinks
                },

                // setup default page layout
                UseDefinedDefaultPageLayout = true,
                DefinedDefaultPageLayout = BuiltInPublishingPageLayoutNames.ArticleRight,
            };

            // create site model to enable publishing infrastructure
            // then deploy web model with page layout settings

            var siteModel = SPMeta2Model.NewSiteModel(site =>
            {
                site.AddSiteFeature(sitePublishingInfrastructureFeature);
            });

            var webModel = SPMeta2Model.NewWebModel(web =>
            {
                web.AddWebFeature(webPublishingInfrastructureFeature);
                web.AddPageLayoutAndSiteTemplateSettings(settings);
            });

            DeployModel(siteModel);
            DeployModel(webModel);
        }

        #endregion
    }
}