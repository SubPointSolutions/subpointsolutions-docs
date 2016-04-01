using System;
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
    public class FeatureDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
          Title = "Activating OOTB site features",
          Description = "",
          Order = 700,
          CatagoryAlias = SampleCategory.SharePointFoundation,
          GroupAlias = SampleGroups.SiteCollection)]


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


        [SampleMetadata(
        Title = "Activating OOTB web features",
        Description = "",
        Order = 700,
        CatagoryAlias = SampleCategory.SharePointFoundation,
        GroupAlias = SampleGroups.Web)]

        [TestMethod]
        [TestCategory("Docs.FeatureDefinition")]
        public void CanActivateOOTBWebFeatures()
        {
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddWebFeature(DocWebFeatures.WebPublishingInfrastructure)
                    .AddWebFeature(DocWebFeatures.MetadataNavigationAndFiltering)
                    .AddWebFeature(DocWebFeatures.MDS);

            });

            DeployModel(model);
        }


        [SampleMetadata(
        Title = "Deactivating OOTB web features",
        Description = "",
        Order = 710,
        CatagoryAlias = SampleCategory.SharePointFoundation,
        GroupAlias = SampleGroups.Web)]


        [TestMethod]
        [TestCategory("Docs.FeatureDefinition")]
        public void CanDeactivateOOTBWebFeatures()
        {
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddWebFeature(DocWebFeatures.Disable.MDS);
            });

            DeployModel(model);
        }

        [SampleMetadata(
           Title = "Activating custom web feature",
           Description = "",
           Order = 720,
           CatagoryAlias = SampleCategory.SharePointFoundation,
           GroupAlias = SampleGroups.Web)]

        [TestMethod]
        [TestCategory("Docs.FeatureDefinition")]
        public void CanActivateCustomWebFeature()
        {
            var myCustomerFeature = new FeatureDefinition
            {
                Enable = true,
                Id = new Guid("87294C72-F260-42f3-A41B-981A2FFCE37A"),
                Scope = FeatureDefinitionScope.Web
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddWebFeature(myCustomerFeature);
            });

            DeployModel(model);
        }

        [SampleMetadata(
          Title = "Deactivating custom web feature",
          Description = "",
          Order = 725,
          CatagoryAlias = SampleCategory.SharePointFoundation,
          GroupAlias = SampleGroups.Web)]

        [TestMethod]
        [TestCategory("Docs.FeatureDefinition")]
        public void CanDeactivateCustomWebFeature()
        {
            var myCustomerFeature = new FeatureDefinition
            {
                Enable = false,
                Id = new Guid("87294C72-F260-42f3-A41B-981A2FFCE37A"),
                Scope = FeatureDefinitionScope.Web
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddWebFeature(myCustomerFeature);
            });

            DeployModel(model);
        }

        [SampleMetadata(
          Title = "OOTB feature inheritance",
          Description = "",
          Order = 740,
          CatagoryAlias = SampleCategory.SharePointFoundation,
          GroupAlias = SampleGroups.Web)]

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
                    .AddWebFeature(enableMinimalDownloadStrategy);
            });

            DeployModel(enableMdsModel);

            // disable MDS
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddWebFeature(disableMinimalDownloadStrategy);
            });

            DeployModel(model);
        }


        #endregion
    }
}
