using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace MVCLogin.ASPX
{
    public partial class PieChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        void LoadData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=(local);Integrated Security=true;Initial Catalog=minosegbiztositas"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select Type, sum(Amount) as TotAmount from MyFirstTestDB group by Type", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.Pie;
           
        }
    }
}