using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReSharePoint.Docs.Basic.Inspection.Code
{
    [TestClass]
    public class UnsafeCastingInItemReceiver
    {
        [TestMethod]
        public void UnsafeCastOnSPItemEventDataCollectionItem(SPItemEventProperties properties)
        {
            properties.AfterProperties["Contracts"].ToString();
            properties.BeforeProperties["Contracts"].ToString();
        }
    }
}
