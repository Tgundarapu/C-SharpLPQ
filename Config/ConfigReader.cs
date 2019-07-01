using System;
using System.Configuration;


namespace MLAutoFramework.Config
{
    public class ConfigReader
    {
        //Initialize elements from App.config file to Settings class
        public static void SetFrameworkSettings()
        {
            Settings.UserName = ConfigurationManager.AppSettings["UserName"];
            Settings.Password = ConfigurationManager.AppSettings["Password"];
            Settings.Question1 = ConfigurationManager.AppSettings["Question1"];
            Settings.Question2 = ConfigurationManager.AppSettings["Question2"];
            Settings.AUT = ConfigurationManager.AppSettings["AUT"];
            Settings.AbsoluteURL = ConfigurationManager.AppSettings["AbsoluteURL"];
            Settings.BuildName = ConfigurationManager.AppSettings["BuildName"];
            Settings.DBName = ConfigurationManager.AppSettings["DBName"];
            Settings.LogPath = ConfigurationManager.AppSettings["LogPath"];
            Settings.TestDataPath = ConfigurationManager.AppSettings["TestDataPath"];
            Settings.ExecutingBrowser = ConfigurationManager.AppSettings["ExecutingBrowser"];
            Settings.ScreenShotLocation = ConfigurationManager.AppSettings["ScreenShotLocation"];
            Settings.ExceptionDestinationType = ConfigurationManager.AppSettings["ExceptionDestinationType"];
            Settings.ExceptionFilePath = ConfigurationManager.AppSettings["ExceptionFilePath"];
            Settings.iDashXPath = string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["iDashXPath"]) ? "//*[contains(@src,'page/mobile/default.aspx')]" : ConfigurationManager.AppSettings["iDashXPath"];
            Settings.DBConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Default"]);
            Settings.MasterDBConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Master"]);

            #region Reporting Settings
            Settings.MLEHRBuildVersion = ConfigurationManager.AppSettings["MLEHRBuildVersion"];
            Settings.MLMobileBuildVersion = ConfigurationManager.AppSettings["MLMobileBuildVersion"];
            Settings.Environment = ConfigurationManager.AppSettings["Environment"];
            Settings.IEVersion = ConfigurationManager.AppSettings["IEVersion"];
            Settings.FFVersion = ConfigurationManager.AppSettings["FFVersion"];
            Settings.ChromeVersion = ConfigurationManager.AppSettings["ChromeVersion"];
            Settings.TestReportName = ConfigurationManager.AppSettings["TestReportName"];
            Settings.ReplaceExistingTestResult = Convert.ToBoolean(ConfigurationManager.AppSettings["ReplaceExistingTestResult"]);
            #endregion Reporting Settings

            #region SMTP Settings
            Settings.EmailGroup = ConfigurationManager.AppSettings["EmailGroup"];
            Settings.SMTPHost = ConfigurationManager.AppSettings["SMTPHost"];
            Settings.SMTPPort = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]);
            Settings.SMTPUserName = ConfigurationManager.AppSettings["SMTPUserName"];
            Settings.SMTPPassword = ConfigurationManager.AppSettings["SMTPPassword"];
            Settings.SMTPTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPTimeout"]);
            Settings.SMTPEnableSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["SMTPEnableSSL"]);
            Settings.EmailSubject = ConfigurationManager.AppSettings["EmailSubject"];
            Settings.SendEmailReport = Convert.ToBoolean(ConfigurationManager.AppSettings["SendEmailReport"]);
            Settings.EmailFrom = ConfigurationManager.AppSettings["EmailFrom"];
            Settings.EmailBody = ConfigurationManager.AppSettings["EmailBody"];
            #endregion SMTP Settings

            Settings.EnableDBSnapshot= Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDBSnapshot"]);

        }
    }
}
