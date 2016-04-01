using System;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Web;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReSharePoint.Docs.Basic.Inspection.Code
{
    [TestClass]
    public class DoNotUseUnsafeTypeConversionOnSPListItem
    {
        [TestMethod]
        public void IncorrectSPListItemCast(SPListItem item)
        {
            string date1 = item["Date"].ToString();
            DateTime date2 = (DateTime)item["Date"];
            int x = ((SPFieldUserValue)item["User"]).LookupId;
        }

        [TestMethod]
        public void CorrectSPListItemCast(SPListItem item)
        {
            DateTime date1 = Convert.ToDateTime(item["Date"]);
            DateTime? date2 = item["Date"] as DateTime?;
        }
    }
}
