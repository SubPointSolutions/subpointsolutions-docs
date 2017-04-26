using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;
using SPMeta2.Enumerations;


using System.ComponentModel;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]


    [Category("Category=Farm Model/Farm")]


    //[Browsable(false)]
    public class FarmDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.FarmDefinition")]

        [DisplayName("Add farm feature")]
        //[Browsable(false)]
        public void CanDeploySimpleFarmDefinition()
        {
            var farmFeature = BuiltInFarmFeatures.SiteMailboxes.Inherit(f =>
            {
                f.Enable = true;
            });

            var model = SPMeta2Model.NewFarmModel(farm =>
            {
                farm.AddFarmFeature(farmFeature);
            });

            DeployModel(model);
        }

        #endregion
    }
}