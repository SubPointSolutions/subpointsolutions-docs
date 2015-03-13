using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Definitions
{
    public static class DocWebFeatures
    {
        #region features

        public static FeatureDefinition MDS = BuiltInWebFeatures
           .MinimalDownloadStrategy
           .Inherit(def =>
           {
               def.Enable = true;
           });

        public static FeatureDefinition WebPublishingInfrastructure = BuiltInWebFeatures
        .SharePointServerPublishing
        .Inherit(def =>
        {
            def.Enable = true;
        });

        public static FeatureDefinition MetadataNavigationAndFiltering = BuiltInWebFeatures
       .MetadataNavigationAndFiltering
       .Inherit(def =>
       {
           def.Enable = true;
       });


        #endregion

        #region disable

        public static class Disable
        {
            public static FeatureDefinition MDS = BuiltInWebFeatures
           .MinimalDownloadStrategy
           .Inherit(def =>
           {
               def.Enable = false;
           });
        }

        #endregion
    }
}
