using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;
using SubPointSolutions.Docs.Code.Enumerations;
using SubPointSolutions.Docs.Code.Metadata;
using System.ComponentModel;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]

    [Category("Category=Web Model/Web site")]
    //[Browsable(false)]
    public class TreeViewSettingsDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.TreeViewSettingsDefinition")]

        [DisplayName("Add tree view settings to web")]
        //[Browsable(false)]
        public void CanDeploySimpleTreeViewSettingsDefinition()
        {
            var treeViewSettings = new TreeViewSettingsDefinition
            {
                TreeViewEnabled = true,
                QuickLaunchEnabled = true
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddTreeViewSettings(treeViewSettings);
            });

            DeployModel(model);
        }

        #endregion
    }
}