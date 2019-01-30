---
id: "contenttypedefinition"
title: "ContentTypeDefinition"
scenario_model: "Site collection model"
scenario_category: "Content Types"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web

## Notes
Content type provision is enabled via ContentTypeDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if content type exists by the content type ID, then creates a new conten type. You can deploy either single content type or a set using AddContentType() extension method as per following examples.

## Examples

### Add item content type


```cs
var listContentType = new ContentTypeDefinition
{
    Name = "Custom list item",
    Id = new Guid("79658c1e-3096-4c44-bd55-4228d01a5b97"),
    ParentContentTypeId = BuiltInContentTypeId.Item,
    Group = "SPMeta2.Samples"
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
       .AddContentType(listContentType);
});
 
DeployModel(model);

```

### Add document content type

```cs
var documentContentType = new ContentTypeDefinition
{
    Name = "Custom document",
    Id = new Guid("008e7c50-a271-4fcd-9f01-f18daad5bd7e"),
    ParentContentTypeId = BuiltInContentTypeId.Document,
    Group = "SPMeta2.Samples"
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
       .AddContentType(documentContentType);
});
 
DeployModel(model);
```

### Add document set content type

```cs
var documentContentType = new ContentTypeDefinition
{
    Name = "Custom document set",
    Id = new Guid("AAC93B98-F776-4D5C-9E6E-66F2DC45A467"),
    ParentContentTypeId = BuiltInContentTypeId.DocumentSet_Correct,
    Group = "SPMeta2.Samples"
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
       .AddContentType(documentContentType);
});
 
DeployModel(model);
```

### Add several content types


```cs
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
       .AddContentType(DocContentTypes.CustomerAccount)
       .AddContentType(DocContentTypes.CustomerDocument);
});
 
DeployModel(model);

```

### Add content type with fields

```cs
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
        .AddField(DocFields.Clients.ClientCredit)
        .AddField(DocFields.Clients.ClientDebit)
        .AddField(DocFields.Clients.ClientDescription)
        .AddField(DocFields.Clients.ClientNumber)
        .AddField(DocFields.Clients.ClientWebSite)
 
       .AddContentType(DocContentTypes.CustomerAccount, contentType =>
       {
           contentType
             .AddContentTypeFieldLink(DocFields.Clients.ClientCredit)
             .AddContentTypeFieldLink(DocFields.Clients.ClientDebit)
             .AddContentTypeFieldLink(DocFields.Clients.ClientWebSite);
       })
       .AddContentType(DocContentTypes.CustomerDocument, contentType =>
       {
           contentType
              .AddContentTypeFieldLink(DocFields.Clients.ClientDescription)
              .AddContentTypeFieldLink(DocFields.Clients.ClientNumber);
       });
});
 
DeployModel(model);

```

### Add parent-child content types


```cs
var rootDocumentContentType = new ContentTypeDefinition
{
    Name = "A root document",
    Id = new Guid("b0ec3794-8bf3-49ed-b8d1-24a4df5ac75b"),
    ParentContentTypeId = BuiltInContentTypeId.Document,
    Group = "SPMeta2.Samples"
};
 
var childDocumentContentType = new ContentTypeDefinition
{
    Name = "A child document",
    Id = new Guid("84ab43ee-1f9d-4436-a9de-868bd7a36400"),
    // use GetContentTypeId() to get the content type ID and refer as a parent ID
    ParentContentTypeId = rootDocumentContentType.GetContentTypeId(),
    Group = "SPMeta2.Samples"
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
       .AddContentType(rootDocumentContentType)
       .AddContentType(childDocumentContentType);
});
 
DeployModel(model);

```