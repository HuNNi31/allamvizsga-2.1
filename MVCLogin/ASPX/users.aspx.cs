using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MVCLogin.ASPX
{
    public partial class users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer.ProcessingMode = ProcessingMode.Local;
                ReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/rptUser.rdlc");
                DataSet ds = GetData("SELECT *  FROM [minosegbiztositas].[dbo].[User]");
                ReportDataSource datasource = new ReportDataSource("UserDataSet", ds.Tables[0]);
                ReportViewer.LocalReport.DataSources.Clear();
                ReportViewer.LocalReport.DataSources.Add(datasource);
                ReportViewer.LocalReport.Refresh();
            }

        }
        private DataSet GetData(string query)
        {
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["minosegbiztositasConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlDataAdapter da = new SqlDataAdapter("SELECT *  FROM [minosegbiztositas].[dbo].[User]", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        ///ImportController
        ///

    }

}