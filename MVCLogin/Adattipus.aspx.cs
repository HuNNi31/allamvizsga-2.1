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
                ReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/rptAdat.rdlc");
                DataSet ds = GetData("SELECT *  FROM [minosegbiztositas].[dbo].[Adattipus]");

                //Paramtereezes
                //ReportParameterCollection reportparameter = new ReportParameterCollection();
                //reportparameter.Add(new ReportParameter("HiddenColumn", Session["HidenColumn"].ToString()));
                //ReportViewer.LocalReport.SetParameters(reportparameter);

                ReportDataSource datasource = new ReportDataSource("DataSetAdattipus", ds.Tables[0]);
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

                SqlDataAdapter da = new SqlDataAdapter("SELECT *  FROM [minosegbiztositas].[dbo].[Adattipus]", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }


        }

        /*<!*/
        protected void ShowRDLC(object sender, EventArgs e)
        {
            List<string> columns = new List<string>();
            if (chkName.Checked)
            {
                columns.Add(chkName.Text);
            }
            if (chkCountry.Checked)
            {
                columns.Add(chkCountry.Text);
            }
            Session["HidenColumn"] = string.Join(",", columns);


            DataTable ds = new DataTable();
            //    foreach (GridViewRow row in ds.Rows)
            //    {
            //        if ((row.FindControl("chkSelect") as CheckBox).Checked)
            //        {
            //            string id = row.Cells[1].Text;
            //            string name = (row.FindControl("lblName") as Label).Text.Trim();
            //            string country = (row.FindControl("lblCountry") as Label).Text.Trim();
            //            ds.Rows.Add(id, name, country);
            //        }
            //    }

            Session["GridViewRow"] = ds;
            string url = "Adattipus.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=350,height=200,left=150,top=120,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }
        protected void OnCheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Text == "ID")
            {
                if ((sender as CheckBox).Checked)
                {
                    gvCustomers.Columns[2].Visible = true;
                }
                else
                {
                    gvCustomers.Columns[2].Visible = false;
                }
            }
            if ((sender as CheckBox).Text == "Tanar Fizetes")
            {
                if ((sender as CheckBox).Checked)
                {
                    gvCustomers.Columns[3].Visible = true;
                }
                else
                {
                    gvCustomers.Columns[3].Visible = false;
                }
            }
        }
    }
        

}
