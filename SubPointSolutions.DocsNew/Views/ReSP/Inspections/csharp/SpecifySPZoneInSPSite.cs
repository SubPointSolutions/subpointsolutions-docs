using System;
using System.Collections.Specialized;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReSharePoint.Docs.Basic.Inspection.Code
{
    [TestClass]
    public class SpecifySPZoneInSPSite
    {
        [TestMethod]
        public void IncorrectSPUrlZoneParamUsage(SPList list)
        {
            using (SPSite site = new SPSite(SPContext.Current.Site.ID))
            {
                SPUrlZone zone = site.Zone;
                //Logic that depends on Zone
                //Oops! Zone is always 'Default'
            }
        }

        [TestMethod]
        public void CorrectSPUrlZoneParamUsage(SPList list)
        {
            using (SPSite site = new SPSite(SPContext.Current.Site.ID, SPContext.Current.Site.Zone))
            {
                SPUrlZone zone = site.Zone;
                //Logic that depends on Zone
                //Zone will contain the correct Zone depending upon the Context
            }
        }
    }
}
