using System;
using System.Collections.Specialized;
using System.Web;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReSharePoint.Docs.Basic.Inspection.Code
{
    [TestClass]
    public class SendMailFromWcfService
    {
        [TestMethod]
        public void CorrectSendMailFromWcfServiceUsage(SPWeb web, string to, string subject, string body)
        {
            // save current context
            HttpContext curCtx = HttpContext.Current;
            HttpContext.Current = null; // <-- recommended approach for wcf services

            bool success = SPUtility.SendEmail(web, true, true, to, subject, body);

            // restore the context
            HttpContext.Current = curCtx;
        }
    }
}
