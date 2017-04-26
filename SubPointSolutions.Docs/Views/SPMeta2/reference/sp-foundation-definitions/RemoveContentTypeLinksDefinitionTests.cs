using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Definitions.ContentTypes;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.SSOM.DefaultSyntax;
using SPMeta2.Syntax.Default;


using System.ComponentModel;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]

    

    [Category("Category=Web Model/Lists and libraries")]


    //[Browsable(false)]
    public class RemoveContentTypeLinksDefinitionTests : ProvisionTestBase
    {
        #region methods


        [TestMethod]
        [TestCategory("Docs.RemoveContentTypeLinksDefinition")]

        [DisplayName("Remove content types from lists")]
        //[Browsable(false)]
        public void CanRemoveContentTypeFromList()
        {
            var defaultReport = new ContentTypeDefinition
            {
                Name = "M2 Default Report",
                Id = new Guid("E2134FA1-254A-41AF-8BB0-A0A521722832"),
                ParentContentTypeId = BuiltInContentTypeId.Item,
                Group = "SPMeta2.Samples"
            };

            var defaultReportsList = new ListDefinition
            {
                Title = "M2 Default Reports",
                Description = "A generic list.",
                TemplateType = BuiltInListTemplateTypeId.GenericList,
                ContentTypesEnabled = true,
                Url = "M2DefaultReports"
            };

            var siteModel = SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddContentType(defaultReport);
            });

            var webModel = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(defaultReportsList, list =>
                {
                    list
                        .AddContentTypeLink(defaultReport)
                        .AddRemoveContentTypeLinks(new RemoveContentTypeLinksDefinition
                        {
                            ContentTypes = new List<ContentTypeLinkValue>
                            {
                                new ContentTypeLinkValue{ ContentTypeName = "Item"}
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