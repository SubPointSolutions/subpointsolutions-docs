using System;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReSharePoint.Docs.Basic.Inspection.Code
{
    [TestClass]
    public class AvoidUsingSPListItemFile
    {
        [TestMethod]
        public void AppropriateSPListItemSPFileUsage(SPListItem item)
        {
            var file = item.Web.GetFile(item.UniqueId);
        }
    }
}
