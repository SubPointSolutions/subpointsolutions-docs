using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.CSOM.DefaultSyntax;
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
    public class XsltListViewWebPartDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
            Title = "Binding to list by Title",
            Description = "",
            Order = 100,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.XsltListViewWebPart)]
        [TestMethod]
        [TestCategory("Docs.XsltListViewWebPartDefinition")]
        public void CanBindXsltListViewWebPartByListTitle()
        {
            var inventoryLibrary = new ListDefinition
            {
                Title = "Inventory library",
                Description = "A document library.",
                TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
                CustomUrl = "InventoryLibrary"
            };

            var xsltListView = new XsltListViewWebPartDefinition
            {
                Title = "Inventory Default View by List Title",
                Id = "m2InventoryView",
                ZoneIndex = 10,
                ZoneId = "Main",
                ListTitle = inventoryLibrary.Title
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 Xslt List View provision",
                FileName = "xslt-listview-webpart-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                  .AddList(inventoryLibrary)
                  .AddHostList(BuiltInListDefinitions.SitePages, list =>
                  {
                      list.AddWebPartPage(webPartPage, page =>
                      {
                          page.AddXsltListViewWebPart(xsltListView);
                      });
                  });
            });

            DeployModel(model);
        }

        [SampleMetadata(
            Title = "Binding to list by Url",
            Description = "",
            Order = 150,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.XsltListViewWebPart)]
        [TestMethod]
        [TestCategory("Docs.XsltListViewWebPartDefinition")]
        public void CanBindXsltListViewWebPartByListUrl()
        {
            var booksLibrary = new ListDefinition
            {
                Title = "Books library",
                Description = "A document library.",
                TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
                CustomUrl = "BooksLibrary"
            };

            var xsltListView = new XsltListViewWebPartDefinition
            {
                Title = "Books Default View by List Url",
                Id = "m2BooksView",
                ZoneIndex = 10,
                ZoneId = "Main",
                ListUrl = booksLibrary.CustomUrl
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 Xslt List View provision",
                FileName = "xslt-listview-webpart-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                  .AddList(booksLibrary)
                  .AddHostList(BuiltInListDefinitions.SitePages, list =>
                  {
                      list.AddWebPartPage(webPartPage, page =>
                      {
                          page.AddXsltListViewWebPart(xsltListView);
                      });
                  });
            });

            DeployModel(model);
        }

        [SampleMetadata(
            Title = "Binding to list view by Name",
            Description = "",
            Order = 200,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.XsltListViewWebPart)]
        [TestMethod]
        [TestCategory("Docs.XsltListViewWebPartDefinition")]
        public void CanBindXsltListViewWebPartByListViewTitle()
        {
            var booksLibrary = new ListDefinition
            {
                Title = "Books library",
                Description = "A document library.",
                TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
                CustomUrl = "BooksLibrary"
            };

            var booksView = new ListViewDefinition
            {
                Title = "Popular Books",
                Fields = new Collection<string>
                {
                    BuiltInInternalFieldNames.Edit,
                    BuiltInInternalFieldNames.ID,
                    BuiltInInternalFieldNames.FileLeafRef
                },
                RowLimit = 10
            };

            var xsltListView = new XsltListViewWebPartDefinition
            {
                Title = "Popular Books binding by List View Title",
                Id = "m2PopularBooksView",
                ZoneIndex = 10,
                ZoneId = "Main",
                ListUrl = booksLibrary.CustomUrl,
                ViewName = booksView.Title
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 Xslt List View provision",
                FileName = "xslt-listview-webpart-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                  .AddList(booksLibrary, list =>
                  {
                      list.AddListView(booksView);
                  })
                  .AddHostList(BuiltInListDefinitions.SitePages, list =>
                  {
                      list.AddWebPartPage(webPartPage, page =>
                      {
                          page.AddXsltListViewWebPart(xsltListView);
                      });
                  });
            });

            DeployModel(model);
        }

        #endregion
    }
}