---
id: "sandboxsolutiondefinition"
title: "SandboxSolutionDefinition"
scenario_model: "Web model"
scenario_category: "Site Collection"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes

Sandbox solution provision is enabled via SandboxSolutionDefinition object.

Both CSOM/SSOM object models are supported. 
Provision checks if object exists looking up it by SolutionId property, then deletes or upload a new object. 
You can deploy either single object or a set of the objects using AddSandboxSolution() extension method as per following examples.

Here are a few things you need to keep in mind:

* CSOM uses DesignPackage API
* **FileName** must not have "." - DesignPackage API fails to remove file with "."
* **SolutionId** must be set, it is used to lookup existing package
* **Content** is a byte array, so get it from whatver you wish - local folder or assembly resource
* **Activate** must be 'True' for CSOM - DesignPackage API limition

## Examples

### Add sandbox solution

```cs
// FileName could be different to the original solution name
// FileName must not have "." to avoid fails (DesignPackage API limitations)
 
// Content is a byte array, so get ot from whatever source you want
 
// SolutionId is used to lookup existing sandbox package
// get SolutionId from the VS project or XML inside WSP package
 
// Activate must be always true for CSOM (DesignPackage API limitations)
 
var myBranding = new SandboxSolutionDefinition
{
    FileName = "MyBranding.wsp",
    Content = File.ReadAllBytes("MySandboxBranding.wsp"),
    SolutionId = new Guid("0CDCC076-A472-4DD9-9A1F-0E1E761ED61D"),
    Activate = true,
};
 
var myTasks = new SandboxSolutionDefinition
{
    FileName = "MyTasks.wsp",
    Content = ModuleFileUtils.FromResource(GetType().Assembly, "MyIntranet.Resources.MyTasks.wsp"),
    SolutionId = new Guid("3D279748-92FC-49F9-A6C5-A10FBCD2DB24"),
    Activate = true,
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
      .AddSandboxSolution(myBranding)
      .AddSandboxSolution(myTasks);
});
 
DeployModel(model);
```