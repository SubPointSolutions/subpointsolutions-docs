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
    public class InappropriateUsageOfSPListCollection
    {
        [TestMethod]
        public void CorrectListUsage(SPWeb web)
        {
            var listUrl = "/lists/tasks";
            var taskList = web.GetList(SPUrlUtility.CombineUrl(web.Url, listUrl));
        }
    }
}
