using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;



namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]

   [Category("Category=Web Model/Display Templates")]
    //[Browsable(false)]
    public class JavaScriptDisplayTemplateDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.JavaScriptDisplayTemplateDefinition")]

        [DisplayName("Add JavaScript display template")]
        [Browsable(false)]
        public void CanDeploySimpleJavaScriptDisplayTemplateDefinition()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
         
            });

            DeployModel(model);
        }

        #endregion
    }
}