using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Definitions.ContentTypes;
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
    public class RemoveContentTypeFieldLinksDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
          Title = "Removing field from content type",
          Description = "",
          Order = 3000,
          CatagoryAlias = SampleCategory.SharePointFoundation,
          GroupAlias = SampleGroups.ContentType)]

        [TestMethod]
        [TestCategory("Docs.RemoveContentTypeFieldLinksDefinition")]
        public void CanCreateContentTypeWithOutTitleField()
        {
            var customName = new TextFieldDefinition
            {
                Title = "Custom Name",
                InternalName = "m2_CustomName",
                Group = "SPMeta2.Samples",
                Id = new Guid("8EE0C5C6-BD47-4111-9707-660B737F9F9B"),
            };

            var customObjectContentType = new ContentTypeDefinition
            {
                Name = "M2 Custom Object",
                Id = new Guid("C6F60CBE-48AE-434D-955C-7A45DC32AD9A"),
                ParentContentTypeId = BuiltInContentTypeId.Item,
                Group = "SPMeta2.Samples"
            };

            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                 .AddField(customName)
                 .AddContentType(customObjectContentType, contentType =>
                 {
                     contentType
                         .AddContentTypeFieldLink(customName)
                         .AddRemoveContentTypeFieldLinks(new RemoveContentTypeFieldLinksDefinition
                         {
                             Fields = new List<FieldLinkValue>
                             {
                                 new FieldLinkValue {Id = BuiltInFieldId.Title}
                             }
                         });
                 });
            });

            DeployModel(model);
        }

        #endregion
    }
}