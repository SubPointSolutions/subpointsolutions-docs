using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Attributes;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Consts;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class MasterPageSettingsDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.MasterPageSettingsDefinition")]

        [SampleMetadata(
            Title = "Adding master page settings",
            Description = "",
            Order = 1000,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.Web)]

        public void CanDeployWebmasterPageSettings()
        {
            // BuiltInMasterPageDefinitions class could be used to refer OOTB master pages
            // BuiltInMasterPageDefinitions.Seattle 
            // BuiltInMasterPageDefinitions.Oslo  
            // BuiltInMasterPageDefinitions.Minimal  

            var masterPageSettings = new MasterPageSettingsDefinition
            {
                // both should be site relative URLs
                SiteMasterPageUrl = "/_catalogs/masterpage/oslo.master",
                SystemMasterPageUrl = "/_catalogs/masterpage/oslo.master"
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddMasterPageSettings(masterPageSettings);
            });

            DeployModel(model);
        }

        #endregion
    }
}