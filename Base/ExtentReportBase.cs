using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using MLAutoFramework.Config;
using MLAutoFramework.Helpers;
using System;
using System.Net.Mail;
using System.Text;

namespace MLAutoFramework.Base
{

    public class ExtentReportBase : TestBase
    {

        //Getting the Project Path
        public static string ProjectPath
        {
            get
            {
                string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string actualPath = path.Substring(0, path.LastIndexOf("bin"));
                string projectPath = new Uri(actualPath).LocalPath;
                return projectPath;
            }
        }


        //Getting the Report Path
        public static string ReportName
        {
            get
            {
                //string MLEHRBuildVersion = Settings.MLEHRBuildVersion;
                //string MLMobileBuildVersion = Settings.MLMobileBuildVersion;
                //string TestReportName = Settings.TestReportName;
                //string scriptName = this.GetType().Name;
                //string reportPath = ProjectPath + TestReportName + "_" + scriptName + "_EHRVersion_" + MLEHRBuildVersion + "_MobileVersion_" + MLMobileBuildVersion + ".html";
                string reportPath = ProjectPath + "_ExtentReport.html";
                return reportPath;
            }
        }


        //Generating Extent Report
        public static void StartReport()
        {
            if (Settings.IEVersion == null)
            {
                ConfigReader.SetFrameworkSettings();
            }
            // False flag append the same report, True flag generates new fresh report & overwrites the existing report
            extent = new ExtentReports(ReportName, Settings.ReplaceExistingTestResult, DisplayOrder.OldestFirst);
            //extent.AddSystemInfo("Module Name", this.GetType().Name);
            //extent.AddSystemInfo("ML EHR Version", Settings.MLEHRBuildVersion);
            //extent.AddSystemInfo("ML Mobile Version", Settings.MLMobileBuildVersion);
            extent.AddSystemInfo("IE Version", Settings.IEVersion);
            //extent.AddSystemInfo("Firefox Version", Settings.FFVersion);
            //extent.AddSystemInfo("Chrome Version", Settings.ChromeVersion);
            extent.LoadConfig(ProjectPath + "extentreport_config.xml");
        }


        //Flush extent report
        public static void StopReport(IWebDriver driver, string stepName, string scenarioTitle)
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            //var stepname = TestContext.CurrentContext.Test.Name;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
            var errorMessage = TestContext.CurrentContext.Result.Message;
            LogStatus logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = LogStatus.Skip;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }

            if (status == TestStatus.Failed)
            {
                string screenShotPath = TakeScreenShot(driver);
                test.Log(logstatus, scenarioTitle, "Test Step **" + stepName + "** !!" + logstatus + "!! In Scenario **" + scenarioTitle + "** " + stacktrace + errorMessage);
                test.Log(logstatus, "Snapshot below: " + test.AddScreenCapture(screenShotPath));
                driver.Close();
            }
            else
            {
                test.Log(logstatus, scenarioTitle, "Test scenario **" + scenarioTitle + "** ended with !!" + logstatus + "!!" + stacktrace + errorMessage);
            }

            extent.EndTest(test);
            extent.Flush();
        }


        //Take screenshot
        public static string TakeScreenShot(IWebDriver driver)
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                string stepName = TestContext.CurrentContext.Test.Name;
                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                Console.WriteLine("Before");
                string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + Settings.ScreenShotLocation + stepName + ".png";
                Console.WriteLine("After");
                string localpath = new Uri(finalpth).LocalPath;
                ss.SaveAsFile(localpath);
                Console.WriteLine("End");
                return localpath;
            }
            catch (Exception e)
            {
                LogHelper.LogException(e);
                throw;
            }
        }



        //Email extent report
        public static void EmailReport()
        {
            try
            {
                if (Settings.SendEmailReport)
                {
                    SmtpClient mailClient = new SmtpClient();
                    mailClient.Port = Settings.SMTPPort;
                    mailClient.Host = Settings.SMTPHost;
                    mailClient.EnableSsl = Settings.SMTPEnableSSL;
                    mailClient.Timeout = Settings.SMTPTimeout;
                    mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    mailClient.UseDefaultCredentials = false;
                    mailClient.Credentials = new System.Net.NetworkCredential(Settings.SMTPUserName, Settings.SMTPPassword);
                    MailMessage mail = new MailMessage(Settings.EmailFrom, Settings.EmailGroup);
                    mail.Subject = Settings.EmailSubject;
                    mail.Attachments.Add(new System.Net.Mail.Attachment(ReportName));
                    mail.Body = Settings.EmailBody;
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    mailClient.Send(mail);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
            }
        }
    }
}
