---
id: "xsltlistviewwebpartdefinition"
title: "XsltListViewWebPartDefinition"
scenario_model: "Web model"
scenario_category: "Web Parts"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
XsltListViewWebPart provision is enabled via XsltListViewWebPartDefinition object.

Both CSOM/SSOM object models are supported. You can deploy either single object or a set of the objects using AddXsltListViewWebPart() extension method as per following examples

## Examples

### Add XLVWP binded to list by Title

```cs
var inventoryLibrary = new ListDefinition
{
    Title = "Inventory library",
    Description = "A document library.",
    TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
    Url = "InventoryLibrary"
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
    Title = "SPMeta2 Xslt List View provision",
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

```

### Add XLVWP binded to list by URL

```cs
var booksLibrary = new ListDefinition
{
    Title = "Books library",
    Description = "A document library.",
    TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
    Url = "BooksLibrary"
};
 
var xsltListView = new XsltListViewWebPartDefinition
{
    Title = "Books Default View by List Url",
    Id = "m2BooksView",
    ZoneIndex = 10,
    ZoneId = "Main",
    ListUrl = booksLibrary.GetListUrl()
};
 
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 Xslt List View provision",
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

```

### Add XLVWP binded to list view by Title

```cs
var booksLibrary = new ListDefinition
{
    Title = "Books library",
    Description = "A document library.",
    TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
    Url = "BooksLibrary"
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
    ListUrl = booksLibrary.GetListUrl(),
    ViewName = booksView.Title
};
 
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 Xslt List View provision",
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
```