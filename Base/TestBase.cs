using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using RelevantCodes.ExtentReports;
using MLAutoFramework.Config;
using MLAutoFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using MLAutoFramework.Extensions;

namespace MLAutoFramework.Base
{
    public class TestBase //UnitTestBase
    {
        public static ExtentReports extent;
        public static ExtentTest test;
        public static IReadOnlyCollection<IWebElement> element;
        public static string main_window;
        private static string _SnapShotFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        IEnumerable<int> _browserInstance;
        public string CurrentBrowser { get; set; }
        private IWebDriver _driver { get; set; }


        //Open desired browser
        private IWebDriver zOpenBrowser(String Browser)//we dont want user to invoke browser 
        {
            switch (Browser.ToUpper())//To hadle any case mistmatch
            {
                //case BrowserType.IE:
                case "IE":
                    // http://stackoverflow.com/questions/14952348/not-able-to-launch-ie-browser-using-selenium2-webdriver-with-java
                    //Please follow above instructions above to setup IE 

                    _driver = new InternetExplorerDriver();
                    break;

                case "FIREFOX":
                    _driver = new FirefoxDriver();
                    break;

                case "CHROME":
                    _driver = new ChromeDriver();
                    break;

                case "SAFARI":
                    _driver = new SafariDriver();
                    break;

                case "EDGE":
                    _driver = new EdgeDriver();
                    break;

                case "OPERA":
                    _driver = new OperaDriver();
                    break;

                default:
                    _driver = new ChromeDriver();
                    break;
            }
            return _driver;
        }


        //Take screenshot
        public void TakeScreenshot(string ImageFileName)
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
                ss.SaveAsFile(Settings.ScreenShotLocation + ImageFileName + "_" + _SnapShotFileName + ".jpeg");
            }
            catch (Exception e)
            {
                LogHelper.LogException(e);
                throw;
            }
        }


        //Set up test environment, i.e., create instance of Extent report and log file
        public void TestSetUp(string TestScriptName, bool useTestData = true)
        {
            try
            {
                //Helpers.DataBaseHelper.ManageDBSnapshot(true);
                //StartUp(UnitTestDBName);
                string testDatafileName = string.Empty;
                if (useTestData)
                {
                    //PopulateExcelData(TestScriptName);
                    ExtentReportBase.StartReport();
                }
                LogHelper.CreateLogFile(TestScriptName);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                throw;
            }
        }


        //Email report
        public void TestFinalize()
        {
            ExtentReportBase.EmailReport();
            //DataBaseHelper.ManageDBSnapshot(false);
        }


        //Open browser, and create instance of extent test
        public IWebDriver StartTestExecution(String Browser, String scenario)
        {
            try
            {
                CurrentBrowser = Browser;
                _browserInstance = zGetCurrentBrowserInstances(Browser);
                var testname = scenario;
                //TestContext.CurrentContext.Test.Name
                test = extent.StartTest(testname + "_" + Browser);
                _driver = zOpenBrowser(Browser);
                test.Log(LogStatus.Info, "Browser Launched");
                MaximizeBrowser();
                DeleteAllCookies();
                _driver.WaitForPageLoad();
                return _driver;
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                throw;
            }
        }


        //Delete cookies, flush extent report, and kill process
        public void TestCleanUp()
        {
            try
            {
                DeleteAllCookies();
                // Cleanup(UnitTestDBName);
                if (_driver != null)
                {
                    //ExtentReportBase.StopReport(_driver);
                    Process[] FirefoxDriverProcesses = Process.GetProcessesByName("firefox");

                    foreach (var FirefoxDriverProcess in FirefoxDriverProcesses)
                    {
                        FirefoxDriverProcess.Kill();
                    }
                    _driver.Quit();
                    zCloseBrowser(CurrentBrowser);
                }
                //_driver.Dispose();
                LogHelper.Write("Closed the Browser");
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
            }
        }


        //Kill process and close browser
        private void zCloseBrowser(string browser)
        {
            IEnumerable<int> currentInstance;
            var currentBrowserInstances = zGetCurrentBrowserInstances(browser);
            if (_browserInstance != null && _browserInstance.Any())
            {
                currentInstance = currentBrowserInstances.Except(_browserInstance);
            }
            else
            {
                currentInstance = currentBrowserInstances;
            }

            foreach (int instance in currentInstance)
            {
                Process.GetProcessById(instance).Kill();
                _driver.Dispose();
            }
        }


        //Get current browser instance
        private IEnumerable<int> zGetCurrentBrowserInstances(string browser)
        {
            string processName = string.Empty;
            List<int> pIdList = null;
            switch (browser.ToUpper())
            {
                case "IE":
                    processName = "iexplore";
                    break;
                case "CHROME":
                    processName = "Chrome";
                    break;
                case "FIREFOX":
                    processName = "Firefox";
                    break;

            }
            if (!string.IsNullOrEmpty(processName))
            {
                Process[] processArray = Process.GetProcessesByName(processName);
                if (processArray != null && processArray.Length > 0)
                {
                    pIdList = new List<int>();
                    foreach (Process p in processArray)
                    {
                        pIdList.Add(p.Id);
                    }
                }
            }
            return pIdList;
        }


        //Clear IE cache
        public void ClearIECache()
        {
            var options = new InternetExplorerOptions();
            options.EnsureCleanSession = true;
            _driver = new InternetExplorerDriver(options);
        }


        //Launch URL
        public void NavigateToURL()
        {
            //string URL = "https://beta.loanspq.com/login.aspx?enc2=36aNbmudSLCCMdjJoYQn6iT9nG7GRjqBbkIAMYcy9aM";
            //**Me Make comment

            string AbsoluteURL = Settings.AbsoluteURL;
            string URL = Settings.AUT;
            //string MachineName = System.Environment.MachineName;
            string Environment = Settings.Environment;
            URL = "https://" + Environment + "." + URL;
            if ((!String.IsNullOrEmpty(AbsoluteURL)))
            {
                _driver.Navigate().GoToUrl(AbsoluteURL);
            }
            else
            {
                _driver.Navigate().GoToUrl(URL);
            }

            LogHelper.Write("Navigated to the URL");
        }


        public static IEnumerable<String> BrowserToRunWith()
        {
            String[] browsers = null;
            if (Settings.ExecutingBrowser == null)
            {
                ConfigReader.SetFrameworkSettings();
            }
            browsers = Settings.ExecutingBrowser.Split(',');
            foreach (String b in browsers)
            {
                yield return b;
            }
        }


        //Navigate Forward
        public void NavigateForward()
        {
            _driver.Navigate().Forward();
        }


        //Navigate Back
        public void NavigateBack()
        {
            _driver.Navigate().Back();
        }


        


        //Maximize the browser
        public void MaximizeBrowser()
        {
            _driver.Manage().Window.Maximize();
        }


        //Delete all Cookies
        public void DeleteAllCookies()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
        }


        //Resize browser in Apple tab size
        public void ResizeBrowserToTabSize()
        {
            //DriverContext.Driver.Manage().Window.Size = new Size(960, 640);
            ResizeBrowser(960, 640);
        }


        //Populate Excel data in Data Table
        public void PopulateExcelData(string testScripName)
        {
            string testDatafileName = Settings.TestDataPath + testScripName + ".xlsx";
            ExcelHelper.PopulateInCollection(testDatafileName);
        }


        //Resize browser in resired size
        public void ResizeBrowser(int width, int height)
        {
            _driver.Manage().Window.Size = new System.Drawing.Size(width, height);
        }


        internal class ExtentManager
        {
            private static readonly ExtentReports _instance =
                new ExtentReports("Extent.Net.html", DisplayOrder.OldestFirst);

            static ExtentManager() { }

            private ExtentManager() { }

            public static ExtentReports Instance
            {
                get
                {
                    return _instance;
                }
            }
        }
    }
}
