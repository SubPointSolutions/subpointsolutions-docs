using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class FolderDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.FolderDefinition")]
        public void CanDeploySimpleFolderList()
        {
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(DocLists.GeneralReports, list =>
                {
                    list
                        .AddFolder(DocFolders.Years.Year2013)
                        .AddFolder(DocFolders.Years.Year2014)
                        .AddFolder(DocFolders.Years.Year2015);
                });
            });

            DeployModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.FolderDefinition")]
        public void CanDeployHierarchicalFolderList()
        {
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(DocLists.GeneralReports, list =>
                {
                    list
                        .AddFolder(DocFolders.Years.Year2013, year2013 =>
                        {
                            year2013
                                .AddFolder(DocFolders.Quarters.Q1)
                                .AddFolder(DocFolders.Quarters.Q2)
                                .AddFolder(DocFolders.Quarters.Q3)
                                .AddFolder(DocFolders.Quarters.Q4);
                        })
                        .AddFolder(DocFolders.Years.Year2014, year2014 =>
                        {
                            year2014
                                .AddFolder(DocFolders.Quarters.Q1)
                                .AddFolder(DocFolders.Quarters.Q2)
                                .AddFolder(DocFolders.Quarters.Q3)
                                .AddFolder(DocFolders.Quarters.Q4);
                        })
                        .AddFolder(DocFolders.Years.Year2015, year2015 =>
                        {
                            year2015
                                .AddFolder(DocFolders.Quarters.Q1)
                                .AddFolder(DocFolders.Quarters.Q2)
                                .AddFolder(DocFolders.Quarters.Q3)
                                .AddFolder(DocFolders.Quarters.Q4);
                        });
                });
            });

            DeployModel(model);
        }

        #endregion
    }
}
