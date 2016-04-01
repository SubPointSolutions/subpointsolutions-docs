using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Attributes;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Consts;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class FolderDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
          Title = "Adding folders",
          Description = "",
          Order = 100,
          CatagoryAlias = SampleCategory.SharePointFoundation,
          GroupAlias = SampleGroups.List)]

        [TestMethod]
        [TestCategory("Docs.FolderDefinition")]
        public void CanDeploySimpleFolders()
        {
            var activeDocsFolder = new FolderDefinition
            {
                Name = "Active documents"
            };

            var archiveFolder = new FolderDefinition
            {
                Name = "Archive"
            };

            var listWithFolders = new ListDefinition
            {
                Title = "List with folders",
                Description = "Custom list with folders.",
                TemplateType = BuiltInListTemplateTypeId.GenericList,
                CustomUrl = "ListWithFolders"
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(listWithFolders, list =>
                {
                    list
                        .AddFolder(activeDocsFolder)
                        .AddFolder(archiveFolder);
                });
            });

            DeployModel(model);
        }

        [SampleMetadata(
          Title = "Adding folders to list",
          Description = "",
          Order = 100,
          CatagoryAlias = SampleCategory.SharePointFoundation,
          GroupAlias = SampleGroups.Folders)]

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

        [SampleMetadata(
          Title = "Adding hierarchical folders",
          Description = "",
          Order = 100,
          CatagoryAlias = SampleCategory.SharePointFoundation,
          GroupAlias = SampleGroups.Folders)]

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
