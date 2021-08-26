using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDataDownloadeer.Classes
{
    class PyHelper
    {
        private System.Windows.Forms.Form commingFrom;
        public PyHelper(System.Windows.Forms.Form commingFrom)
        {
            this.commingFrom = commingFrom;
        }
        public bool run_processer(string fileName)
        {
            string path = System.Windows.Forms.Application.ExecutablePath.Replace("OnlineDataDownloadeer.exe", "");
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = path + "process_file.exe";
            //MsgTypes.printme("processor path: " + start.FileName,commingFrom);
            start.Arguments = string.Format("{0}", KnownFolders.GetPath(KnownFolder.Downloads) + "\\"+  fileName);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
            return true;
        }
    }
}
