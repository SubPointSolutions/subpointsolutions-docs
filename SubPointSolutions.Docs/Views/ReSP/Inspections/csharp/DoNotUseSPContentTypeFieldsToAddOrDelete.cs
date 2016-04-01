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
    public class DoNotUseSPContentTypeFieldsToAddOrDelete
    {
        [TestMethod]
        public void InappropriateSPContentTypeFieldsUsage(SPWeb web, string contentTypeName)
        {
            var ct = web.ContentTypes[contentTypeName];
            ct.Fields.Add("NewField", SPFieldType.Boolean, true);
        }

        [TestMethod]
        public void AppropriateAddingFields(SPContentType contentType, SPField field)
        {
            //Check if the Field reference does not exists already
            if (!contentType.Fields.ContainsField(field.Title))
            {
                contentType.FieldLinks.Add(new SPFieldLink(field));
                contentType.Update();
            }
            else
            {
                //Do Nothing
            }
        }

        [TestMethod]
        public void AppropriateDeletingFields(SPContentType contentType, SPField field)
        {
            //Check if the Field reference exists
            if (contentType.Fields.ContainsField(field.Title))
            {
                contentType.FieldLinks.Delete(field.Title);
                contentType.Update();
            }
            else
            {
                //Do Nothing
            }
        }
    }
}
