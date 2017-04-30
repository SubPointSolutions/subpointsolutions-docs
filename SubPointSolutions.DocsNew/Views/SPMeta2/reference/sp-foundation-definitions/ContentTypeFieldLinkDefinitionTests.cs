using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;


using System.ComponentModel;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    

    [Category("Category=Web Model/Content types")]

    //[Browsable(false)]
    public class ContentTypeFieldLinkDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.ContentTypeFieldLinkDefinition")]

        [DisplayName("Add field to content types")]
        [Browsable(false)]
        public void CanDeploySimpleContentTypeFieldLinkDefinition()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
         
            });

            DeployModel(model);
        }

        #endregion
    }
}