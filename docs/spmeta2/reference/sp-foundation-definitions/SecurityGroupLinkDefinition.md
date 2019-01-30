---
id: "securitygrouplinkdefinition"
title: "SecurityGroupLinkDefinition"
scenario_model: "Web model"
scenario_category: "Security"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes

Linking security groups to webs, lists, folders and items is enables via SecurityGroupLinkDefinition.

Provision checks if the security group was linked with the current securable object optionaly breaking or force clearing role inheritance.

## Examples

### Assign security group to web

```cs
var auditors = new SecurityGroupDefinition
{
    Name = "External Auditors",
    Description = "External auditors group."
};
 
// add group to the site first
var siteModel = SPMeta2Model.NewSiteModel(site =>
{
    site.AddSecurityGroup(auditors);
});
 
// assign group to the web, via .AddSecurityGroupLink() method
var webModel = SPMeta2Model.NewWebModel(web =>
{
 
    web.AddSecurityGroupLink(auditors);
});
 
DeployModel(siteModel);
DeployModel(webModel);

```

### Assign security group to list

```cs
var auditors = new SecurityGroupDefinition
{
    Name = "External Auditors",
    Description = "External auditors group."
};
 
var auditorsList = new ListDefinition
{
    Title = "Auditors documents",
    TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
    CustomUrl = "audit-docs"
};
 
// add group to the site first
var siteModel = SPMeta2Model.NewSiteModel(site =>
{
    site.AddSecurityGroup(auditors);
});
 
// assign group to the list, via .AddSecurityGroupLink() method
var webModel = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(auditorsList, list =>
    {
        list.AddSecurityGroupLink(auditors);
    });
});
 
DeployModel(siteModel);
DeployModel(webModel);
```