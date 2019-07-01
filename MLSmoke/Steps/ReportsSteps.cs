using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using MLAutoFramework.Base;
using MLAutoFramework.Extensions;
using MLAutoFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using MLAutoFramework.PageObjects;

namespace MLAutoFramework.Steps
{
    [Binding]
    public class ReportsSteps:TestBase
    {
        private IWebDriver _driver;

        public ReportsSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        public String customReportTitle = "Test Amount Approved";
        String createdReportName;
        Actions action;
        SelectElement select;
        [Given(@"User login to application")]
        public void GivenUserLoginToApplication()
        {
           
        }
        
        [Given(@"User navigated to Reports page")]
        public void GivenUserNavigatedToReportsPage()
        {
            action = new Actions(_driver);
            action.MoveToElement(_driver.FindElement(HomePage.MouseHover_Tools)).Build().Perform();
            Thread.Sleep(3000);
            action.MoveToElement(_driver.FindElement(HomePage.MouseHover_Reports)).Build().Perform();
            Thread.Sleep(3000);
            action.MoveToElement(_driver.FindElement(HomePage.MouseHover_RunSchedule)).Click().Build().Perform();
            Thread.Sleep(10000);
        }
        [Given(@"User selected Approved Loans Pre-built reports in XLS format")]
        public void GivenUserSelectedApprovedLoansPre_BuiltReportsInXLSFormat()
        {
            _driver.FindElement(ReportsPage.approved_Loans).Click();
            Thread.Sleep(5000);
            select = new SelectElement(_driver.FindElement(ReportsPage.display_Type));
            select.SelectByText("XLS");
            Thread.Sleep(2000);
        }


        [Given(@"User selected Pre-built Credit Score reports")]
        public void GivenUserSelectedPre_BuiltCreditScoreReports()
        {
            WebElementExtension.Click(_driver.FindElement(ReportsPage.credit_Score));
            Thread.Sleep(3000);
        }

        [Given(@"User selected pre-built Credit Score Reports for Vehicle App")]
        public void GivenUserSelectedPre_BuiltCreditScoreReportsForVehicleApp()
        {
            WebElementExtension.Click(_driver.FindElement(ReportsPage.credit_Score));
            Thread.Sleep(3000);
            select = new SelectElement(_driver.FindElement(ReportsPage.loan_Type));
            Thread.Sleep(3000);
            select.SelectByText("Vehicle");
            Thread.Sleep(3000);
        }
        
       [Given(@"User selected Credit Score Reports in PDF format for Vehicle App")]
        public void GivenUserSelectedCreditScoreReportsInPDFFormatForVehicleApp()
        {
            WebElementExtension.Click(_driver.FindElement(ReportsPage.credit_Score));
            Thread.Sleep(3000);
            select = new SelectElement(_driver.FindElement(ReportsPage.display_Type));
            Thread.Sleep(3000);
            select.SelectByText("PDF");
            Thread.Sleep(3000);
        }
       
        [Given(@"User selected Approved Loans Pre-built reports")]
        public void GivenUserSelectedApprovedLoansPre_BuiltReports()
        {
            WebElementExtension.Click(_driver.FindElement(ReportsPage.approved_Loans));
            Thread.Sleep(3000);
        }

        [When(@"User ran Credit Score reports")]
        public void WhenUserRanCreditScoreReports()
        {
            WebElementExtension.Click(_driver.FindElement(ReportsPage.show_Report));
            Thread.Sleep(3000);
        }
        [When(@"User ran Credit Score reports for Vehicle App")]
        public void WhenUserRanCreditScoreReportsForVehicleApp()
        {
            WebElementExtension.Click(_driver.FindElement(ReportsPage.show_Report));
            Thread.Sleep(3000);
        }

        [When(@"User ran Approved Loans Pre-built reports in XLS format")]
        public void WhenUserRanApprovedLoansPre_BuiltReportsInXLSFormat()
        {
            WebElementExtension.Click(_driver.FindElement(ReportsPage.show_Report));
            Thread.Sleep(10000);
            //Process.Start("C://Users//tgundarapu//Documents//ClickOnSave.exe");
            Thread.Sleep(3000);
            WindowHelper.switchToChildWindow(_driver);

            //Excel downloand and open file at run time is pending
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver,main_window);
        }

        [When(@"User ran Credit Score reports for Vehicle App in PDF format")]
        public void WhenUserRanCreditScoreReportsForVehicleAppInPDFFormat()
        {
            WebElementExtension.Click(_driver.FindElement(ReportsPage.show_Report));
            Thread.Sleep(3000);
            //Pending: Document downloading at run time 
        }
        [When(@"User ran Approved Loans reports")]
        public void WhenUserRanApprovedLoansReports()
        {
            WebElementExtension.Click(_driver.FindElement(ReportsPage.show_Report));
            Thread.Sleep(3000);
        }

        [When(@"User designed a custom report for Credit Score")]
        public void WhenUserDesignedACustomReportForCreditScore()
        {
            WebElementExtension.SelectDropDown(_driver.FindElement(ReportsPage.bc_ddlReportType), "Custom");
            Thread.Sleep(3000);
            WebElementExtension.Click(_driver.FindElement(ReportsPage.bc_lbtnManageCustomReports));
            Thread.Sleep(3000);
            WebElementExtension.Click(_driver.FindElement(ReportsPage.add_NewCustomReport_Button));
            Thread.Sleep(3000);
            WindowHelper.switchToChildWindow(_driver);
            action = new Actions(_driver);
            WebElementExtension.EnterText(_driver.FindElement(ReportsPage.textBox_Report_Title), customReportTitle);
            WebElementExtension.Click(_driver.FindElement(ReportsPage.add_NewColumn_Link));
            Thread.Sleep(3000);
            action.MoveToElement(_driver.FindElement(ReportsPage.general_Loan_Fields)).Build().Perform();
            Thread.Sleep(3000);
            action.MoveToElement(_driver.FindElement(ReportsPage.approved_Amount)).Click().Build().Perform();
            Thread.Sleep(3000);
            WebElementExtension.Click(_driver.FindElement(ReportsPage.btnRunReport));
            Thread.Sleep(3000);
            _driver.SwitchTo().Frame(0);
            Thread.Sleep(3000);
            WebElementExtension.Click(_driver.FindElement(ReportsPage.ButtonSave));
            WindowHelper.switchToMainWindow(_driver, main_window);
        }
        [Given(@"User selected Branch Activities Pre-built reports")]
        public void GivenUserSelectedBranchActivitiesPre_BuiltReports()
        {
            //_driver.FindElement(ReportsPage.branch_Activities).Click();
            Thread.Sleep(2000);
        }

        [When(@"User ran Branch Activities Pre-built reports")]
        public void WhenUserRanBranchActivitiesPre_BuiltReports()
        {
            WebElementExtension.Click(_driver.FindElement(ReportsPage.show_Report));
            Thread.Sleep(3000);
        }

        [Then(@"User verified Branch Activities Pre-built reports")]
        public void ThenUserVerifiedBranchActivitiesPre_BuiltReports()
        {
            //Assertion is pending
        }

        [Then(@"User verified Pre-built Credit Score reports")]
        public void ThenUserVerifiedPre_BuiltCreditScoreReports()
        {
            WindowHelper.switchToChildWindow(_driver);
            Thread.Sleep(3000);
            _driver.SwitchTo().Frame("frame1");
            IList<IWebElement> creditScores = _driver.FindElements(ReportsPage.nobr_Tags);
            var date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            Assert.IsTrue(creditScores[2].GetText().Contains("From " + firstDayOfMonth.ToShortDateString() + " - " + lastDayOfMonth.ToShortDateString()));
            for (int i=0; i<creditScores.Count; i++)
            {
                if (creditScores[i].GetText().Equals("NA")){
                    Console.WriteLine("Credit Score is dispalying NA");
                    Assert.IsTrue(!creditScores[i].GetText().Equals("NA"));
                }
            }

            _driver.SwitchTo().DefaultContent();
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
           
        }
        [Then(@"User verified Credit Score reports for Vehicle App")]
        public void ThenUserVerifiedCreditScoreReportsForVehicleApp()
        {
            WindowHelper.switchToChildWindow(_driver);
            Thread.Sleep(3000);
            _driver.SwitchTo().Frame("frame1");
            IList<IWebElement> creditScores = _driver.FindElements(ReportsPage.nobr_Tags);
            var date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            Assert.IsTrue(creditScores[2].GetText().Contains("From " + firstDayOfMonth.ToShortDateString() + " - " + lastDayOfMonth.ToShortDateString()));
            for (int i = 0; i < creditScores.Count; i++)
            {
               if (creditScores[i].GetText().Equals("NA"))
                {
                    Console.WriteLine("Credit Score is dispalying NA");
                    Assert.IsTrue(!creditScores[i].GetText().Equals("NA"));
                }
            }

            _driver.SwitchTo().DefaultContent();
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            Thread.Sleep(3000);
        }
        [Then(@"User verified Approved Loans reports")]
        public void ThenUserVerifiedApprovedLoansReports()
        {
            var date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            WindowHelper.switchToChildWindow(_driver);
            Thread.Sleep(3000);
            _driver.SwitchTo().Frame("frame1");
            IList<IWebElement> creditScores = _driver.FindElements(ReportsPage.nobr_Tags);
            Assert.IsTrue(creditScores[2].GetText().Contains("From " + firstDayOfMonth.ToShortDateString() + " - " + lastDayOfMonth.ToShortDateString()));
            for (int i = 0; i < creditScores.Count; i++)
            {
                if (creditScores[i].GetText().Equals("NA"))
                {
                    Console.WriteLine("Credit Score is dispalying NA");
                    Assert.IsTrue(!creditScores[i].GetText().Equals("NA"));
                }
            }
            
            _driver.SwitchTo().DefaultContent();
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            Thread.Sleep(3000);
        }

        [Then(@"User verified Credit Score custom report creation")]
        public void ThenUserVerifiedCreditScoreCustomReportCreation()
        {
            IList<IWebElement> list = _driver.FindElements(ReportsPage.table_CustomReports);
            for (int i = 2; i <= list.Count; i++)
            {
                String reportName = _driver.FindElement(By.XPath(".//table[@id='ctl00_bc_dg']//tbody//tr[" + i + "]/td[2]")).GetText();
                Console.WriteLine(reportName);
                if (reportName.Equals(customReportTitle))
                {
                    createdReportName = reportName;
                    break;
                }
            }
            Assert.IsTrue(createdReportName.Equals(customReportTitle));
            Thread.Sleep(3000);
        }

        [Then(@"User verified Credit Score reports with PDF format for Vehicle App")]
        public void ThenUserVerifiedCreditScoreReportsWithPDFFormatForVehicleApp()
        {
            WindowHelper.switchToChildWindow(_driver);
            Thread.Sleep(3000);
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            Thread.Sleep(2000);

            var date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            
            String pdfData = _driver.GetAllTextFromPDF("MAIN//Test//MLAnyWhereAutoTest//Downloads//Viewer_pdf.pdf");
            Assert.IsTrue(pdfData.Contains("From " + firstDayOfMonth.ToShortDateString() + " - " + lastDayOfMonth.ToShortDateString()));
        }

        [Then(@"User verified Approved Loans reports in XLS format")]
        public void ThenUserVerifiedApprovedLoansReportsInXLSFormat()
        {
            // Pending: Excel reading from downloaded document 
            Thread.Sleep(2000);
        }
    }
}
