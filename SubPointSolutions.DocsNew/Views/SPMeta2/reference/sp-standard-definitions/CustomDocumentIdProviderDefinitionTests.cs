using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;



namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]

    [Category("Category=Site Collection Model/Site collection")]
    //[Browsable(false)]
    public class CustomDocumentIdProviderDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.CustomDocumentIdProviderDefinition")]

        [DisplayName("Add Document ID provider")]
        [Browsable(false)]
        public void CanDeploySimpleCustomDocumentIdProviderDefinition()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {

            });

            DeployModel(model);
        }

        #endregion
    }
}