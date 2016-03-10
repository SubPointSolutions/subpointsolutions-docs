using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Definitions.ContentTypes;
using SPMeta2.Docs.ProvisionSamples.Attributes;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Consts;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Standard.Enumerations;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class HideContentTypeLinksDefinitionTests : ProvisionTestBase
    {
        #region methods


        [SampleMetadata(
            Title = "Hiding content types in list",
            Description = "",
            Order = 2500,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.ContentType)]
        [TestMethod]
        [TestCategory("Docs.HideContentTypeLinksDefinition")]
        public void CanHideContentTypesInList()
        {
            var newAnnualReportContentType = new ContentTypeDefinition
            {
                Name = "M2 Annual Report 2015",
                Id = new Guid("7B3378FF-11DF-430B-830F-C63FABA4712F"),
                ParentContentTypeId = BuiltInContentTypeId.Item,
                Group = "SPMeta2.Samples"
            };

            var oldAnnualReportContentType = new ContentTypeDefinition
            {
                Name = "M2 Annual Report 2014",
                Id = new Guid("DEB586C5-ED08-4D06-98F6-9FC5002986D2"),
                ParentContentTypeId = BuiltInContentTypeId.Item,
                Group = "SPMeta2.Samples"
            };

            var annualReportsList = new ListDefinition
            {
                Title = "M2 Annual Reports",
                Description = "A generic list.",
                TemplateType = BuiltInListTemplateTypeId.GenericList,
                ContentTypesEnabled = true,
                CustomUrl = "M2AnnualReports"
            };

            var siteModel = SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddContentType(newAnnualReportContentType)
                    .AddContentType(oldAnnualReportContentType);
            });

            var webModel = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(annualReportsList, list =>
                {
                    list
                        .AddContentTypeLink(newAnnualReportContentType)
                        .AddContentTypeLink(oldAnnualReportContentType)
                        .AddHideContentTypeLinks(new HideContentTypeLinksDefinition
                        {
                            ContentTypes = new List<ContentTypeLinkValue>
                            {
                                new ContentTypeLinkValue{ ContentTypeName = "Item" },
                                new ContentTypeLinkValue{ ContentTypeName = oldAnnualReportContentType.Name }
                            }
                        });
                });
            });

            DeployModel(siteModel);
            DeployModel(webModel);
        }

        #endregion
    }
}