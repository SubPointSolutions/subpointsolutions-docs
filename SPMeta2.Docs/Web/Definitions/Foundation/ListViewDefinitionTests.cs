using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;
using System.Collections.ObjectModel;
using System.Text;
using SPMeta2.Docs.ProvisionSamples.Attributes;
using SPMeta2.Docs.ProvisionSamples.Consts;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class ListViewDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
        Title = "Adding list views",
        Description = "",
        Order = 100,
        CatagoryAlias = SampleCategory.SharePointFoundation,
        GroupAlias = SampleGroups.List)]

        [TestMethod]
        [TestCategory("Docs.ListViewDefinition")]
        public void CanDeploySimpleListViews()
        {
            var approvedDocuments = new ListViewDefinition
            {
                Title = "Approved Documents",
                Fields = new Collection<string>
                {
                    BuiltInInternalFieldNames.ID,
                    BuiltInInternalFieldNames.FileLeafRef
                }
            };

            var inProgressDocuments = new ListViewDefinition
            {
                Title = "In Progress Documents",
                Fields = new Collection<string>
                {
                    BuiltInInternalFieldNames.ID,
                    BuiltInInternalFieldNames.FileLeafRef
                }
            };

            var documentLibrary = new ListDefinition
            {
                Title = "CustomerDocuments",
                Description = "A customr document library.",
                TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
                CustomUrl = "CustomerDocuments"
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(documentLibrary, list =>
                {
                    list.AddListView(approvedDocuments);
                    list.AddListView(inProgressDocuments);

                });
            });

            DeployModel(model);
        }

        [SampleMetadata(
         Title = "Adding list view with custom URL",
         Description = "",
         Order = 100,
         CatagoryAlias = SampleCategory.SharePointFoundation,
         GroupAlias = SampleGroups.ListViews)]

        [TestMethod]
        [TestCategory("Docs.ListViewDefinition")]
        public void CanDeploySimpleListViewsWithCustomUrl()
        {
            var returnedDocuments = new ListViewDefinition
            {
                Title = "Returned Documents",
                Url = "Returned.aspx",
                Fields = new Collection<string>
                {
                    BuiltInInternalFieldNames.ID,
                    BuiltInInternalFieldNames.FileLeafRef
                }
            };

            var documentLibrary = new ListDefinition
            {
                Title = "CustomerDocuments",
                Description = "A customr document library.",
                TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
                CustomUrl = "CustomerDocuments"
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(documentLibrary, list =>
                {
                    list.AddListView(returnedDocuments);
                });
            });

            DeployModel(model);
        }

        [SampleMetadata(
         Title = "Adding list view with custom CAML",
         Description = "",
         Order = 100,
         CatagoryAlias = SampleCategory.SharePointFoundation,
         GroupAlias = SampleGroups.ListViews)]

        [TestMethod]
        [TestCategory("Docs.ListViewDefinition")]
        public void CanDeploySimpleListViewsWithCAMLQuery()
        {
            var createdQuery = new StringBuilder();

            createdQuery.Append("<Where>");
            createdQuery.Append("</Where>");
            createdQuery.Append("<OrderBy>");
            createdQuery.Append("  <FieldRef Name='ID' Ascending='FALSE'/>");
            createdQuery.Append("</OrderBy>");

            var lastTenCreatedDocuments = new ListViewDefinition
            {
                Title = "Last 10 Created Documents",
                RowLimit = 10,
                Query = createdQuery.ToString(),
                Fields = new Collection<string>
                {
                    BuiltInInternalFieldNames.ID,
                    BuiltInInternalFieldNames.FileLeafRef
                }
            };

            var editedQuery = new StringBuilder();

            editedQuery.Append("<Where>");
            editedQuery.Append("</Where>");
            editedQuery.Append("<OrderBy>");
            editedQuery.Append("  <FieldRef Name='Modified' Ascending='FALSE'/>");
            editedQuery.Append("</OrderBy>");

            var lastTenEditedDocuments = new ListViewDefinition
            {
                Title = "Last 10 Edited Documents",
                RowLimit = 10,
                Query = editedQuery.ToString(),
                Fields = new Collection<string>
                {
                    BuiltInInternalFieldNames.ID,
                    BuiltInInternalFieldNames.FileLeafRef
                }
            };

            var documentLibrary = new ListDefinition
            {
                Title = "CustomerDocuments",
                Description = "A customr document library.",
                TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
                CustomUrl = "CustomerDocuments"
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(documentLibrary, list =>
                {
                    list.AddListView(lastTenCreatedDocuments);
                    list.AddListView(lastTenEditedDocuments);
                });
            });

            DeployModel(model);
        }

        #endregion
    }
}