---
id: "listviewdefinition"
title: "ListViewDefinition"
scenario_model: "Web model"
scenario_category: "List Views"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
List view provision is enabled via ListViewDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if list view exists looking up it by Url property, then by Title, and the creates a new list definition. You can deploy either single list view or a set of the list views using AddListView() extension method as per following examples.

## Examples

### Add list view

```cs
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
    Url = "CustomerDocuments"
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


```

### Add list view with URL
```cs
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
    Url = "CustomerDocuments"
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(documentLibrary, list =>
    {
        list.AddListView(returnedDocuments);
    });
});
 
DeployModel(model);


```

### Add list view with CAML

```cs
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
    Url = "CustomerDocuments"
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

```