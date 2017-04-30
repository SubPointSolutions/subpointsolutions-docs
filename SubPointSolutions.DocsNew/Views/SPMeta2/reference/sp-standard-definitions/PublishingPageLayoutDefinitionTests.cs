using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Definitions;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Standard.Definitions;
using SPMeta2.Standard.Enumerations;
using SPMeta2.Standard.Syntax;
using SPMeta2.Syntax.Default;


using SubPointSolutions.Docs.Code.Resources;
using System.ComponentModel;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]


    [Category("Category=Web Model/Master page gallery")]
    //[Browsable(false)]
    public class PublishingPageLayoutDefinitionTests : ProvisionTestBase
    {
        #region methods



        [TestMethod]
        [TestCategory("Docs.MasterPageDefinition")]
        [DisplayName("Add publishing page layout")]
        //[Browsable(false)]
        public void CanDeploySimplePublishingPageLayoutDefinition()
        {
            var publishingPageContentType = new ContentTypeDefinition
            {
                Name = "M2 Article",
                Id = new Guid("664CFB31-AFF3-433E-9F3F-D8812199B0BC"),
                Group = "SPMeta2.Samples",
                ParentContentTypeId = BuiltInPublishingContentTypeId.ArticlePage
            };

            var publshingPageLayout = new PublishingPageLayoutDefinition
            {
                Title = "M2 Article Left Layout",
                FileName = "m2-article-left.aspx",
                // replace with your publishing page layout content
                Content = DefaultPublishingPageLayoutTemplates.ArticleLeft,
                AssociatedContentTypeId = publishingPageContentType.GetContentTypeId(),
                NeedOverride = true
            };

            var siteModel = SPMeta2Model.NewSiteModel(site =>
            {
                site.AddContentType(publishingPageContentType);
            });

            var rootWebModel = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.Catalogs.MasterPage, list =>
                {
                    list.AddPublishingPageLayout(publshingPageLayout);
                });
            });

            DeployModel(siteModel);
            DeployModel(rootWebModel);
        }


        #endregion
    }
}