using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Definitions;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;


using System.ComponentModel;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]

    [Category("Category=Web Model/Web site")]
    //[Browsable(false)]
    public class MasterPageSettingsDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.MasterPageSettingsDefinition")]

        [DisplayName("Add master page setting")]
        //[Browsable(false)]
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