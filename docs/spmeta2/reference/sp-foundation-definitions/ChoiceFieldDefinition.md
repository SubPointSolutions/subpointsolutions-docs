---
id: "choicefielddefinition"
title: "ChoiceFieldDefinition"
scenario_model: "Site collection model"
scenario_category: "Fields"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Provision checks if field exists looking up it by Id/Name property, then creates a new field.

## Examples

### Add choice field

```cs
var fieldDef = new ChoiceFieldDefinition
{
    Title = "Tasks status",
    InternalName = "dcs_ProgressStatus",
    Group = "SPMeta2.Samples",
    Id = new Guid("759f97a7-c26f-4dc3-b3fa-47250f168ba4"),
    Choices = new Collection<string>
    {
        "Not stated",
        "In progress",
        "Done"
    }
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site.AddChoiceField(fieldDef);
});
 
DeployModel(model);
```