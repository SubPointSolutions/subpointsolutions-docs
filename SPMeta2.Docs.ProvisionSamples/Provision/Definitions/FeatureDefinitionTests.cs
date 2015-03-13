using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class FeatureDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.FeatureDefinition")]
        public void CanActivateOOTBSiteFeatures()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddSiteFeature(DocSiteFeatures.SitePublisingInfrastructure)
                    .AddSiteFeature(DocSiteFeatures.DocumentSets);

            });

            DeployModel(model);
        }


        [TestMethod]
        [TestCategory("Docs.FeatureDefinition")]
        public void CanActivateOOTBWebFeatures()
        {
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddSiteFeature(DocWebFeatures.WebPublishingInfrastructure)
                    .AddSiteFeature(DocWebFeatures.MetadataNavigationAndFiltering)
                    .AddSiteFeature(DocWebFeatures.MDS);

            });

            DeployModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.FeatureDefinition")]
        public void CanDeactivateOOTBWebFeatures()
        {
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddSiteFeature(DocWebFeatures.Disable.MDS);
            });

            DeployModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.FeatureDefinition")]
        public void CanActivateCustomWebFeature()
        {
            var myCustomerFeature = new FeatureDefinition
            {
                Enable = true,
                Id = new Guid("6b588ec5-3019-420a-bd40-c7aef5e4e4fc")
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddSiteFeature(myCustomerFeature);
            });

            DeployModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.FeatureDefinition")]
        public void CanDeactivateCustomWebFeature()
        {
            var myCustomerFeature = new FeatureDefinition
            {
                Enable = true,
                Id = new Guid("6b588ec5-3019-420a-bd40-c7aef5e4e4fc")
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddSiteFeature(myCustomerFeature);
            });

            DeployModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.FeatureDefinition")]
        public void OOTBFeatureInheritance()
        {
            var enableMinimalDownloadStrategy = BuiltInWebFeatures.MinimalDownloadStrategy.Inherit(def =>
            {
                def.Enable = true;
            });

            var disableMinimalDownloadStrategy = BuiltInWebFeatures.MinimalDownloadStrategy.Inherit(def =>
            {
                def.Enable = false;
            });

            // enable MDS
            var enableMdsModel = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddSiteFeature(enableMinimalDownloadStrategy);
            });

            DeployModel(enableMdsModel);

            // disable MDS
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddSiteFeature(disableMinimalDownloadStrategy);
            });

            DeployModel(model);
        }


        #endregion
    }
}
