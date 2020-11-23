using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace MVCLogin
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Tanar", sqlCon);
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
                gvTanar.Rows[0].Cells[0].Text = "No Data Found ..!";
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
                        string query = "INSERT INTO Tanar (F1,F2,F3,F4) VALUES (@F1,@F2,@F3,@F4)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@F1", (gvTanar.FooterRow.FindControl("txtF1Footer") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@F2", (gvTanar.FooterRow.FindControl("txtF2Footer") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@F3", (gvTanar.FooterRow.FindControl("txtF3Footer") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@F4", (gvTanar.FooterRow.FindControl("txtF4Footer") as TextBox).Text.Trim());
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
                    string query = "UPDATE Tanar SET F1=@F1,F2=@F2,F3=@F3,F4=@F4 WHERE F1 = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@F1", (gvTanar.Rows[e.RowIndex].FindControl("txtF1") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@F2", (gvTanar.Rows[e.RowIndex].FindControl("txtF2") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@F3", (gvTanar.Rows[e.RowIndex].FindControl("txtF3") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@F4", (gvTanar.Rows[e.RowIndex].FindControl("txtF4") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvTanar.DataKeys[e.RowIndex].Value.ToString()));
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
                    string query = "DELETE FROM Tanar WHERE F1 = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvTanar.DataKeys[e.RowIndex].Value.ToString()));
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