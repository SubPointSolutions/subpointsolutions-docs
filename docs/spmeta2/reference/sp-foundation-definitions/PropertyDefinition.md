---
id: "propertydefinition"
title: "PropertyDefinition"
scenario_model: "Web model"
scenario_category: "Property Bags"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Property bag value provision is enabled via PropertyDefinition object.

Both CSOM/SSOM object models are supported. SSOM also supports farm and web application scopes. Provision updated a target property with given Key/Value pair. You can deploy either single mode or a set of the nodes using AddProperty() extension method as per following examples.

## Examples

### Add property to farm
```cs
var farmTag = new PropertyDefinition
{
    Key = "m2_farm_tag",
    Value = "m2_farm_tag_value",
};
 
var farmType = new PropertyDefinition
{
    Key = "m2_farm_type",
    Value = "m2_farm_type_value",
};
 
var model = SPMeta2Model.NewFarmModel(farm =>
{
    farm
        .AddProperty(farmTag)
        .AddProperty(farmType);
});
 
DeploySSOMModel(model);
```

### Add property to site

```cs
var siteTag = new PropertyDefinition
{
    Key = "m2_site_tag",
    Value = "m2_site_tag_value",
};
 
var siteType = new PropertyDefinition
{
    Key = "m2_site_type",
    Value = "m2_site_type_value",
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
        .AddProperty(siteTag)
        .AddProperty(siteType);
});
 
DeployModel(model);

```

### Add property to web
```cs
var webTag = new PropertyDefinition
{
    Key = "m2_web_tag",
    Value = "m2_web_tag_value",
};
 
var webType = new PropertyDefinition
{
    Key = "m2_web_type",
    Value = "m2_web_type_value",
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
     .AddProperty(webTag)
     .AddProperty(webType);
});
 
DeployModel(model);

```

### Add property to list

```cs
var listTag = new PropertyDefinition
{
    Key = "m2_list_tag",
    Value = "m2_list_tag_value",
};
 
var listType = new PropertyDefinition
{
    Key = "m2_web_type",
    Value = "m2_web_type_value",
};
 
var listWithProperties = new ListDefinition
{
    Title = "List with properties",
    Description = "List with some properties.",
    TemplateType = BuiltInListTemplateTypeId.GenericList,
    Url = "ListWithProperties"
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(listWithProperties, list =>
    {
        list
          .AddProperty(listTag)
          .AddProperty(listType);
    });
});
 
DeployModel(model);

```

### Add property to folder

```cs
var folderTag = new PropertyDefinition
{
    Key = "m2_folder_tag",
    Value = "m2_folder_tag_value",
};
 
var folderType = new PropertyDefinition
{
    Key = "m2_folder_type",
    Value = "m2_folder_type_value",
};
 
var listWithProperties = new ListDefinition
{
    Title = "List with properties",
    Description = "List with some properties.",
    TemplateType = BuiltInListTemplateTypeId.GenericList,
    Url = "ListWithProperties"
};
 
var fodlerWithProperties = new FolderDefinition
{
    Name = "folder with properties"
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(listWithProperties, list =>
    {
        list.AddFolder(fodlerWithProperties, folder =>
        {
            // Syntax miss - folder should support adding props #669
            // https://github.com/SubPointSolutions/spmeta2/issues/669
 
            //folder
            //    .AddProperty(folderTag)
            //    .AddProperty(folderType);
 
            folder
                .AddDefinitionNode(folderTag)
                .AddDefinitionNode(folderType);
        });
 
    });
});
 
DeployModel(model);
```