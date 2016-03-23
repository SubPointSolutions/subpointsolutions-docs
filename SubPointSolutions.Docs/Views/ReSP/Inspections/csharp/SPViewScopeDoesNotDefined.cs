using System.Collections.Specialized;
using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReSharePoint.Docs.Basic.Inspection.Code
{
    [TestClass]
    public class SPViewScopeDoesNotDefined
    {
        [TestMethod]
        public void CorrectSPViewScopeUsage(SPList list)
        {
            var viewFields = new[] { "Title", "Department" };

            var fields = new StringCollection();
            fields.AddRange(viewFields);

            var newView = list.Views.Add("TestView", fields, string.Empty, 100, true, false);

            // define SPView.Scope
            newView.Scope = SPViewScope.Recursive;
            newView.Update();

            list.Update();
        }
    }
}
