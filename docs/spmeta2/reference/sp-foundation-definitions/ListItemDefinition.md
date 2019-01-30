---
id: "listitemdefinition"
title: "ListItemDefinition"
scenario_model: "Web model"
scenario_category: "Lists and Libraries"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
List item provision is enabled via ListItemDefinition object.

## Examples

### Add list item

```cs
var listDef = new ListDefinition
{
    Title = "Customers",
    TemplateType = BuiltInListTemplateTypeId.GenericList,
    CustomUrl = "lists/customers",
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(listDef, list =>
    {
        list
            .AddListItem(new ListItemDefinition { Title = "Microsoft" })
            .AddListItem(new ListItemDefinition { Title = "Apple" })
            .AddListItem(new ListItemDefinition { Title = "IBM" });
    });
});
 
DeployModel(model);
```