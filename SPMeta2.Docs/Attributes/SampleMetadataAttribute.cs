using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPMeta2.Docs.ProvisionSamples.Attributes
{
    public class SampleMetadataAttribute : Attribute
    {
        #region properties

        public string Title { get; set; }
        public string Description { get; set; }

        public int Order { get; set; }

        public string CatagoryAlias { get; set; }

        public string GroupAlias { get; set; }
        public int GroupOrder { get; set; }

        #endregion
    }
}
