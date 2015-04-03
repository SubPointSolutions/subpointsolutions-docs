using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class ContentTypeDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.ContentTypeDefinition")]
        public void CanDeploySimpleContentTypes()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                   .AddContentType(DocContentTypes.CustomerAccount)
                   .AddContentType(DocContentTypes.CustomerDocument);
            });

            DeployModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.ContentTypeDefinition")]
        public void CanDeploySimpleContentTypesWithFields()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddField(DocFields.Clients.ClientCredit)
                    .AddField(DocFields.Clients.ClientDebit)
                    .AddField(DocFields.Clients.ClientDescription)
                    .AddField(DocFields.Clients.ClientNumber)
                    .AddField(DocFields.Clients.ClientWebSite)

                   .AddContentType(DocContentTypes.CustomerAccount, contentType =>
                   {
                       contentType
                         .AddContentTypeFieldLink(DocFields.Clients.ClientCredit)
                         .AddContentTypeFieldLink(DocFields.Clients.ClientDebit)
                         .AddContentTypeFieldLink(DocFields.Clients.ClientWebSite);
                   })
                   .AddContentType(DocContentTypes.CustomerDocument, contentType =>
                   {
                       contentType
                          .AddContentTypeFieldLink(DocFields.Clients.ClientDescription)
                          .AddContentTypeFieldLink(DocFields.Clients.ClientNumber);
                   });
            });

            DeployModel(model);
        }

        #endregion
    }
}
