---
id: "breakroleinheritancedefinition"
title: "BreakRoleInheritanceDefinition"
scenario_model: "Web model"
scenario_category: "Security"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Web, List, Folder, ListItem

## Notes
Break role inheritance operations over securable SharePoint objects are implemented with BreakRoleInheritanceDefinition.

BreakRoleInheritanceDefinition maps out SPSecurableObject.BreakRoleInheritance() method call. Properties CopyRoleAssignments and ClearSubscopes get passed to CSOM/SSOM .BreakRoleInheritance() method.

Additional property ForceClearSubscopes is introduced by SPMeta2. The property forces SPMeta2 to clear .RoleAssignments collection every provision.

Note that .AddBreakRoleInheritance() syntax passes the object on which the method was called. For instance, for list, you would get the list wihtin AddBreakRoleInheritance() as following: list.AddBreakRoleInheritance(list => {} )

For web, you would get the web wihtin AddResetRoleInheritance() as following: web.AddBreakRoleInheritance(web => {} )

## Examples

### Break role inheritance on web

```cs
var privateProjectWebDef = new WebDefinition
{
    Title = "Private project",
    Url = "private-project",
    WebTemplate = BuiltInWebTemplates.Collaboration.TeamSite
};
 
var privateProjectWebBreakRoleInheritance = new BreakRoleInheritanceDefinition
{
    CopyRoleAssignments = false
};
 
var privateSecurityGroupMembers = new SecurityGroupDefinition
{
    Name = "Private Project Group Members"
};
 
var privateSecurityGroupViewers = new SecurityGroupDefinition
{
    Name = "Private Project Group Viewers"
};
 
// site model with the groups
var siteModel = SPMeta2Model.NewSiteModel(site =>
           {
   site.AddSecurityGroup(privateSecurityGroupMembers);
   site.AddSecurityGroup(privateSecurityGroupViewers);
);
 
// web model
var webModel = SPMeta2Model.NewWebModel(web =>
{
    web.AddWeb(privateProjectWebDef, publicProjectWeb =>
    {
        publicProjectWeb.AddBreakRoleInheritance(privateProjectWebBreakRoleInheritance, privateProjectResetWeb =>
        {
            // privateProjectResetWeb is your web but after breaking role inheritance
 
            // link group with roles by SecurityRoleType / SecurityRoleName
            // use BuiltInSecurityRoleTypes or BuiltInSecurityRoleNames
 
            // add group with contributor permission
            privateProjectResetWeb.AddSecurityGroupLink(privateSecurityGroupMembers, group =>
            {
                group.AddSecurityRoleLink(new SecurityRoleLinkDefinition
                {
                    SecurityRoleType = BuiltInSecurityRoleTypes.Contributor
                });
            });
 
            // add group with reader permission
            privateProjectResetWeb.AddSecurityGroupLink(privateSecurityGroupViewers, group =>
            {
                group.AddSecurityRoleLink(new SecurityRoleLinkDefinition
                {
                    SecurityRoleType = BuiltInSecurityRoleTypes.Reader
                });
            });
        });
    });
});
 
// deploy site model with groups, and then web model with the rest
DeployModel(siteModel);
DeployModel(webModel);

```

### Break role inheritance on list

```cs
var privateListDef = new ListDefinition
{
    Title = "Private records",
    TemplateType = BuiltInListTemplateTypeId.GenericList,
    CustomUrl = "lists/private-records",
};
 
var privateProjectWebBreakRoleInheritance = new BreakRoleInheritanceDefinition
{
    CopyRoleAssignments = false
};
 
var privateSecurityGroupMembers = new SecurityGroupDefinition
{
    Name = "Private Project Group Members"
};
 
var privateSecurityGroupViewers = new SecurityGroupDefinition
{
    Name = "Private Project Group Viewers"
};
 
// site model with the groups
var siteModel = SPMeta2Model.NewSiteModel(site =>
{
    site.AddSecurityGroup(privateSecurityGroupMembers);
    site.AddSecurityGroup(privateSecurityGroupViewers);
});
 
// web model
var webModel = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(privateListDef, publicProjectWeb =>
    {
        publicProjectWeb.AddBreakRoleInheritance(privateProjectWebBreakRoleInheritance, privateResetList =>
        {
            // privateResetList is your list but after breaking role inheritance
 
            // link group with roles by SecurityRoleType / SecurityRoleName
            // use BuiltInSecurityRoleTypes or BuiltInSecurityRoleNames
 
            // add group with contributor permission
            privateResetList.AddSecurityGroupLink(privateSecurityGroupMembers, group =>
            {
                group.AddSecurityRoleLink(new SecurityRoleLinkDefinition
                {
                    SecurityRoleType = BuiltInSecurityRoleTypes.Contributor
                });
            });
 
            // add group with reader permission
            privateResetList.AddSecurityGroupLink(privateSecurityGroupViewers, group =>
            {
                group.AddSecurityRoleLink(new SecurityRoleLinkDefinition
                {
                    SecurityRoleType = BuiltInSecurityRoleTypes.Reader
                });
            });
        });
    });
});
 
// deploy site model with groups, and then web model with the rest
DeployModel(siteModel);
DeployModel(webModel);
```