using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace OnlineDataDownloadeer.Classes
{

 
    class OnlineDB
    {
        db_elptestDataSetTableAdapters.tbl_MSFTOnlineFile_LogTableAdapter onlineDB =
        new db_elptestDataSetTableAdapters.tbl_MSFTOnlineFile_LogTableAdapter();

        private System.Windows.Forms.Form commingFrom;

        public OnlineDB(System.Windows.Forms.Form commingFrom)
        {
            this.commingFrom = commingFrom;
        }

        #region Logic
        public bool InsertRecord(string fileName)
        {
            try
            {
                onlineDB.Insert(Path.GetFileName(fileName), DateTime.Now, null);
                return true;
            }catch(Exception ex)
            {
                return false;
            }

        }
        public string IsNewFileAvailable()
        {
            bool matchfound = false;
            string localfilename;
            db_elptestDataSet.tbl_MSFTOnlineFile_LogDataTable dataset =
                new db_elptestDataSet.tbl_MSFTOnlineFile_LogDataTable();
            onlineDB.Fill(dataset);
            MsgTypes.printme("downloads folder: " + KnownFolders.GetPath(KnownFolder.Downloads), this.commingFrom);
            string[] files = Directory.GetFiles(KnownFolders.GetPath(KnownFolder.Downloads), "*MSOnlineCapture*");
            foreach (string f in files)
            {
                matchfound = false;
                localfilename = Path.GetFileName(f.ToString());
                foreach (db_elptestDataSet.tbl_MSFTOnlineFile_LogRow row in dataset.Rows)
                {
                    string dbfilename = row[1].ToString();
                    //MsgTypes.printme("- comparing " + localfilename + " > " + dbfilename, this.commingFrom);
                    if (localfilename == dbfilename)
                    {
                        matchfound = true;
                        break;
                    }
                }
                if (!matchfound)
                {
                    return localfilename;
                }
            }
            return "";
        }
        public int qtyFilesLogged()
        {
            db_elptestDataSet.tbl_MSFTOnlineFile_LogDataTable dataset =
            new db_elptestDataSet.tbl_MSFTOnlineFile_LogDataTable();
            onlineDB.Fill(dataset);
            return dataset.Rows.Count;
        }
        public string getOldestUnprocessedFile()
        {

            DataSet dataset = new DataSet();
            string sql = getQuery("getOldestUnProcessedFile");
            SqlDataAdapter adp = new SqlDataAdapter(sql, onlineDB.Connection.ConnectionString);
            adp.Fill(dataset);

            return dataset.Tables[0].Rows[0].ItemArray[1].ToString();

        }
        public void markFileProcessed(string name)
        {
            //TODO insert logic to look for the name in database file name 
            //and set the date of processing.

            string sql = getQuery("msft_udpateOnlineLogRow");
            sql = String.Format(sql, name, DateTime.Now);
            //MsgTypes.printme("**************************", commingFrom);
            //MsgTypes.printme("query description:", commingFrom);
            //MsgTypes.printme(sql,commingFrom);
            //MsgTypes.printme("**************************", commingFrom);

            //SqlConnection conn = new SqlConnection(onlineDB.Connection.ConnectionString);
            SqlConnection conn = new SqlConnection("Data Source=elpuatsqlserver.database.windows.net;Initial Catalog=db_elptest;User ID=azureuser;Password=elp.1234");

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        #endregion



        #region Support Functions
        private string getQuery(string name)
        {
            try
            {
                string path = System.Windows.Forms.Application.ExecutablePath;
                path = path.Replace("OnlineDataDownloadeer.exe", "");
                string[] files = Directory.GetFiles(path + "\\Queries\\");
                string sql = "";
                foreach (string file in files)
                {
                    if (file.Contains(name))
                    {
                        sql = System.IO.File.ReadAllText(file);
                    }
                }
                if (sql == "")
                {
                    Console.WriteLine("faiules >> no query obtained");
                }
                else
                {

                }
                return sql;
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                return null;
            }
        }
        #endregion


    }
}
