---
id: "securityroledefinition"
title: "SecurityRoleDefinition"
scenario_model: "Web model"
scenario_category: "Security"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes

Security role provision is enabled via SecurityRoleDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if object exists looking up it by Name property, then creates a new object. You can deploy either single object or a set of the objects using AddSecurityRole() extension method as per following examples.

## Examples

### Add security role

```cs
var customerEditors = new SecurityRoleDefinition
{
    Name = "Customer editors",
    BasePermissions = new Collection<string>
    {
        BuiltInBasePermissions.EditListItems,
        BuiltInBasePermissions.UseClientIntegration
    }
};
 
var customerApprovers = new SecurityRoleDefinition
{
    Name = "Customer approvers",
    BasePermissions = new Collection<string>
    {
        BuiltInBasePermissions.EditListItems,
        BuiltInBasePermissions.DeleteListItems,
        BuiltInBasePermissions.UseClientIntegration
    }
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
        .AddSecurityRole(customerEditors)
        .AddSecurityRole(customerApprovers);
});
 
DeployModel(model);
```