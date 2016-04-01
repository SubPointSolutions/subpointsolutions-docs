using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
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
    public class MasterPageDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
         Title = "Adding master page",
         Description = "",
         Order = 100,
         CatagoryAlias = SampleCategory.SharePointFoundation,
         GroupAlias = SampleGroups.MasterPageGallery)]

        [TestMethod]
        [TestCategory("Docs.MasterPageDefinition")]
        public void CanDeploySimpleMasterPageDefinition()
        {
            var masterPage = new MasterPageDefinition
            {
                Title = "M2 Oslo",
                FileName = "m2-oslo.master",
                // replace with your master page content
                Content = Encoding.UTF8.GetBytes(DefaultMasterPageTemplates.Oslo),
                NeedOverride = true
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.Catalogs.MasterPage, list =>
                {
                    list.AddMasterPage(masterPage);
                });
            });

            DeployModel(model);
        }

        #endregion
    }
}