﻿using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;
using SubPointSolutions.Docs.Code.Definitions;



namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    //[Browsable(false)]
    public class FeatureDefinitionTests : ProvisionTestBase
    {
        #region methods

       


        [TestMethod]
        [TestCategory("Docs.FeatureDefinition")]

        [Category("Category=Site Collection Model/Features")]

        [DisplayName("Activate OOTB site features")]
        //[Browsable(false)]

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

        [Category("Category=Web Model/Features")]

        [DisplayName("Activate OOTB web features")]
        //[Browsable(false)]
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


   


        [TestMethod]
        [TestCategory("Docs.FeatureDefinition")]

        [Category("Category=Web Model/Features")]
        [DisplayName("Disable OOTB web features")]
        //[Browsable(false)]
        public void CanDeactivateOOTBWebFeatures()
        {
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddWebFeature(DocWebFeatures.Disable.MDS);
            });

            DeployModel(model);
        }


        [TestMethod]
        [TestCategory("Docs.FeatureDefinition")]

        [Category("Category=Web Model/ Features")]
        [DisplayName("Activate custom web features")]
        //[Browsable(false)]
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


        [TestMethod]
        [TestCategory("Docs.FeatureDefinition")]

        [Category("Category=Web Model/Features")]
        [DisplayName("Disable custom web features")]
        //[Browsable(false)]
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


        [TestMethod]
        [TestCategory("Docs.FeatureDefinition")]

        [Category("Category=Web Model/Features")]
        [DisplayName("Inherit OOTB features")]
        //[Browsable(false)]
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
