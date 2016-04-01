using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Webparts;
using SPMeta2.Docs.ProvisionSamples.Attributes;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Consts;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;
using SPMeta2.Utils;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.CSOM.DefaultSyntax;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class ContentEditorWebPartDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
         Title = "Empty web part",
         Description = "",
         Order = 10,
         CatagoryAlias = SampleCategory.SharePointFoundation,
         GroupAlias = SampleGroups.ContentEditorWebpart)]


        [TestMethod]
        [TestCategory("Docs.ContentEditorWebPartDefinition")]
        public void CanDeploEmptyContentEditorWebpart()
        {
            var cewp = new ContentEditorWebPartDefinition
            {
                Title = "Empty Content Editor Webpart",
                Id = "m2EmptyCEWP",
                ZoneIndex = 10,
                ZoneId = "Main"
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 CEWP provision",
                FileName = "cewp-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.SitePages, list =>
                {
                    list.AddWebPartPage(webPartPage, page =>
                    {
                        page.AddContentEditorWebPart(cewp);
                    });
                });
            });

            DeployModel(model);
        }

        [SampleMetadata(
        Title = "Predefined URL content link",
        Description = "",
        Order = 20,
        CatagoryAlias = SampleCategory.SharePointFoundation,
        GroupAlias = SampleGroups.ContentEditorWebpart)]

        [TestMethod]
        [TestCategory("Docs.ContentEditorWebPartDefinition")]
        public void CanDeploContentEditorWebpartWithUrlLink()
        {
            var htmlContent = new ModuleFileDefinition
            {
                FileName = "m2-cewp-content.html",
                Content = Encoding.UTF8.GetBytes("M2 is everything you need to deploy stuff to Sharepoint"),
                Overwrite = true,
            };

            var cewp = new ContentEditorWebPartDefinition
            {
                Title = "Content Editor Webpart with URL link",
                Id = "m2ContentLinkCEWP",
                ZoneIndex = 20,
                ZoneId = "Main",
                ContentLink = UrlUtility.CombineUrl(new string[]{
                        "~sitecollection",
                        BuiltInListDefinitions.StyleLibrary.CustomUrl,
                        htmlContent.FileName})
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 CEWP provision",
                FileName = "cewp-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddHostList(BuiltInListDefinitions.StyleLibrary, list =>
                    {
                        list.AddModuleFile(htmlContent);
                    })
                    .AddHostList(BuiltInListDefinitions.SitePages, list =>
                    {
                        list.AddWebPartPage(webPartPage, page =>
                        {
                            page.AddContentEditorWebPart(cewp);
                        });
                    });
            });

            DeployModel(model);
        }

        [SampleMetadata(
        Title = "Predefined content",
        Description = "",
        Order = 30,
        CatagoryAlias = SampleCategory.SharePointFoundation,
        GroupAlias = SampleGroups.ContentEditorWebpart)]

        [TestMethod]
        [TestCategory("Docs.ContentEditorWebPartDefinition")]
        public void CanDeployContentEditorWebpartWithContent()
        {
            var cewp = new ContentEditorWebPartDefinition
            {
                Title = "Content Editor Webpart with content",
                Id = "m2ContentCEWP",
                ZoneIndex = 30,
                ZoneId = "Main",
                Content = "Content Editor web part inplace content."
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 CEWP provision",
                FileName = "cewp-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.SitePages, list =>
                {
                    list.AddWebPartPage(webPartPage, page =>
                    {
                        page.AddContentEditorWebPart(cewp);
                    });
                });
            });

            DeployModel(model);
        }

        #endregion
    }
}