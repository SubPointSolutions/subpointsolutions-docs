using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.CSOM.DefaultSyntax;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Fields;
using SPMeta2.Docs.ProvisionSamples.Attributes;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Consts;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class LookupFieldDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestCategory("Docs.FieldDefinition")]
        [SampleMetadata(
            Title = "Adding empty lookup field",
            Description = "",
            Order = 5000,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.Fields)]

        [TestMethod]
        [TestCategory("Docs.LookupFieldDefinition")]
        public void CanDeployEmptyLookupField()
        {
            var emptyLookupField = new LookupFieldDefinition
            {
                Title = "Empty Lookup Field",
                InternalName = "m2EmptyLookupField",
                Group = "SPMeta2.Samples",
                Id = new Guid("B6387953-3967-4023-9D38-431F2C6A5E54")
            };

            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddField(emptyLookupField);
            });

            DeployModel(model);
        }

        [TestCategory("Docs.FieldDefinition")]
        [SampleMetadata(
            Title = "Adding lookup field with binding",
            Description = "",
            Order = 5100,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.Fields)]

        [TestMethod]
        [TestCategory("Docs.LookupFieldDefinition")]
        public void CanDeployLookupFieldBindedToList()
        {
            var leadTypeLookup = new LookupFieldDefinition
            {
                Title = "Lead Type",
                InternalName = "m2LeadType",
                Group = "SPMeta2.Samples",
                Id = new Guid("FEFC30A7-3B38-4034-BB2A-FFD538D46A63")
            };

            var lookupFieldModel = SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddField(leadTypeLookup);
            });

            var leadRecords = new ListDefinition
            {
                Title = "Lead Records",
                Description = "A generic list.",
                TemplateType = BuiltInListTemplateTypeId.GenericList,
                CustomUrl = "m2LeadRecordsList"
            };

            var leadRecordTypes = new ListDefinition
            {
                Title = "Lead Record Types",
                Description = "A generic list.",
                TemplateType = BuiltInListTemplateTypeId.GenericList,
                CustomUrl = "m2LeadRecordTypesList"
            };

            var webModel = SPMeta2Model.NewWebModel(web =>
            {
                web
                  .AddList(leadRecords, list =>
                  {
                      list.AddListFieldLink(leadTypeLookup);
                  })
                  .AddList(leadRecordTypes);
            });

            // 1. deploy lookup field without bindings
            DeployModel(lookupFieldModel);

            // 2. deploy lists
            DeployModel(webModel);

            // 3. update binding for the lookup field
            // LookupList/LookupListId could also be used
            leadTypeLookup.LookupListTitle = leadRecordTypes.Title;

            // 4. deploy lookup field again, so that it will be binded
            DeployModel(lookupFieldModel);
        }

        #endregion
    }
}