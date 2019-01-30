---
id: "multichoicefielddefinition"
title: "MultiChoiceFieldDefinition"
scenario_model: "Web model"
scenario_category: "Fields"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Provision checks if field exists looking up it by Id/Name property, then creates a new field.

## Examples

### Add module file to Style Library
```cs
var fieldDef = new MultiChoiceFieldDefinition
{
    Title = "Tasks label",
    InternalName = "dcs_ProgressTag",
    Group = "SPMeta2.Samples",
    Id = new Guid("b08325aa-a750-4bf9-a73e-c470b86d37c8"),
    Choices = new Collection<string>
    {
        "internal",
        "external",
        "bug",
        "easy fix",
        "enhancement"
    }
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site.AddMultiChoiceField(fieldDef);
});
 
DeployModel(model);
```