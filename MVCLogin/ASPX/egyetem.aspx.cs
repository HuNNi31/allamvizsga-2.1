using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;


namespace MVCLogin.ASPX
{
    public partial class egyetem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer.ProcessingMode = ProcessingMode.Local;
                ReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/rptEgyetem.rdlc");
                DataSet ds = GetData("SELECT *  FROM [minosegbiztositas].[dbo].[Munka1$]");

                //Paramtereezes
                //ReportParameterCollection reportparameter = new ReportParameterCollection();
                //reportparameter.Add(new ReportParameter("HiddenColumn", Session["HidenColumn"].ToString()));
                //ReportViewer.LocalReport.SetParameters(reportparameter);

                ReportDataSource datasource = new ReportDataSource("egyetem", ds.Tables[0]);
                ReportViewer.LocalReport.Refresh();

                ReportViewer.LocalReport.DataSources.Clear();
                ReportViewer.LocalReport.DataSources.Add(datasource);


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
    }
}