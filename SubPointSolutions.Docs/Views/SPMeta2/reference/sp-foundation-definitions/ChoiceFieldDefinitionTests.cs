using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions.Fields;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;


using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]

    [Category("Category=Site Collection Model/Fields")]

    //[Browsable(false)]
    public class ChoiceFieldDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.ChoiceFieldDefinition")]

        [DisplayName("Add choice field")]
        //[Browsable(false)]
        public void CanDeploySimpleChoiceFieldDefinition()
        {
            var fieldDef = new ChoiceFieldDefinition
            {
                Title = "Tasks status",
                InternalName = "dcs_ProgressStatus",
                Group = "SPMeta2.Samples",
                Id = new Guid("759f97a7-c26f-4dc3-b3fa-47250f168ba4"),
                Choices = new Collection<string>
                {
                    "Not stated",
                    "In progress",
                    "Done"
                }
            };

            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site.AddChoiceField(fieldDef);
            });

            DeployModel(model);
        }

        #endregion
    }
}