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
    public class MultiChoiceFieldDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.MultiChoiceFieldDefinition")]

        [DisplayName("Add multichoice field")]
        //[Browsable(false)]
        public void CanDeploySimpleMultiChoiceFieldDefinition()
        {
            var fieldDef = new MultiChoiceFieldDefinition
            {
                Title = "Tasks label",
                InternalName = "dcs_ProgressTag",
                Group = "SPMeta2.Samples",
                Id = new Guid("b08325aa-a750-4bf9-a73e-c470b86d37c8"),
                Choices = new Collection<string>
                {
                    "internal",
                    "external",
                    "bug",
                    "easy fix",
                    "enhancement"
                }
            };

            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site.AddMultiChoiceField(fieldDef);
            });

            DeployModel(model);
        }

        #endregion
    }
}