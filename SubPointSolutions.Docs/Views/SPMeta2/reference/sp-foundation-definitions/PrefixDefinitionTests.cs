using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;


using System.ComponentModel;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]

    [Category("Category=Web Application Model/Web application")]

    //[Browsable(false)]
    public class PrefixDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.PrefixDefinition")]

        [DisplayName("Add prefix")]
        //[Browsable(false)]
        public void CanDeploySimplePrefixDefinition()
        {
            var prefixDef = new PrefixDefinition
            {
                Path = "projects",
                PrefixType = BuiltInPrefixTypes.WildcardInclusion
            };

            var model = SPMeta2Model.NewWebApplicationModel(webApp =>
            {
                webApp.AddPrefix(prefixDef);
            });

            DeployModel(model);
        }

        #endregion
    }
}