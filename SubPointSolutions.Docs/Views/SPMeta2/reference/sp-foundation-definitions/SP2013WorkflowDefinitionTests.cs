using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;


using SubPointSolutions.Docs.Code.Resources;
using System.ComponentModel;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]

    [Category("Category=Web Model/SharePoint 2013 workflow")]

    //[Browsable(false)]
    public class SP2013WorkflowDefinitionTests : ProvisionTestBase
    {
        #region methods

        
        [TestMethod]
        [TestCategory("Docs.SP2013WorkflowDefinition")]

        [DisplayName("Add SP2013 workflow")]
        //[Browsable(false)]
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