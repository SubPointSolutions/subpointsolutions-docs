using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SubPointSolutions.Docs.Views.ReSP.Inspections.csharp
{
    [TestClass]
   
    public class DoNotUseSPContextObjectInDisposedBlock
    {
        [TestMethod]
        [TestCategory("Docs.resSP")]
        public void InapropriateSPContextUsage()
        {
            using (var site = SPContext.Current.Site)
            {
            }
        }

        [TestMethod]
        [TestCategory("Docs.resSP")]
        public void CorrectSPContextUsage()
        {
            using (var site = new SPSite(SPContext.Current.Site.ID))
            {
            }
        }
    }
}
