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
    public class PutSPFileExistsIntoTryCatchBlock
    {
        [TestMethod]
        public void CorrectSPFileExistsUsage(SPWeb web)
        {
            var defaultMasterUrl = "/_catalogs/masterpage/default.master";

            if (web.AllProperties.ContainsKey("OldMasterUrl"))
            {
                string oldMasterUrl = web.AllProperties["OldMasterUrl"].ToString();
                try
                {
                    var fileExists = web.GetFile(oldMasterUrl).Exists;
                    web.MasterUrl = oldMasterUrl;
                }
                catch (ArgumentException)
                {
                    web.MasterUrl = defaultMasterUrl;
                }


                var oldCustomUrl = web.AllProperties["OldCustomMasterUrl"].ToString();
                try
                {
                    var fileExists = web.GetFile(oldCustomUrl).Exists;
                    web.CustomMasterUrl = web.AllProperties["OldCustomMasterUrl"].ToString();
                }
                catch (ArgumentException)
                {
                    web.CustomMasterUrl = defaultMasterUrl;
                }

                web.AllProperties.Remove("OldMasterUrl");
                web.AllProperties.Remove("OldCustomMasterUrl");
            }
            else
            {
                web.MasterUrl = defaultMasterUrl;
                web.CustomMasterUrl = defaultMasterUrl;
            }
        }
    }
}
