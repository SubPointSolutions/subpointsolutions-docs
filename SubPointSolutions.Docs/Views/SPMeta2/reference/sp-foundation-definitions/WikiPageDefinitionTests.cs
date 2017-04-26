using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Webparts;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;
using SubPointSolutions.Docs.Code.Definitions;


using System.ComponentModel;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    

    [Category("Category=Web Model/Wiki pages")]
    //[Browsable(false)]
    public class WikiPageDefinitionTests : ProvisionTestBase
    {
        #region methods

      

        [TestMethod]
        [TestCategory("Docs.WikiPageDefinition")]

        [DisplayName("Add wiki pages")]
        //[Browsable(false)]
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

      

        [TestMethod]
        [TestCategory("Docs.WikiPageDefinition")]

        [DisplayName("Add wiki pages to folders")]
        //[Browsable(false)]
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
