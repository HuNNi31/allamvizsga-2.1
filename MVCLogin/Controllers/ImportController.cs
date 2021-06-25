using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mvc;



namespace MVCLogin.Controllers
{
    public class ImportController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

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
            SqlCommand cmd = new SqlCommand("Create table #MyTempTable(ID int, Szakok nvarchar(50), TanarCim nvarchar(50), TanarNev nvarchar(50), Tanszek nvarchar(50), TanariAllas nvarchar(50))", con);
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
            bulkCopy.ColumnMappings.Add("TanariAllas", "TanariAllas");
            //string query2 = string.Format("INSERT INTO Adattipus SELECT * FROM #MyTempTable tt WHERE NOT EXISTS(SELECT 1 FROM Adattipus yt WHERE yt.ID = tt.ID)");


            bulkCopy.WriteToServer(dt);
            //
            SqlCommand cmd2 = new SqlCommand("UPDATE " +
                                                   "Table_A " +
                                            "SET " +
                                                   "Table_A.Szakok = Table_B.Szakok, " +
                                                   "Table_A.TanarCim = Table_B.TanarCim," +
                                                   "Table_A.TanarNev = Table_B.TanarNev," +
                                                   "Table_A.Tanszek = Table_B.Tanszek, " +
                                                   "Table_A.TanariAllas = Table_B.TanariAllas " +
                                            "FROM " +
                                                    "Adattipus AS Table_A " +
                                                    "INNER JOIN #MyTempTable AS Table_B " +
                                                        "ON Table_A.ID = Table_B.ID", con);
            cmd2.ExecuteNonQuery();
            SqlCommand cmd3 = new SqlCommand("INSERT Adattipus(ID,Szakok,TanarCim,TanarNev,Tanszek, TanariAllas) SELECT * FROM #MyTempTable tt WHERE NOT EXISTS(SELECT 1 FROM Adattipus yt WHERE yt.ID = tt.ID)", con);
            cmd3.ExecuteNonQuery();

            con.Close();
        }

    }
}