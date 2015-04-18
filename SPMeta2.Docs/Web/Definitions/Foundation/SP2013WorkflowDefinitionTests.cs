using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Attributes;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Consts;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Docs.Resources;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class SP2013WorkflowDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
         Title = "Adding workflow",
         Description = "",
         Order = 50,
         CatagoryAlias = SampleCategory.SharePointFoundation,
         GroupAlias = SampleGroups.SharePoint2013Workflow)]

        [TestMethod]
        [TestCategory("Docs.SP2013WorkflowDefinition")]
        public void CanDeploySimpleSP2013WorkflowDefinition()
        {
            var writeToHistoryLstWorkflow = new SP2013WorkflowDefinition
            {
                DisplayName = "M2 - Write to history list",
                Override = true,
                Xaml = WorkflowTemplates.WriteToHistoryListWorkflow
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddSP2013Workflow(writeToHistoryLstWorkflow);
            });

            DeployModel(model);
        }

        #endregion
    }
}