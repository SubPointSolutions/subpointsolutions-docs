---
id: "sp2013workflowsubscriptiondefinition"
title: "SP2013WorkflowSubscriptionDefinition"
scenario_model: "Web model"
scenario_category: "Workflows"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
SharePoint 2013 workflow binding to a web or list is enabled via SP2013WorkflowSubscriptionDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if object exists looking up it by Name property, then creates a new object. You can deploy either single object or a set of the objects using AddSP2013WorkflowSubscription() extension method as per following examples.

## Examples

### Add SP2013 workflow to web

```cs
var writeToHistoryListWorkflow = new SP2013WorkflowDefinition
{
    DisplayName = "SPMeta2 - Write to history list",
    Override = true,
    Xaml = WorkflowTemplates.WriteToHistoryListWorkflow
};
 
var taskList = new ListDefinition
{
    Title = "Write To History List Tasks",
    TemplateType = BuiltInListTemplateTypeId.Tasks,
    Url = "m2WriteToHistoryListTasks"
};
 
var historyList = new ListDefinition
{
    Title = "Write To History List History",
    TemplateType = BuiltInListTemplateTypeId.WorkflowHistory,
    Url = "m2WriteToHistoryListHistory"
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
      .AddSP2013Workflow(writeToHistoryListWorkflow)
      .AddList(historyList)
      .AddList(taskList)
      .AddSP2013WorkflowSubscription(new SP2013WorkflowSubscriptionDefinition
      {
          Name = "Write To History Web Workflow",
          WorkflowDisplayName = writeToHistoryListWorkflow.DisplayName,
          HistoryListUrl = historyList.GetListUrl(),
          TaskListUrl = taskList.GetListUrl()
      });
});
 
DeployModel(model);

```

### Add SP2013 workflow to list

```cs
var writeToHistoryListWorkflow = new SP2013WorkflowDefinition
{
    DisplayName = "SPMeta2 - Write to history list",
    Override = true,
    Xaml = WorkflowTemplates.WriteToHistoryListWorkflow
};
 
var taskList = new ListDefinition
{
    Title = "Workflow Enabled List Tasks",
    TemplateType = BuiltInListTemplateTypeId.Tasks,
    Url = "m2WorkflowEnabledListTasks"
};
 
var historyList = new ListDefinition
{
    Title = "Workflow Enabled List History",
    TemplateType = BuiltInListTemplateTypeId.WorkflowHistory,
    Url = "m2WorkflowEnabledListHistory"
};
 
var workflowEnabledList = new ListDefinition
{
    Title = "Workflow Enabled List",
    Description = "Workflow enabled list.",
    TemplateType = BuiltInListTemplateTypeId.GenericList,
    Url = "WorkflowEnabledList"
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddSP2013Workflow(writeToHistoryListWorkflow)
        .AddList(historyList)
        .AddList(taskList)
        .AddList(workflowEnabledList, list =>
        {
            list
                .AddSP2013WorkflowSubscription(new SP2013WorkflowSubscriptionDefinition
                {
                    Name = "Write To History List Workflow",
                    WorkflowDisplayName = writeToHistoryListWorkflow.DisplayName,
                    HistoryListUrl = historyList.GetListUrl(),
                    TaskListUrl = taskList.GetListUrl()
                });
        });
});
 
DeployModel(model);
```