using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace OnlineDataDownloadeer.Classes
{
    class OnlineDriver
    {
        private IWebDriver Driver;

        private System.Windows.Forms.Form commingFrom;
        public OnlineDriver(System.Windows.Forms.Form commingFrom)
        {
            this.commingFrom = commingFrom;
        }

        private void login(string user, string password)
        {

        }

        public void Open(string chromeDriverPath = "", bool hideCmdPrompt = true)
        {
            if (chromeDriverPath == "")
                chromeDriverPath = Path.GetDirectoryName(Application.ExecutablePath);

            var chromeDriverService =
                ChromeDriverService.CreateDefaultService(chromeDriverPath);

            chromeDriverService.HideCommandPromptWindow = hideCmdPrompt;

            Driver = new ChromeDriver(chromeDriverService, new ChromeOptions());
        }
        public void Navigate(string url)
        {
            if (Driver == null)
                return;

            Driver.Url = url;
        }

        public IWebElement WaitForElementById(string elementId, int timeoutSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds));
                var element = wait.Until(x => x.FindElement(By.Id(elementId)));
                return element;
            }
            catch
            {
                return null;
            }
        }

        public IWebElement WaitForElementByTagName(string tagName, int timeoutSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds));
                var element = wait.Until(x => x.FindElement(By.TagName(tagName)));
                return element;
            }
            catch
            {
                return null;
            }
        }

        //public IWebElement FindElementByXPath(IWebElement element, string xPath)
        public IWebElement FindElementByXPath(string xPath)
        {
            try
            {
                //var outputElement = element.FindElement(By.XPath(xPath));
                var outputElement = Driver.FindElement(By.XPath(xPath));
                return outputElement;
            }
            catch
            {
                return null;
            }
        }

        public void Minimize()
        {
            if (Driver == null)
                return;

            try
            {
                Driver.Manage().Window.Minimize();
            }
            catch { }
        }

        public void Maximize()
        {
            if (Driver == null)
                return;

            try
            {
                Driver.Manage().Window.Maximize();
            }
            catch { }
        }

        public void Close()
        {
            if (Driver != null)
            {
                try
                {
                    Driver.Close();
                }
                catch { }
            }
        }

        public bool IsAlive()
        {
            try
            {
                string title = Driver.Title;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Quit()
        {
            try
            {
                if (Driver != null)
                    Driver.Quit();
            }
            catch { }
        }
    }
}
