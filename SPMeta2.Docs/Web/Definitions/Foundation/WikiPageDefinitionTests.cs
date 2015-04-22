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
    public class WikiPageDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
          Title = "Adding to 'Site Pages' library",
          Description = "",
          Order = 100,
          CatagoryAlias = SampleCategory.SharePointFoundation,
          GroupAlias = SampleGroups.WikiPages)]

        [TestMethod]
        [TestCategory("Docs.WikiPageDefinition")]
        public void CanDeploySimpleWikiPages()
        {
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.SitePages, list =>
                {
                    list
                        .AddWikiPage(DocWikiPages.AboutUs)
                        .AddWikiPage(DocWikiPages.Contacts);
                });
            });

            DeployModel(model);
        }

        [SampleMetadata(
          Title = "Adding to a folder",
          Description = "",
          Order = 100,
          CatagoryAlias = SampleCategory.SharePointFoundation,
          GroupAlias = SampleGroups.WikiPages)]

        [TestMethod]
        [TestCategory("Docs.WikiPageDefinition")]
        public void CanDeployWikiPagesUnderFolder()
        {
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.SitePages, list =>
                {
                    list
                        .AddFolder(DocFolders.WikiPages.News, newsFolder =>
                        {
                            newsFolder
                                .AddWikiPage(DocWikiPages.NewCoffeeMachine)
                                .AddWikiPage(DocWikiPages.NewSPMeta2Release);
                        })
                        .AddFolder(DocFolders.WikiPages.Archive, archiveFolder =>
                        {
                            archiveFolder
                               .AddWikiPage(DocWikiPages.December2012News)
                               .AddWikiPage(DocWikiPages.October2012News);
                        });
                });
            });

            DeployModel(model);
        }

        #endregion
    }
}
