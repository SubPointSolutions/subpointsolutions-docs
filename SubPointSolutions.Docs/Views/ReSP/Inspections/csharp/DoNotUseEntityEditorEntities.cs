using System.Web.UI;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SubPointSolutions.Docs.Views.Views.ReSP.Inspections.csharp
{
    [TestClass]
    public class DoNotUseEntityEditorEntities
    {
        [TestMethod]
        public SPPrincipalInfo GetPeoplePickerUser(ControlCollection controlCollection)
        {
            SPPrincipalInfo result = null;

            foreach (Control control in controlCollection)
            {
                var peopleEditor = control as PeopleEditor;
                if (peopleEditor != null && peopleEditor.Entities.Count == 1)
                {
                    PickerEntity pickerEntity = (PickerEntity)peopleEditor.Entities[0];
                    // get principal info code here ...
                    return result;
                }
                if (control.HasControls())
                {
                    result = GetPeoplePickerUser(control.Controls);
                }
            }

            return result;
        }
    }
}
