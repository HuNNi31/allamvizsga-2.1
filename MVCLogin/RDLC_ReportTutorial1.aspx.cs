using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;


namespace MVCLogin
{
    public partial class RDLC_ReportTutorial1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer.ProcessingMode = ProcessingMode.Local;
                ReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/rptMunka1.rdlc");
                DataSet ds = GetData("SELECT *  FROM [minosegbiztositas].[dbo].[Munka1$]");
                DataSet ds1 = GetData1("SELECT *  FROM [minosegbiztositas].[dbo].[User]");
                ReportDataSource datasource = new ReportDataSource("Munka1DataSet", ds.Tables[0]);
                ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds1.Tables[0]);
                
                ReportViewer.LocalReport.DataSources.Clear();
                ReportViewer.LocalReport.DataSources.Add(datasource);
                ReportViewer.LocalReport.DataSources.Add(datasource1);
                ReportViewer.LocalReport.Refresh();
            }

        }
        private DataSet GetData(string query)
        {
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["minosegbiztositasConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlDataAdapter da = new SqlDataAdapter("SELECT *  FROM [minosegbiztositas].[dbo].[Munka1$]", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }


        }
        private DataSet GetData1(string query)
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

    }
}