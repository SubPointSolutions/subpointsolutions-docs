---
id: "securitygroupdefinition"
title: "SecurityGroupDefinition"
scenario_model: "Web model"
scenario_category: "Security"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes

Security group provision is enabled via SecurityGroupDefinition object.

Provision checks if object exists looking up it by Name property, then creates a new object. You can deploy either single object or a set of the objects using AddSecurityGroup() extension method as per following examples.

In some cases we need to refer to build-in SharePoint security groups, such as associated members, owners and visitors. That could be done with IsAssociatedMemberGroup, IsAssociatedOwnerGroup and IsAssociatedVisitorsGroup properties.

Once you define suc a group, provision does not do anything but uses these flags to pass them into SecurityGroupLinkDefinition while linking a security group with SharePoint web, list, item, folder or other securable object. Check SecurityGroupLinkDefinition for more samples on how to use IsAssociatedMemberGroup, IsAssociatedOwnerGroup and IsAssociatedVisitorsGroup properties.

## Examples

### Add security group

```cs
var auditors = new SecurityGroupDefinition
{
    Name = "External Auditors",
    Description = "External auditors group."
};
 
var reviewers = new SecurityGroupDefinition
{
    Name = "External Reviewers",
    Description = "External reviewers group."
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
        .AddSecurityGroup(auditors)
        .AddSecurityGroup(reviewers);
});
 
DeployModel(model);

```

### Add multiple security groups

```cs
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
        .AddSecurityGroup(DocSecurityGroups.ClientManagers)
        .AddSecurityGroup(DocSecurityGroups.ClientSupport)
        .AddSecurityGroup(DocSecurityGroups.Interns)
        .AddSecurityGroup(DocSecurityGroups.OrderApprovers);
});
 
DeployModel(model);
```