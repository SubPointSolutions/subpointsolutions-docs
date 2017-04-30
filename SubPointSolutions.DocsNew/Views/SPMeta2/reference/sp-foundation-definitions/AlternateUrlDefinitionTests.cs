using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;



namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]

    [Category("Category=Web Application Model/Web application;CategoryOrder=200")]

    public class AlternateUrlDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.AlternateUrlDefinition")]

        [DisplayName("Add alternate URL")]
        public void CanDeploySimpleAlternateUrlDefinition()
        {
            var internalDef = new AlternateUrlDefinition
            {
                Url = "http://the-portal",
                UrlZone = BuiltInUrlZone.Intranet
            };

            var intranetDef = new AlternateUrlDefinition
            {
                Url = "http://my-intranet.com.au",
                UrlZone = BuiltInUrlZone.Internet
            };

            var model = SPMeta2Model.NewWebApplicationModel(webApp =>
            {
                webApp.AddAlternateUrl(internalDef);
                webApp.AddAlternateUrl(intranetDef);
            });

            DeployModel(model);
        }

        #endregion
    }
}