using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;
using System;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class FieldDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.FieldDefinition")]
        public void CanDeploySimpleFields()
        {
            var textField = new FieldDefinition
            {
                Title = "Simple text field",
                InternalName = "dcs_SimpleTextField",
                Group = "SPMeta2.Samples",
                Id = new Guid("c3afc5ee-c416-4a05-91b3-116de4a205de"),
                FieldType = BuiltInFieldTypes.Text,
            };

            var booleanField = new FieldDefinition
            {
                Title = "Simple boolean field",
                InternalName = "dcs_SimpleBooleanField",
                Group = "SPMeta2.Samples",
                Id = new Guid("1f0a5ba9-7b00-433d-8d93-dcfb4f87bfca"),
                FieldType = BuiltInFieldTypes.Boolean,
            };

            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddField(textField)
                    .AddField(booleanField);
            });

            DeployModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.FieldDefinition")]
        public void CanDeploySiteFields()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddField(DocFields.Clients.ClientCredit)
                    .AddField(DocFields.Clients.ClientDebit)
                    .AddField(DocFields.Clients.ClientDescription)
                    .AddField(DocFields.Clients.ClientNumber)
                    .AddField(DocFields.Clients.ClientWebSite);
            });

            DeployModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.FieldDefinition")]
        public void CanDeployListFields()
        {
            var textField = new FieldDefinition
            {
                Title = "Simple text field",
                InternalName = "dcs_SimpleTextField",
                Group = "SPMeta2.Samples",
                Id = new Guid("c3afc5ee-c416-4a05-91b3-116de4a205de"),
                FieldType = BuiltInFieldTypes.Text,
            };

            var booleanField = new FieldDefinition
            {
                Title = "Simple boolean field",
                InternalName = "dcs_SimpleBooleanField",
                Group = "SPMeta2.Samples",
                Id = new Guid("1f0a5ba9-7b00-433d-8d93-dcfb4f87bfca"),
                FieldType = BuiltInFieldTypes.Boolean,
            };

            var listWithFields = new ListDefinition
            {
                Title = "List with fields",
                Description = "Custom list with list-scoped fields.",
                TemplateType = BuiltInListTemplateTypeId.GenericList,
                Url = "ListWithFields"
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(listWithFields, list =>
                {
                    list.AddField(textField);
                    list.AddField(booleanField);
                });
            });

            DeployModel(model);
        }

        #endregion
    }
}
