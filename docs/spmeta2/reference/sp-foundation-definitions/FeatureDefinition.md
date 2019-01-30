---
id: "featuredefinition"
title: "FeatureDefinition"
scenario_model: "Farm model"
scenario_category: "Features"
---

## API support
[+] SSOM [-] CSOM

## Can be deployed under
Farm

## Notes
Feature activation/deactivation is enabled via FeatureDefinition object.

Both CSOM/SSOM object models are supported, except webapp/farm features could be deployed only with SSOM object model.

Provision looks up feature by ID and acts according feature definition properties Enable/ForceActivate.

Enable suggest to enable feature if it was not activated, but skip if it is activates. ForceActivate flag allows to force activate feature despite of current state. You can deploy either single feature or a set using AddWebFeature() extension method.

## Examples

### Activate OOTB site features

```cs
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
        .AddSiteFeature(DocSiteFeatures.SitePublisingInfrastructure)
        .AddSiteFeature(DocSiteFeatures.DocumentSets);
 
});
 
DeployModel(model);
```

### Activate OOTB web features

```cs
var model = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddWebFeature(DocWebFeatures.WebPublishingInfrastructure)
        .AddWebFeature(DocWebFeatures.MetadataNavigationAndFiltering)
        .AddWebFeature(DocWebFeatures.MDS);
 
});
 
DeployModel(model);
```

### Disable OOTB web features

```cs
var model = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddWebFeature(DocWebFeatures.Disable.MDS);
});
 
DeployModel(model);
```

### Activate custom web features

```cs
var myCustomerFeature = new FeatureDefinition
{
    Enable = true,
    Id = new Guid("87294C72-F260-42f3-A41B-981A2FFCE37A"),
    Scope = FeatureDefinitionScope.Web
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddWebFeature(myCustomerFeature);
});
 
DeployModel(model);
```

### Disable custom web features


```cs
var myCustomerFeature = new FeatureDefinition
{
    Enable = false,
    Id = new Guid("87294C72-F260-42f3-A41B-981A2FFCE37A"),
    Scope = FeatureDefinitionScope.Web
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddWebFeature(myCustomerFeature);
});
 
DeployModel(model);
```

### Inherit OOTB features


```cs
var enableMinimalDownloadStrategy = BuiltInWebFeatures.MinimalDownloadStrategy.Inherit(def =>
{
    def.Enable = true;
});
 
var disableMinimalDownloadStrategy = BuiltInWebFeatures.MinimalDownloadStrategy.Inherit(def =>
{
    def.Enable = false;
});
 
// enable MDS
var enableMdsModel = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddWebFeature(enableMinimalDownloadStrategy);
});
 
DeployModel(enableMdsModel);
 
// disable MDS
var model = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddWebFeature(disableMinimalDownloadStrategy);
});
 
DeployModel(model);
```