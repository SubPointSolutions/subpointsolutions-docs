using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;
using SubPointSolutions.Docs.Code.Enumerations;
using SubPointSolutions.Docs.Code.Metadata;
using System;
using System.ComponentModel;
using System.IO;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    

   [Category("Category=Farm Model/Farm")]


    //[Browsable(false)]
    public class FarmSolutionDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.FarmSolutionDefinition")]

        [DisplayName("Add farm solution")]
        //[Browsable(false)]
        public void CanDeploySimpleFarmSolutionDefinition()
        {
            var solutionDef = new FarmSolutionDefinition
            {
                FileName = "your-solution-file.wsp",
                SolutionId = new Guid("your-solution-id"),
                Content = File.ReadAllBytes("path-to-your-solution-or-byte-array")
            };

            var model = SPMeta2Model.NewFarmModel(farm =>
            {
                farm.AddFarmSolution(solutionDef);
            });

            DeployModel(model);
        }

        #endregion
    }
}