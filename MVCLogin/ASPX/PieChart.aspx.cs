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
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        void LoadData()
        {
            DataTable dt = new DataTable();
            //using (SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog-minosegbiztositas;Integrated Security=True"))
            using (SqlConnection con = new SqlConnection(@"Data Source=(local);Integrated Security=true;Initial Catalog=minosegbiztositas"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select Tanszek AS Tanszék, AVG(Gradul_de_multumire) AS Értékelés from Adattipus group by Tanszek", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                //con.Close();
            }
            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            //Chart1.DataSource = dt;
            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.Pie;
            //Chart1.Series["Series1"].XValueMember = "Tanszek";
            //Chart1.Series["Series1"].YValueMembers = "Szint";
            //Chart1.Series["Series1"].ChartType = SeriesChartType.Pie;
            //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
           // Chart1.Legends["Series1"].Enabled = true;

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}