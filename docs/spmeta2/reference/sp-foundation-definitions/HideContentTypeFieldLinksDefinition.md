---
id: "hidecontenttypefieldlinksdefinition"
title: "HideContentTypeFieldLinksDefinition"
scenario_model: "Site Collection model"
scenario_category: "Content Types"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Hiding fields inside a content type is enabled via HideContentTypeFieldLinksDefinition object.

Both CSOM/SSOM object models are supported. Provision makes fields non-required and hide them inside the content type according the Fields property. You can deploy either single object or a set of the objects using AddHideContentTypeFieldLinks() extension method as per following examples.

## Examples

### Reorder content type fields

```cs
var hiddenNotesField = new NoteFieldDefinition
{
    Title = "Hidden Notes",
    InternalName = "m2_HiddenNotes",
    Group = "SPMeta2.Samples",
    Id = new Guid("13C47F4C-F3BA-431E-A76B-FCC03FED4E9B"),
};
 
var publicNotesField = new NoteFieldDefinition
{
    Title = "Publis Notes",
    InternalName = "m2_PublicNotes",
    Group = "SPMeta2.Samples",
    Id = new Guid("BACEE8AA-90B4-4268-8257-EEA0706942E4"),
};
 
var hiddenNotesContentType = new ContentTypeDefinition
{
    Name = "SPMeta2 Hidden Notes",
    Id = new Guid("1166D859-CC4B-4A5F-A1F3-28BE508C5A92"),
    ParentContentTypeId = BuiltInContentTypeId.Item,
    Group = "SPMeta2.Samples"
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
        .AddField(hiddenNotesField)
        .AddField(publicNotesField)
        .AddContentType(hiddenNotesContentType, contentType =>
        {
            contentType
                .AddContentTypeFieldLink(hiddenNotesField)
                .AddContentTypeFieldLink(publicNotesField)
                .AddHideContentTypeFieldLinks(new HideContentTypeFieldLinksDefinition
                {
                    Fields = new List<FieldLinkValue>
                    {
                       new FieldLinkValue{ Id = BuiltInFieldId.Title },
                       new FieldLinkValue{ Id = hiddenNotesField.Id }
                    }
                });
        });
});
 
DeployModel(model);
```