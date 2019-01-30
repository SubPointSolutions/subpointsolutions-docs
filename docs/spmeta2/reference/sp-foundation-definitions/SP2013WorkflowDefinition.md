---
id: "sp2013workflowdefinition"
title: "SP2013WorkflowDefinition"
scenario_model: "Web model"
scenario_category: "Workflows"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes

SharePoint 2013 workflow provision is enabled via SP2013WorkflowDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if object exists looking up it by DisplayName property, then creates a new object. You can deploy either single object or a set of the objects using AddSP2013Workflow() extension method as per following examples

## Examples

### Add SP2013 workflow

```cs
var writeToHistoryLstWorkflow = new SP2013WorkflowDefinition
{
    DisplayName = "SPMeta2 - Write to history list",
    Override = true,
    Xaml = WorkflowTemplates.WriteToHistoryListWorkflow
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddSP2013Workflow(writeToHistoryLstWorkflow);
});
 
DeployModel(model);
```