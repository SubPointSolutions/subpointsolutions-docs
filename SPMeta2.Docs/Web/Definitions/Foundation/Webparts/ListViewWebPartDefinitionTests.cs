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
    public class ListViewWebPartDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
            Title = "Binding to list by Title",
            Description = "",
            Order = 100,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.ListViewWebPart)]
        [TestMethod]
        [TestCategory("Docs.ListViewWebPartDefinition")]
        public void CanBindListViewWebPartByListTitle()
        {
            var travelRequests = new ListDefinition
            {
                Title = "Travel Requests",
                Description = "A document library.",
                TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
                CustomUrl = "m2TravelRequests"
            };

            var listView = new ListViewWebPartDefinition
            {
                Title = "Travel Request Default View by List Title",
                Id = "m2TravelRequestsView",
                ZoneIndex = 10,
                ZoneId = "Main",
                ListTitle = travelRequests.Title
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 List View provision",
                FileName = "listview-webpart-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                  .AddList(travelRequests)
                  .AddHostList(BuiltInListDefinitions.SitePages, list =>
                  {
                      list.AddWebPartPage(webPartPage, page =>
                      {
                          page.AddListViewWebPart(listView);
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
            GroupAlias = SampleGroups.ListViewWebPart)]
        [TestMethod]
        [TestCategory("Docs.ListViewWebPartDefinition")]
        public void CanBindListViewWebPartByListUrl()
        {
            var annualReviewsLibrary = new ListDefinition
            {
                Title = "Annual Reviews",
                Description = "A document library.",
                TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
                CustomUrl = "m2AnnualReviews"
            };

            var listView = new ListViewWebPartDefinition
            {
                Title = "Annual Reviews Default View by List Url",
                Id = "m2AnnualReviewsView",
                ZoneIndex = 10,
                ZoneId = "Main",
                ListUrl = annualReviewsLibrary.CustomUrl
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 List View provision",
                FileName = "listview-webpart-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                  .AddList(annualReviewsLibrary)
                  .AddHostList(BuiltInListDefinitions.SitePages, list =>
                  {
                      list.AddWebPartPage(webPartPage, page =>
                      {
                          page.AddListViewWebPart(listView);
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
            GroupAlias = SampleGroups.ListViewWebPart)]
        [TestMethod]
        [TestCategory("Docs.ListViewWebPartDefinition")]
        public void CanBindListViewWebPartByListViewTitle()
        {
            var incidentsLibrary = new ListDefinition
            {
                Title = "Incidents library",
                Description = "A document library.",
                TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
                CustomUrl = "m2Incidents"
            };

            var incidentsView = new ListViewDefinition
            {
                Title = "Last Incidents",
                Fields = new Collection<string>
                {
                    BuiltInInternalFieldNames.Edit,
                    BuiltInInternalFieldNames.ID,
                    BuiltInInternalFieldNames.FileLeafRef
                },
                RowLimit = 10
            };

            var listView = new ListViewWebPartDefinition
            {
                Title = "Last Incidents binding by List View Title",
                Id = "m2LastIncidentsView",
                ZoneIndex = 10,
                ZoneId = "Main",
                ListUrl = incidentsLibrary.CustomUrl,
                ViewName = incidentsView.Title
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 List View provision",
                FileName = "listview-webpart-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                  .AddList(incidentsLibrary, list =>
                  {
                      list.AddListView(incidentsView);
                  })
                  .AddHostList(BuiltInListDefinitions.SitePages, list =>
                  {
                      list.AddWebPartPage(webPartPage, page =>
                      {
                          page.AddListViewWebPart(listView);
                      });
                  });
            });

            DeployModel(model);
        }

        [SampleMetadata(
            Title = "Binding to calendar view",
            Description = "",
            Order = 200,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.ListViewWebPart)]
        [TestMethod]
        [TestCategory("Docs.ListViewWebPartDefinition")]
        public void CanBindListViewWebPartToCalendarView()
        {
            var companyEvents = new ListDefinition
            {
                Title = "Company Events",
                Description = "A document library.",
                TemplateType = BuiltInListTemplateTypeId.Events,
                CustomUrl = "m2CompanyEvents"
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 List View provision",
                FileName = "listview-webpart-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var listView = new ListViewWebPartDefinition
            {
                Title = "Company Events by List View Title",
                Id = "m2CompanyEvents",
                ZoneIndex = 10,
                ZoneId = "Main",
                ListUrl = companyEvents.CustomUrl,
                ViewName = "Calendar"
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                  .AddList(companyEvents)
                  .AddHostList(BuiltInListDefinitions.SitePages, list =>
                  {
                      list.AddWebPartPage(webPartPage, page =>
                      {
                          page.AddListViewWebPart(listView);
                      });
                  });
            });

            DeployModel(model);
        }

        #endregion
    }
}