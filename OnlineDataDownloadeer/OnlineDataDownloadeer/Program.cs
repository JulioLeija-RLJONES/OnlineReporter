using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineDataDownloadeer.Forms;

namespace OnlineDataDownloadeer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            FrmMonitor monitor = new FrmMonitor();
            Application.Run(monitor);
        }
    }
}
