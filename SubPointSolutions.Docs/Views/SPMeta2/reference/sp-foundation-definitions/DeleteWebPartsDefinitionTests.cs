using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;
using System.Collections.Generic;
using System.ComponentModel;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    [Category("Category=Web Model/Web parts")]

    //[SampleMetadataTag(Name = BuiltInTagNames.SampleHidden)]
    public class DeleteWebPartsDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.DeleteWebPartsDefinition")]

        [DisplayName("Delete web part by Title")]
        public void CanDeployDeleteWebPartsDefinition_ByTitle()
        {
            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 webparts",
                FileName = "web-parts.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            // aiming to delete two web part with the following titles:
            // 'My Tasks'
            // 'My Projects'
            var myWebPartDeletionDef = new DeleteWebPartsDefinition
            {
                WebParts = new List<WebPartMatch>(new WebPartMatch[] { 
                    new WebPartMatch {
                        Title = "My Tasks"
                    },
                    new WebPartMatch {
                        Title = "My Projects"
                    }
                })
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.SitePages, list =>
                {
                    list.AddWebPartPage(webPartPage, page =>
                    {
                        page.AddDeleteWebParts(myWebPartDeletionDef);
                    });
                });
            });

            DeployModel(model);
        }

        #endregion
    }
}