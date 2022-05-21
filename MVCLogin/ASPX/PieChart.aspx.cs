using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    void LoadData()
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog-MyFirstTestDB;Integrated Security=True"))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Tanzsek, Gradul_de_multumire as Rate from Adattipus group by Tanszek", con);
            SqlDataAdapter da = new SqlDataAdapter();
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
        Chart1sss.Series[0].ChartType = SeriesChartType.Pie;
    }
}