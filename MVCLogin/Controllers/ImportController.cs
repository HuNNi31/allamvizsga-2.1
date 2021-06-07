using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using MVCLogin.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;



namespace MVCLogin.Controllers
{
    public class ImportController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // GET: Import
        //string CS = System.Configuration.ConfigurationManager.ConnectionStrings["minosegbiztositasConnectionString"].ConnectionString;
        //SqlConnection con = new SqlConnection(CS);
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["minosegbiztositasConnectionString"].ConnectionString);
        OleDbConnection Econ;

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength == 0)
            {
                ViewBag.Error = "Please select an excel file";
                return View("Index");
            }
            else
            {
                if (file.FileName.EndsWith("xls") || file.FileName.EndsWith("xlsx"))
                {
                    string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    string filepath = "~/excelfolder/" + filename;
                    file.SaveAs(Path.Combine(Server.MapPath("~/excelfolder"), filename));
                    InsertExceldata(filepath, filename);

                    return View("Index");
                }
                else
                {
                    ViewBag.Error = "File type is incorrect<br>";
                    return View("Index");
                }
            }
        }

        private void ExcelConn(string filepath)
        {
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", filepath);
            Econ = new OleDbConnection(constr);
        }

        private void InsertExceldata(string filepath, string filename)
        {
            string fullpath = Server.MapPath("/excelfolder/") + filename;
            ExcelConn(fullpath);

            // create temp table

            // tobb sheet
            //string query = string.Format("Select [Szakok], [TanarNev] from [{0}] Group by Szakok,TanarNev", "Sheet1$");
            string query = string.Format("Select * from [{0}]", "Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);
            Econ.Close();
            oda.Fill(ds);
con.Open();
            // create temp table
            SqlCommand cmd = new SqlCommand("Create table #MyTempTable(ID int, Szakok nvarchar(50), TanarCim nvarchar(50), TanarNev nvarchar(50), Tanszek nvarchar(50))", con);
            cmd.ExecuteNonQuery();

            // create temp table
            //con.CommandText = string.Format(createTempCommand, "#TempTable",
            //                      string.Join(",", columnList.Select(c => c.ToString()).ToArray()));


            DataTable dt = ds.Tables[0];

            //Masolas a temp tablebe
            SqlBulkCopy bulkCopy = new SqlBulkCopy(con);
            bulkCopy.DestinationTableName = "#MyTempTable";
            bulkCopy.ColumnMappings.Add("ID", "ID");
            bulkCopy.ColumnMappings.Add("Szakok", "Szakok");
            bulkCopy.ColumnMappings.Add("TanarCim", "TanarCim");
            bulkCopy.ColumnMappings.Add("TanarNev", "TanarNev");
            bulkCopy.ColumnMappings.Add("Tanszek", "Tanszek");
            //string query2 = string.Format("INSERT INTO Adattipus SELECT * FROM #MyTempTable tt WHERE NOT EXISTS(SELECT 1 FROM Adattipus yt WHERE yt.ID = tt.ID)");


            bulkCopy.WriteToServer(dt);
            //
            SqlCommand cmd2 = new SqlCommand("UPDATE " +
                                                   "Table_A " +
                                            "SET " +
                                                   "Table_A.Szakok = Table_B.Szakok, " +
                                                   "Table_A.TanarCim = Table_B.TanarCim," +
                                                   "Table_A.TanarNev = Table_B.TanarNev," +
                                                   "Table_A.Tanszek = Table_B.Tanszek " +
                                            "FROM " +
                                                    "Adattipus AS Table_A " +
                                                    "INNER JOIN #MyTempTable AS Table_B " +
                                                        "ON Table_A.ID = Table_B.ID", con);
            cmd2.ExecuteNonQuery();
            SqlCommand cmd3 = new SqlCommand("INSERT Adattipus(ID,Szakok,TanarCim,TanarNev,Tanszek) SELECT * FROM #MyTempTable tt WHERE NOT EXISTS(SELECT 1 FROM Adattipus yt WHERE yt.ID = tt.ID)", con);
            cmd3.ExecuteNonQuery();
            //SqlCommand cmd1 = new SqlCommand("MERGE INTO Adattipus AS TARGET" +
            //                                 "USING #MyTempTable AS SOURCE" +
            //                                 "ON (TARGET.ID = SOURCE.ID)" +
            //                                 "WHEN MATCHED AND TARGET.Szakok <> SOURCE.Szakok OR TARGET.TanarNev <> SOURCE.TanarNev" +
            //                                 "THEN UPDATE SET TARGET.Szakok = SOURCE.Szakok, TARGET.TanarNev = SOURCE.TanarNev" +
            //                                 "WHEN NOT MATCHED BY TARGET" +
            //                                 "THEN INSERT (ID, Szakok, TanarNev) VALUES (SOURCE.ID, SOURCE.Szakok, SOURCE.TanarNev)", con);
            //cmd1.ExecuteNonQuery();
            //Masolas TEMP-bol veglegesbe
            //string query1 = @"INSERT INTO Adattipus  
            //           SELECT * FROM #MyTempTable tt
            //           WHERE NOT EXISTS(SELECT 1 FROM Adattipus yt WHERE yt.ID = tt.ID)";
            //cmd2.CommandText = query1;
            //cmd2.ExecuteNonQuery();


            //
            // Example string.Compare("citroen","Citroën", CultureInfo.InvariantCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase)
            //
            con.Close();
        }

        //    protected void insertdata_Click(object sender, EventArgs e)
        //    {
        //        OleDbConnection oconn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("Desktop/A2E31540.xlsx") + ";Extended Properties='Excel 8.0;HDR={1}'");

        //            OleDbCommand ocmd = new OleDbCommand("select * from [Sheet1$]", oconn);
        //            oconn.Open();
        //            OleDbDataReader odr = ocmd.ExecuteReader();
        //            string ID = "";
        //            string Szakok = "";
        //            string TanarNev = "";
        //            while (odr.Read())
        //            {
        //                ID = valid(odr, 0);
        //                Szakok = valid(odr, 1);
        //                TanarNev = valid(odr, 2);
        //                // Checking email exist or not.
        //                // If not exist then insert record.
        //                if (!IsIDExist(Szakok, TanarNev))
        //                {
        //                    insertdataintosql(ID, Szakok, TanarNev);
        //                }
        //            }
        //            oconn.Close();

        //        //catch (DataException ee)
        //        //{
        //        //    lblmsg.Text = ee.Message;
        //        //    lblmsg.ForeColor = System.Drawing.Color.Red;
        //        //}
        //        //finally
        //        //{
        //        //    lblmsg.Text = "Data Inserted Sucessfully";
        //        //    lblmsg.ForeColor = System.Drawing.Color.Green;
        //        //}
        //    }

        //    private bool IsIDExist(string Szakok, string TanarNev)
        //    {
        //        bool exist = false;
        //        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        //        SqlConnection conn = new SqlConnection(conStr);
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = conn;
        //        // Change the query as per your condition.
        //        string query1 = "SELECT TanarNev FROM Adattipus WHERE TanarNev = @TanarNev AND Szakok = @Szakok";
        //        cmd.CommandText = query1;
        //        cmd.Parameters.Add("@Szakok", SqlDbType.NVarChar, 100).Value = Szakok;
        //        cmd.Parameters.Add("@TanarNev", SqlDbType.NVarChar, 100).Value = TanarNev;
        //        cmd.CommandType = CommandType.Text;
        //        conn.Open();
        //        object i = cmd.ExecuteScalar();
        //        if (i != null)
        //        {
        //            exist = true;
        //        }
        //        conn.Close();

        //        return exist;
        //    }

        //    protected string valid(OleDbDataReader myreader, int stval) //if any columns are found null then they are replaced by zero
        //    {
        //        object val = myreader[stval];
        //        if (val != DBNull.Value)
        //            return val.ToString();
        //        else
        //            return Convert.ToString(0);
        //    }

        //    public void insertdataintosql(string DeltakerName, string DeltakerEpost, string DeltakerTelefon)
        //    {
        //        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        //        SqlConnection conn = new SqlConnection(conStr);
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = conn;
        //        string query1 = "INSERT INTO Adattipus (ID, Szakok, TanarNev) VALUES (@DeltakerName, @Szakok, @TanarNev);SELECT SCOPE_IDENTITY()";
        //        cmd.CommandText = query1;
        //        cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 100).Value = DeltakerName;
        //        cmd.Parameters.Add("@Szakok", SqlDbType.NVarChar, 100).Value = DeltakerEpost;
        //        cmd.Parameters.Add("@TanarNev", SqlDbType.NVarChar, 100).Value = DeltakerTelefon;
        //        cmd.CommandType = CommandType.Text;
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //        conn.Close();
        //    }

        //}

    }
}