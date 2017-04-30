using System;
using System.Collections.Specialized;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReSharePoint.Docs.Basic.Inspection.Code
{
    [TestClass]
    public class SPDataSourceScopeDoesNotDefined
    {
        [TestMethod]
        public void SPDataSourceScopeUsageSamples(SPList list)
        {
            var ds = new SPDataSource();

            ds.List = list;
            ds.DataSourceMode = SPDataSourceMode.List;
            ds.IncludeHidden = false;

            ds.Scope = SPViewScope.Recursive; // <-  recommended
        }
    }
}
