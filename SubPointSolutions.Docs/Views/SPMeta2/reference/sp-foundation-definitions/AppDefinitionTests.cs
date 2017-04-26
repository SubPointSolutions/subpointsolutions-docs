using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;


using System;
using System.ComponentModel;
using System.IO;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]

    [Category("Category=Web Model/Web site")]

    public class AppDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.AppDefinition")]

        [DisplayName("Add app")]
        //[Browsable(false)]
        public void CanDeploySimpleAppDefinition()
        {
            var appDef = new AppDefinition
            {
                Content = File.ReadAllBytes("path-to-your-app-file"),
                ProductId = new Guid("your-app-product-id"),
                // your app version 
                Version = "1.0.0.0"
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddApp(appDef);
            });

            DeployModel(model);
        }

        #endregion
    }
}