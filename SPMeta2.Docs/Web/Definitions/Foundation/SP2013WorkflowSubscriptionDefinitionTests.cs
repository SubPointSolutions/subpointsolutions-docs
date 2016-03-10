using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.CSOM.DefaultSyntax;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Attributes;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Consts;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Docs.Resources;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class SP2013WorkflowSubscriptionDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
         Title = "Binding workflow to web",
         Description = "",
         Order = 200,
         CatagoryAlias = SampleCategory.SharePointFoundation,
         GroupAlias = SampleGroups.SharePoint2013Workflow)]
        [TestMethod]
        [TestCategory("Docs.SP2013WorkflowSubscriptionDefinition")]
        public void CanDeploySimpleSP2013WorkflowSubscriptionToWeb()
        {
            var writeToHistoryListWorkflow = new SP2013WorkflowDefinition
            {
                DisplayName = "M2 - Write to history list",
                Override = true,
                Xaml = WorkflowTemplates.WriteToHistoryListWorkflow
            };

            var taskList = new ListDefinition
            {
                Title = "Write To History List Tasks",
                TemplateType = BuiltInListTemplateTypeId.Tasks,
                CustomUrl = "m2WriteToHistoryListTasks"
            };

            var historyList = new ListDefinition
            {
                Title = "Write To History List History",
                TemplateType = BuiltInListTemplateTypeId.WorkflowHistory,
                CustomUrl = "m2WriteToHistoryListHistory"
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
                      HistoryListUrl = historyList.CustomUrl,
                      TaskListUrl = taskList.CustomUrl
                  });
            });

            DeployModel(model);
        }

        [SampleMetadata(
           Title = "Binding workflow to list",
           Description = "",
           Order = 250,
           CatagoryAlias = SampleCategory.SharePointFoundation,
           GroupAlias = SampleGroups.SharePoint2013Workflow)]
        [TestMethod]
        [TestCategory("Docs.SP2013WorkflowSubscriptionDefinition")]
        public void CanDeploySimpleSP2013WorkflowSubscriptionToList()
        {
            var writeToHistoryListWorkflow = new SP2013WorkflowDefinition
            {
                DisplayName = "M2 - Write to history list",
                Override = true,
                Xaml = WorkflowTemplates.WriteToHistoryListWorkflow
            };

            var taskList = new ListDefinition
            {
                Title = "Workflow Enabled List Tasks",
                TemplateType = BuiltInListTemplateTypeId.Tasks,
                CustomUrl = "m2WorkflowEnabledListTasks"
            };

            var historyList = new ListDefinition
            {
                Title = "Workflow Enabled List History",
                TemplateType = BuiltInListTemplateTypeId.WorkflowHistory,
                CustomUrl = "m2WorkflowEnabledListHistory"
            };

            var workflowEnabledList = new ListDefinition
            {
                Title = "Workflow Enabled List",
                Description = "Workflow enabled list.",
                TemplateType = BuiltInListTemplateTypeId.GenericList,
                CustomUrl = "WorkflowEnabledList"
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
                                HistoryListUrl = historyList.CustomUrl,
                                TaskListUrl = taskList.CustomUrl
                            });
                    });
            });

            DeployModel(model);
        }

        #endregion
    }
}