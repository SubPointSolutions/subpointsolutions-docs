---
id: "removecontenttypefieldlinksdefinition"
title: "RemoveContentTypeFieldLinksDefinition"
scenario_model: "Web model"
scenario_category: "Content Types"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Removing fields inside a content type is enabled via RemoveContentTypeFieldLinksDefinition object.

Both CSOM/SSOM object models are supported. Provision removed field link inside the content type according the Fields property. You can deploy either single object or a set of the objects using AddRemoveContentTypeFieldLinks() extension method as per following examples.

## Examples

### Remove fields from content type

```cs
var customName = new TextFieldDefinition
{
    Title = "Custom Name",
    InternalName = "m2_CustomName",
    Group = "SPMeta2.Samples",
    Id = new Guid("8EE0C5C6-BD47-4111-9707-660B737F9F9B"),
};
 
var customObjectContentType = new ContentTypeDefinition
{
    Name = "SPMeta2 Custom Object",
    Id = new Guid("C6F60CBE-48AE-434D-955C-7A45DC32AD9A"),
    ParentContentTypeId = BuiltInContentTypeId.Item,
    Group = "SPMeta2.Samples"
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
     .AddField(customName)
     .AddContentType(customObjectContentType, contentType =>
     {
         contentType
             .AddContentTypeFieldLink(customName)
             .AddRemoveContentTypeFieldLinks(new RemoveContentTypeFieldLinksDefinition
             {
                 Fields = new List<FieldLinkValue>
                 {
                     new FieldLinkValue {Id = BuiltInFieldId.Title}
                 }
             });
     });
});
 
DeployModel(model);
```
