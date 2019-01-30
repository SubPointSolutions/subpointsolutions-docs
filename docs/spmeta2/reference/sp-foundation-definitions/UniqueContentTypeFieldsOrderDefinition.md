---
id: "uniquecontenttypefieldsorderdefinition"
title: "UniqueContentTypeFieldsOrderDefinition"
scenario_model: "Web model"
scenario_category: "Content Types"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Fields re-ordering inside a content type is enabled via UniqueContentTypeFieldsOrderDefinition object.

Both CSOM/SSOM object models are supported. Provision re-orders field links inside the content type according the Fields property. You can deploy either single object or a set of the objects using AddUniqueContentTypeFieldsOrder() extension method as per following examples.

## Examples

### Reorder content type fields

```cs
var debitField = new NumberFieldDefinition
{
    Title = "Debit",
    InternalName = "m2_MDebit",
    Group = "SPMeta2.Samples",
    Id = new Guid("2901EA31-CB32-4EE7-8482-9354C843F264"),
};
 
var creditField = new NumberFieldDefinition
{
    Title = "Credit",
    InternalName = "m2_MCredit",
    Group = "SPMeta2.Samples",
    Id = new Guid("2F62D945-AFF8-4ACF-B090-4BB5A8FB13C9"),
};
 
var totalField = new NumberFieldDefinition
{
    Title = "Total",
    InternalName = "m2_MTotal",
    Group = "SPMeta2.Samples",
    Id = new Guid("07D7B101-3F95-4413-B5D0-0EAA75E31697"),
};
 
var balanceContentType = new ContentTypeDefinition
{
    Name = "SPMeta2 Balance",
    Id = new Guid("1861F08E-4E76-4DA3-9CE9-842B481FD0DA"),
    ParentContentTypeId = BuiltInContentTypeId.Item,
    Group = "SPMeta2.Samples"
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
        .AddField(debitField)
        .AddField(creditField)
        .AddField(totalField)
        .AddContentType(balanceContentType, contentType =>
        {
            contentType
                .AddContentTypeFieldLink(totalField)
                .AddContentTypeFieldLink(debitField)
                .AddContentTypeFieldLink(creditField)
                .AddUniqueContentTypeFieldsOrder(new UniqueContentTypeFieldsOrderDefinition
                {
                    Fields = new List<FieldLinkValue>
                    {
                        new FieldLinkValue{ Id = BuiltInFieldId.Title },
                        new FieldLinkValue{ Id = creditField.Id },
                        new FieldLinkValue{ Id = debitField.Id },
                        new FieldLinkValue{ Id = totalField.Id }
                    }
                });
        });
});
 
DeployModel(model);
```