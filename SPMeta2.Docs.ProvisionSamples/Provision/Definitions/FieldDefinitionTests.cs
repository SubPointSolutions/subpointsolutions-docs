using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class FieldDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.FieldDefinition")]
        public void CanDeploySimpleFields()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddField(DocFields.Clients.ClientCredit)
                    .AddField(DocFields.Clients.ClientDebit)
                    .AddField(DocFields.Clients.ClientDescription)
                    .AddField(DocFields.Clients.ClientNumber)
                    .AddField(DocFields.Clients.ClientWebSite);
            });

            DeployModel(model);
        }

        #endregion
    }
}
