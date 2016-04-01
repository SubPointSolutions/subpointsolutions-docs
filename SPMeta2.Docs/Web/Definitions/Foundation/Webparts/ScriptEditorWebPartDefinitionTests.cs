using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Webparts;
using SPMeta2.Docs.ProvisionSamples.Attributes;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Consts;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class ScriptEditorWebPartDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
         Title = "Adding empty script editor",
         Description = "",
         Order = 50,
         CatagoryAlias = SampleCategory.SharePointFoundation,
         GroupAlias = SampleGroups.ScriptEditorWebPart)]

        [TestMethod]
        [TestCategory("Docs.ScriptEditorWebPartDefinition")]
        public void CanDeploySimpleScriptEditorWebPartDefinition()
        {
            var scriptEditor = new ScriptEditorWebPartDefinition
            {
                Title = "Empty Script Editor",
                Id = "m2EmptyScriptEditorrWhichMustBeMoreThan32Chars",
                ZoneIndex = 10,
                ZoneId = "Main"
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 Script Editor provision",
                FileName = "script-editor-webpart-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                  .AddHostList(BuiltInListDefinitions.SitePages, list =>
                  {
                      list.AddWebPartPage(webPartPage, page =>
                      {
                          page.AddScriptEditorWebPart(scriptEditor);
                      });
                  });
            });

            DeployModel(model);
        }

        [SampleMetadata(
         Title = "Adding script editor with script",
         Description = "",
         Order = 100,
         CatagoryAlias = SampleCategory.SharePointFoundation,
         GroupAlias = SampleGroups.ScriptEditorWebPart)]

        [TestMethod]
        [TestCategory("Docs.ScriptEditorWebPartDefinition")]
        public void CanDeployScriptEditorWebPartwithContent()
        {
            var scriptEditor = new ScriptEditorWebPartDefinition
            {
                Title = "Pre-provisioned Script Editor",
                Id = "m2ScriptEditorWithLoggerWhichMustBeMoreThan32Chars",
                ZoneIndex = 20,
                ZoneId = "Main",
                Content = " <script> console.log('script editor log');  </script> Pre-provisioned Script Editor Content"
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 Script Editor provision",
                FileName = "script-editor-webpart-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                  .AddHostList(BuiltInListDefinitions.SitePages, list =>
                  {
                      list.AddWebPartPage(webPartPage, page =>
                      {
                          page.AddScriptEditorWebPart(scriptEditor);
                      });
                  });
            });

            DeployModel(model);
        }

        #endregion
    }
}