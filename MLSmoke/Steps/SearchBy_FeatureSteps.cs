using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using MLAutoFramework.Base;
using MLAutoFramework.Extensions;
using MLAutoFramework.Helpers;
using MLAutoFramework.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace MLAutoFramework.Steps
{
    [Binding]
    public class SearchBy_FeatureSteps : TestBase
    {
        private IWebDriver _driver;

        public SearchBy_FeatureSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        static int j;
        static string valid_member_number = "9900";
        static string invalid_member_number = "8456";
        static string valid_ssn = "000000001";
        static string invalid_ssn = "000000013";
        static string valid_firstName = "MARISOL";
        static string invalid_firstName = "INVALID";
        static string valid_lastName = "TESTCASE";
        static string invalid_lastName = "INVALID";
        static string valid_appNumber = "3596";
        static string invalid_appNumnber = "9680";
        static string valid_UniversalLoanID = "331062";
        static string invalid_UniversalLoanID = "331056";



        [Given(@"User Login successfully")]
        public void GivenUserLoginSuccessfully()
        {
            
        }

        [When(@"User select the Loan APP Number from the drop down")]
        public void WhenUserSelectTheLoanAPPNumberFromTheDropDown()
        {
            //Select Loan App Number from dropdown
            _driver.FindElement(HomePage.Qs_SearchBy).SelectDropDown("Loan App Number");
            test.Log(LogStatus.Info, "Loan APP Number selected from the dropdown");
        }

        [When(@"User enters valid APP number and Click Search")]
        public void WhenUserEntersValidAPPNumberAndClickSearch()
        {
            //Enter valid App number in search box
            _driver.FindElement(HomePage.Qs_txtQuickLoanNumber).EnterText(valid_appNumber);

            //Click Search button
            _driver.FindElement(HomePage.Headerbutton_search).Click();
            _driver.WaitForPageLoad();
        }

        [When(@"User enters invalid APP number and Click Search")]
        public void WhenUserEntersInvalidAPPNumberAndClickSearch()
        {
            //Enter invalid App number in search box
            _driver.FindElement(HomePage.Qs_txtQuickLoanNumber).EnterText(invalid_appNumnber);
        }

        [When(@"User select the First Name from the drop down")]
        public void WhenUserSelectTheFirstNameFromTheDropDown()
        {
            //Select First Name from dropdown
            _driver.FindElement(HomePage.Qs_SearchBy).SelectDropDown("First Name");
            test.Log(LogStatus.Info, "First Name selected from the dropdown");
        }

        [When(@"User enters valid first name and Click Search")]
        public void WhenUserEntersValidFirstNameAndClickSearch()
        {
            //Enter valid first name in search box
            _driver.FindElement(HomePage.Qs_txtQuickLoanNumber).EnterText(valid_firstName);

            //Click Search button
            _driver.FindElement(HomePage.Headerbutton_search).Click();

            _driver.WaitForPageLoad();
        }

        [When(@"User enters invalid first name and Click Search")]
        public void WhenUserEntersInvalidFirstNameAndClickSearch()
        {
            //Enter invalid first name in search box
            _driver.FindElement(HomePage.Qs_txtQuickLoanNumber).EnterText(invalid_firstName);
        }

        [When(@"User select the Last Name from the drop down")]
        public void WhenUserSelectTheLastNameFromTheDropDown()
        {
            //Select Last Name from dropdown
            _driver.FindElement(HomePage.Qs_SearchBy).SelectDropDown("Last Name");
            test.Log(LogStatus.Info, "Last Name selected from the dropdown");
        }

        [When(@"User enters valid lasst name and Click Search")]
        public void WhenUserEntersValidLasstNameAndClickSearch()
        {
            //Enter valid last name in search box
            _driver.FindElement(HomePage.Qs_txtQuickLoanNumber).EnterText(valid_lastName);

            //Click Search button
            _driver.FindElement(HomePage.Headerbutton_search).Click();
        }

        [When(@"User enters invalid last name and Click Search")]
        public void WhenUserEntersInvalidLastNameAndClickSearch()
        {
            //Enter invalid last name in search box
            _driver.FindElement(HomePage.Qs_txtQuickLoanNumber).EnterText(invalid_lastName);
        }

        [Then(@"Same APP number should be displayed in the loaded Application")]
        public void ThenSameAPPNumberShouldBeDisplayedInTheLoadedApplication()
        {
            //Thread.Sleep(5000);
            _driver.WaitForPageLoad();
            //Assertion for Valid App number
            _driver.FindElement(LoanPage.Sb_LoanNumber).AssertTagText(valid_appNumber);

            _driver.WaitForPageLoad();
        }

        [Then(@"Pop up should be displayed as No Results found")]
        public void ThenPopUpShouldBeDisplayedAsNoResultsFound()
        {
            _driver.AlertTextVerify(_driver.FindElement(HomePage.Headerbutton_search), "No results found");
        }

        [Then(@"Same first name APP should be displayed in the name column of the results found")]
        public void ThenSameFirstNameAPPShouldBeDisplayedInTheNameColumnOfTheResultsFound()
        {
            IList<IWebElement> list = _driver.FindElements(HomePage.MainContent_dg);
            IList<IWebElement> columns = _driver.FindElements(HomePage.FirstRow);

            for (j = 1; j <= columns.Count; j++)
            {
                String columName = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[1]/td[" + j + "]")).GetText();
                if (columName.Contains("Name"))
                    break;
            }
            for (int i = 2; i <= list.Count; i++)
            {

                String fname = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[" + i + "]/td[" + j + "]/a")).GetText();
                Console.WriteLine(fname);
                Assert.IsTrue(fname.EndsWith(valid_firstName));
            }

        }

        [Then(@"Same last name APP should be displayed in the name column of the results found")]
        public void ThenSameLastNameAPPShouldBeDisplayedInTheNameColumnOfTheResultsFound()
        {
            IList<IWebElement> list = _driver.FindElements(HomePage.MainContent_dg);
            IList<IWebElement> columns = _driver.FindElements(HomePage.FirstRow);

            for (j = 1; j <= columns.Count; j++)
            {
                String columName = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[1]/td[" + j + "]")).GetText();
                if (columName.Contains("Name"))
                    break;
            }

            for (int i = 2; i <= list.Count; i++)
            {
                String lname = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[" + i + "]/td[" + j + "]")).GetText();
                Console.WriteLine(lname);
                Assert.IsTrue(lname.StartsWith(valid_lastName));
            }
        }
        [When(@"User select the SSN from the drop down")]
        public void WhenUserSelectTheSSNFromTheDropDown()
        {
            //Select SSN from dropdown
            _driver.FindElement(HomePage.Qs_SearchBy).SelectDropDown("SSN");
        }

        [When(@"User enters valid SSN and Click Search")]
        public void WhenUserEntersValidSSNAndClickSearch()
        {
            //Enter Valid SSN number
            _driver.FindElement(HomePage.Qs_txtQuickLoanNumber).EnterText(valid_ssn);

            //Click Search button
            _driver.FindElement(HomePage.Headerbutton_search).Click();
        }

        //This will assert that Same SSN APP should be displayed in the Last 4 SSN column of the results found
        [Then(@"Same SSN APP should be displayed in the Last 4 SSN column of the results found")]
        public void ThenSameSSNAPPShouldBeDisplayedInTheLastSSNColumnOfTheResultsFound()

        {
            IList<IWebElement> list = _driver.FindElements(HomePage.MainContent_dg);
            IList<IWebElement> columns = _driver.FindElements(HomePage.FirstRow);

            for (j = 1; j <= columns.Count; j++)
            {
                String columName = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[1]/td[" + j + "]")).GetText();
                if (columName.Contains("SSN"))
                    break;
            }

            for (int i = 2; i <= list.Count; i++)
            {
                String ssn = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[" + i + "]/td[" + j + "]")).GetText();
                Console.WriteLine("ssn: " + ssn);
                Console.WriteLine("valid_ssn: " + valid_ssn);
                int ssn_length = valid_ssn.Length;
                StringBuilder last_four_ssn = new StringBuilder();
                for (int k = ssn_length - 4; k < ssn_length; k++)
                {
                    char[] valid_ssn_array = valid_ssn.ToCharArray();
                    string char_ssn = valid_ssn_array.GetValue(k).ToString();
                    last_four_ssn.Append(char_ssn);
                }

                Console.WriteLine(ssn_length);
                Console.WriteLine(last_four_ssn.ToString());
                Assert.IsTrue(ssn.EndsWith(last_four_ssn.ToString()));
            }
            Console.WriteLine("passessssssssss");
        }
        [When(@"User enters invalid SSN and Click Search")]
        public void WhenUserEntersInvalidSSNAndClickSearch()
        {
            //Enter Invalid SSN number
            _driver.FindElement(HomePage.Qs_txtQuickLoanNumber).EnterText(invalid_ssn);
        }

        [When(@"User select the Member Number from the drop down")]
        public void WhenUserSelectTheMemberNumberFromTheDropDown()
        {
            //Select Member Number from dropdown
            _driver.FindElement(HomePage.Qs_SearchBy).SelectDropDown("Member Number");
        }

        [When(@"User enters valid Member Number and Click Search")]
        public void WhenUserEntersValidMemberNumberAndClickSearch()
        {
            //Enter Valid Member Number
            _driver.FindElement(HomePage.Qs_txtQuickLoanNumber).EnterText(valid_member_number);

            //Click Search button
            _driver.FindElement(HomePage.Headerbutton_search).Click();
        }

        [Then(@"Same Member Number APP should be displayed in the Member\# column of the results found")]
        public void ThenSameMemberNumberAPPShouldBeDisplayedInTheMemberColumnOfTheResultsFound()
        {
            IList<IWebElement> list = _driver.FindElements(HomePage.MainContent_dg);
            IList<IWebElement> columns = _driver.FindElements(HomePage.FirstRow);

            for (j = 1; j <= columns.Count; j++)
            {
                String columName = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[1]/td[" + j + "]")).GetText();
                if (columName.Contains("Member"))
                    break;
            }


            for (int i = 2; i <= list.Count; i++)
            {
                String ssn = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[" + i + "]/td[" + j + "]")).GetText();
                Console.WriteLine(ssn);
                Assert.IsTrue(ssn.StartsWith(valid_member_number));
            }
        }

        [When(@"User enters invalid Member Number and Click Search")]
        public void WhenUserEntersInvalidMemberNumberAndClickSearch()
        {
            //Enter Invalid Member Number
            _driver.FindElement(HomePage.Qs_txtQuickLoanNumber).EnterText(invalid_member_number);
        }

        [When(@"User select the Universal Loan ID from the drop down")]
        public void WhenUserSelectTheUniversalLoanIDFromTheDropDown()
        {
            //Select Universal Loan ID from drop down
            _driver.FindElement(HomePage.Qs_SearchBy).SelectDropDown("Universal Loan ID");
        }

        [When(@"User enters valid Universal ID and Click Search")]
        public void WhenUserEntersValidUniversalIDAndClickSearch()
        {
            //Enter valid Universal Loan ID
            _driver.FindElement(HomePage.Qs_txtQuickLoanNumber).EnterText(valid_UniversalLoanID);

            //Click on search button
            _driver.FindElement(HomePage.Headerbutton_search).Click();

            Thread.Sleep(10000);
            _driver.WaitForPageLoad();


        }

        [When(@"In Loan Info click on HMDA info")]
        public void WhenInLoanInfoClickOnHMDAInfo()
        {
            //Click on HMDA info
            _driver.FindElement(HE_EasyApplication_Page.Lab_lbtnHMDAInfo).Click();

            _driver.WaitForPageLoad();
        }

        [Then(@"Same Universal loan ID should be displayed in the universal Loan identifier text box")]
        public void ThenSameUniversalLoanIDShouldBeDisplayedInTheUniversalLoanIdentifierTextBox()
        {
            //Assertion for Valid Universal Loan ID 
            Assert.AreEqual(_driver.FindElement(HE_HMDAIformation_Pgae.HMDAFields_UniversalLoanIdentifier).GetAttributeValue("value"), valid_UniversalLoanID);
        }

        [When(@"User enters invalid Universal Loan ID and Click Search")]
        public void WhenUserEntersInvalidUniversalLoanIDAndClickSearch()
        {
            //Enter Invalid Universal Loan ID
            _driver.FindElement(HomePage.Qs_txtQuickLoanNumber).EnterText(invalid_UniversalLoanID);
        }

        [When(@"In Action \? column click the View APP icon")]
        public void WhenInActionColumnClickTheViewAPPIcon()
        {
            //Click on the view APP icon
            _driver.FindElement(HomePage.ViewAPP).Click();
           
            _driver.WaitForPageLoad();


        }

        [Then(@"APP should be displayed with all the headings Laon Info,Custom Questions,Comments ,Borrower Info,Liabilities,Assets,Underwriting Info,Disbursements")]
        public void ThenAPPShouldBeDisplayedWithAllTheHeadingsLaonInfoCustomQuestionsCommentsBorrowerInfoLiabilitiesAssetsUnderwritingInfoDisbursements()
        {
            WindowHelper.switchToChildWindow(_driver);
           _driver.WaitForPageLoad();

            IList<IWebElement> headings = _driver.FindElements(LoanViewPage.Headings);
            Console.WriteLine("count is:"+headings.Count);
          
            StringBuilder anchorHeadings = new StringBuilder();
            StringBuilder expectedHeadings = new StringBuilder();
            expectedHeadings.Append("Loan Info,Custom Questions,Comments,Borrower Info,Liabilities,Assets,Underwriting Info,Disbursements,");
            foreach (IWebElement head in headings)
            {
               String heading= head.GetText().ToString();
               anchorHeadings.Append(heading+",");
            }
            
            
            Assert.IsTrue(expectedHeadings.ToString().Equals(anchorHeadings.ToString()));
            _driver.Close();

            WindowHelper.switchToMainWindow(_driver, main_window);

        }
    }
}
