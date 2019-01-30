---
id: "masterpagesettingsdefinition"
title: "MasterPageSettingsDefinition"
scenario_model: "Web model"
scenario_category: "Web"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Master page changes provision is enabled via MasterPageSettingsDefinition object.

Both CSOM/SSOM object models are supported. Provision updates SiteMasterPageUrl/SystemMasterPageUrl values of the a target web site. AddMasterPageSettings() extension method as per following examples.

SiteMasterPageUrl and SystemMasterPageUrl are promted to the target web site. Both should be site relative URLs, as follow:

* /_catalogs/masterpage/seattle.master
* /_catalogs/masterpage/oslo.master

BuiltInMasterPageDefinitions class could be used to refer OOTB master pages.

## Examples

### Add master page setting

```cs
// BuiltInMasterPageDefinitions class could be used to refer OOTB master pages
// BuiltInMasterPageDefinitions.Seattle
// BuiltInMasterPageDefinitions.Oslo
// BuiltInMasterPageDefinitions.Minimal
 
var masterPageSettings = new MasterPageSettingsDefinition
{
    // both should be site relative URLs
    SiteMasterPageUrl = "/_catalogs/masterpage/oslo.master",
    SystemMasterPageUrl = "/_catalogs/masterpage/oslo.master"
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddMasterPageSettings(masterPageSettings);
});
 
DeployModel(model);
```