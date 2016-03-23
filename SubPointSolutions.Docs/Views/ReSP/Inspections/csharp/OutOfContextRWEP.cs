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
    public class OutOfContextRWEP
    {
        [TestMethod]
        public void TrustedConnectionSample(SPWeb web)
        {
            // Windows credentials of the current user are used to authenticate against SQL Server and any <user id=> setting will be ignored 
            var sqlConnection = new SqlConnection("Data Source=SQLDevelopment; Initial Catalog=SQL2008; Integrated Security=SSPI;");
            var sqlCommand = new SqlCommand("SELECT * FROM [dbo].[Emplpoyees]", sqlConnection);

            var sqlConnection2 = new SqlConnection("Server=SQLDevelopment; Database=SQL2008; Trusted_Connection=True");
            var sqlCommand2 = new SqlCommand("SELECT * FROM [dbo].[Students]", sqlConnection2);
        }
    }
}
