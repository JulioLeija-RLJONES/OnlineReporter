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
                    MsgTypes.printme("- comparing " + localfilename + " > " + dbfilename, this.commingFrom);
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
