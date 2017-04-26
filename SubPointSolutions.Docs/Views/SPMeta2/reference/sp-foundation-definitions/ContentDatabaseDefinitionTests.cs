using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;


using System.ComponentModel;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]

    [Category("Category=Web Application Model/Web application;CategoryOrder=100")]
    //[Browsable(false)]
    public class ContentDatabaseDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.ContentDatabaseDefinition")]

        [DisplayName("Add content database")]
        //[Browsable(false)]
        public void CanDeploySimpleContentDatabaseDefinition()
        {
            var contentDb1 = new ContentDatabaseDefinition
            {
                ServerName = "localhost",
                DbName = "intranet_content_db1"
            };

            var contentDb2 = new ContentDatabaseDefinition
            {
                ServerName = "localhost",
                DbName = "intranet_content_db2"
            };

            var model = SPMeta2Model.NewWebApplicationModel(webApp =>
            {
                webApp
                    .AddContentDatabase(contentDb1)
                    .AddContentDatabase(contentDb2);
            });

            DeployModel(model);
        }

        #endregion
    }
}