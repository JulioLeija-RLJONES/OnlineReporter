using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

using OnlineDataDownloadeer.Classes;
using System.Diagnostics;

namespace OnlineDataDownloadeer.Forms
{
    public partial class FrmMonitor : Form
    {
        OnlineDB onlineDB;
        PyHelper pyhelper;
        int cycles;
        public FrmMonitor()
        {
            InitializeComponent();
            MsgTypes.printme("1 form loaded", this);
            onlineDB=  new OnlineDB(this);
            pyhelper = new PyHelper(this);
        }

        public void initForm()
        {
            timer2.Interval = (int)(timer1.Interval/4);
            if (!isDebugMode())
            {
                labelVersion.Text = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
        }

        #region Controls
        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            Tools.OnlineChrome.Open();
            MsgTypes.printme("2 FlexlinkChrome open completed", this);
            Tools.OnlineChrome.Maximize();
            MsgTypes.printme("3 FlexlinkChrome maximized", this);
            Tools.OnlineChrome.Navigate("https://rmaamericas.flextronics.com/flexrma/flmanualprealerts/");
            MsgTypes.printme("4 FlexlinkChrome navigated", this);

            System.Threading.Thread.Sleep(5000);

            if (login())
            {
                MsgTypes.printme("5.1 online capture logged in",this);
            }
            else
            {
                MsgTypes.printme("5.2 failure at login", this);
            }
        }
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Tools.OnlineChrome.Quit();
            MsgTypes.printme("6 driver terminated.",this);    
        }
        private void buttonReport_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            runReport();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            runReport();
            cycles += 1;
            labelCycles.Text = "Cycles completed: " + cycles;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            string newfile = onlineDB.IsNewFileAvailable();
            if (newfile.Length > 0)
            {
                MsgTypes.printme("there is a new file available: " + newfile, this);
                onlineDB.InsertRecord(newfile);
                processFile(newfile);
            }

            labelFileQty.Text = "Files: " + onlineDB.qtyFilesLogged();

            
        }
        private void buttonList_Click(object sender, EventArgs e)
        {
            string newfile = onlineDB.IsNewFileAvailable();
            if (newfile.Length > 0)
            {
                MsgTypes.printme("there is a new file available: " + newfile, this);
                onlineDB.InsertRecord(newfile);
            }

        }
        private void buttonProcess_Click(object sender, EventArgs e)
        {
            if (processFile(getFileName()))
            {
                MsgTypes.printme("file processed: " + getFileName(), this);
                textBox1.Clear();
            }
            else
            {
                MsgTypes.printme("could not proccess file: " + getFileName(), this);
            }
        }

        private string getFileName()
        {
            return textBox1.Text;
        }
        #endregion


        #region Logic
        private bool login()
        {

            bool loggedIn = false;

            var loginButton = Tools.OnlineChrome.WaitForElementById("BtnLogin");
            MsgTypes.printme("7.1 button: " + loginButton.Text, this);
            var username = Tools.OnlineChrome.FindElementByXPath("/html/body/section[1]/div[1]/div[4]/div/input");
            if (username != null)
                username.SendKeys("rlj_abrmor");
            MsgTypes.printme("7.2 usernameTextbox: " + username.TagName, this);

            var password = Tools.OnlineChrome.FindElementByXPath("/html/body/section[1]/div[1]/div[5]/div/input");
            if (password != null)
                password.SendKeys("Online.1010");
            MsgTypes.printme("7.3 usernameTextbox: " + password.TagName, this);


            if (username != null && password != null)
            {
                if (loginButton != null)
                {
                    loginButton.Click();
                    MsgTypes.printme("7.3 login button clicked.", this);


                    var welcomeMessage = Tools.OnlineChrome.FindElementByXPath("/html/body/section[2]/div[4]/section[2]/div[1]/div[1]/div/p[1]/text()");
                    loggedIn = welcomeMessage != null;


                    return true;
                }
            }

            return loggedIn;

        }
        private void runReport()
        {
            var reportButton = Tools.OnlineChrome.FindElementByXPath("/html/body/section[2]/div[2]/div[3]/span");
            if (reportButton != null)
            {
                reportButton.Click();
                MsgTypes.printme("9 report button clicked", this);
            }
            System.Threading.Thread.Sleep(5000);
            var get_report_button = Tools.OnlineChrome.WaitForElementById("Report_CmdGetReport", 10);

            if (get_report_button != null)
            {
                get_report_button.Click();
                MsgTypes.printme("9.1 get report button clicked", this);
                System.Threading.Thread.Sleep(5000);

                var report_count_label = Tools.OnlineChrome.WaitForElementById("ReportTotalCount", 10);
                if(report_count_label != null)
                {                    
                    var download_report_button = Tools.OnlineChrome.WaitForElementById("ReportDownload", 10);
                    if (download_report_button != null)
                    {
                        download_report_button.Click();
                        MsgTypes.printme("9.2 download report button clicked", this);
                    }
                }

            }




        }
       
        private bool processFile(string name)
        {
            MsgTypes.printme("processing file : " + name,this);
            bool result = pyhelper.run_processer(name);
            onlineDB.markFileProcessed(name);
            return result;
        }

        #endregion

        

    
        private void FrmMonitor_Load(object sender, EventArgs e)
        {
            initForm();

            MsgTypes.printme("timer 1: " + timer1.Interval.ToString(),this);
            MsgTypes.printme("timer 2: " + timer2.Interval.ToString(),this);

        }


        #region Debug
        public bool isDebugMode()
        {
            if (Debugger.IsAttached)
            {
                // Since there is a debugger attached, assume we are running from the IDE
                return true;
            }
            else
            {
                return false;
                // Assume we aren't running from the IDE
            }
        }
        #endregion

    }
}
