using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace MVCLogin.ASPX
{
    public partial class Default : System.Web.UI.Page
    {
        string connectionString = @"Data Source=(local);Integrated Security=true;Initial Catalog=minosegbiztositas";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridview();
            }
        }

        void PopulateGridview()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Adattipus", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                gvTanar.DataSource = dtbl;
                gvTanar.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvTanar.DataSource = dtbl;
                gvTanar.DataBind();
                gvTanar.Rows[0].Cells.Clear();
                gvTanar.Rows[0].Cells.Add(new TableCell());
                gvTanar.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvTanar.Rows[0].Cells[0].Text = "Nem található adat!";
                gvTanar.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        protected void gvTanar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        //string query = "INSERT INTO Tanar (F1,F2,F3,F4) VALUES (@F1,@F2,@F3,@F4)";
                        string query = "INSERT INTO Adattipus(ID, Szakok, TanarCim, TanarNev, TanariAllas, Aktivitas, Gradul_de_multumire) VALUES (@ID,@Szakok,@TanarCim,@TanarNev,@TanariAllas,@Aktivitas, @Gradul_de_multumire) ";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@ID", (gvTanar.FooterRow.FindControl("txtF1Footer") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Szakok", (gvTanar.FooterRow.FindControl("txtF2Footer") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@TanarCim", (gvTanar.FooterRow.FindControl("txtF3Footer") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@TanarNev", (gvTanar.FooterRow.FindControl("txtF4Footer") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@TanariAllas", (gvTanar.FooterRow.FindControl("txtF5Footer") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Aktivitas", (gvTanar.FooterRow.FindControl("txtF6Footer") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Gradul_de_multumire", (gvTanar.FooterRow.FindControl("txtF7Footer") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        PopulateGridview();
                        lblSuccessMessage.Text = "New Record Added";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvTanar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTanar.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void gvTanar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTanar.EditIndex = -1;
            PopulateGridview();
        }

        protected void gvTanar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE Adattipus SET ID=@ID,Szakok=@Szakok,TanarCim=@TanarCim,TanarNev=@TanarNev, TanariAllas=@TanariAllas, Aktivitas=@Aktivitas, Gradul_de_multumire=@Gradul_de_multumire  WHERE ID = @rid";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@ID", (gvTanar.Rows[e.RowIndex].FindControl("txtF1") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Szakok", (gvTanar.Rows[e.RowIndex].FindControl("txtF2") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@TanarCim", (gvTanar.Rows[e.RowIndex].FindControl("txtF3") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@TanarNev", (gvTanar.Rows[e.RowIndex].FindControl("txtF4") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@TanariAllas", (gvTanar.Rows[e.RowIndex].FindControl("txtF5") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Aktivitas", (gvTanar.Rows[e.RowIndex].FindControl("txtF6") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Gradul_de_multumire", (gvTanar.Rows[e.RowIndex].FindControl("txtF7") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@rid", Convert.ToInt32(gvTanar.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvTanar.EditIndex = -1;
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Updated";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvTanar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Adattipus WHERE ID = @ID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@ID", Convert.ToInt32(gvTanar.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}