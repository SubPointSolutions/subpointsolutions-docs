using System;
using System.Collections.Specialized;
using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReSharePoint.Docs.Basic.Inspection.Code
{
    [TestClass]
    public class SPQueryScopeDoesNotDefined
    {
        [TestMethod]
        public void SPQueryScopeUsageSamples(SPList list)
        {
            Console.WriteLine("All Items Count: " + list.ItemCount);

            var firstQuery = new SPQuery();
            var firstResult = list.GetItems(firstQuery);

            Console.WriteLine("First Query: " + firstResult.Count);

            var secondQuery = new SPQuery
            {
                ViewAttributes = "Scope=\"RecursiveAll\""
            };
            var secondResult = list.GetItems(secondQuery);

            Console.WriteLine("Second Query: " + secondResult.Count);
        }
    }
}
