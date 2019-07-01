using MLAutoFramework.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using MLAutoFramework.Extensions;
using System;
using TechTalk.SpecFlow;
using MLAutoFramework.Helpers;
using System.Threading;
using NUnit.Framework;
using System.Diagnostics;
using MLAutoFramework.Base;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;

using SRSAutoFramework.PageObjects;

namespace MLAutoFramework.MLSmoke.Steps
{
    [Binding]
    public class Documents_FeatureSteps : TestBase
    {
        private IWebDriver _driver;
        private IWebDriver _driver2;
        string generatedlink;
        string filepath = "D:\\test.pdf";
        string title = "doc";
        string filename = "test.pdf";
        string comment_in_textbox = "test";
        string filepath_5mb = "D:\\test5.pdf";
        string filepath_jpg = "D:\\download.jpg";
        string expected_uploadStatusDisplay= "The file you are transferring is too big. Max file size is 3.91MB.";
        

        
        public Documents_FeatureSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [When(@"User selected Vehicle APP")]
        public void WhenUserSelectedVehicleAPP()
        {
            _driver.WaitForPageLoad();
            //rool over to new app 
            Actions action = new Actions(_driver);
            action.MoveToElement(_driver.FindElement(HomePage.Roolover_NewAPP)).Build().Perform();

            //click on vehicle app
            _driver.FindElement(HomePage.New_Vehicle).Click();
            _driver.WaitForPageLoad();

            Thread.Sleep(5000);

        }

        [When(@"User navigated to letter docs")]
        public void WhenUserNavigatedToLetterDocs()
        {
            //click on letter/docs
            _driver.AcceptAlert(_driver.FindElement(LoanPage.lab_lbtnLetters));
            _driver.WaitForPageLoad();
        }

        [When(@"User Attached document")]
        public void WhenUserAttachedDocument()
        {
            //click on attached documents
            Thread.Sleep(5000);
            _driver.FindElement(VE_LetterTemplates_Page.LDocs_btnAttachDoc).Click();
            _driver.WaitForPageLoad();

            //switch to upload document window window
            WindowHelper.switchToChildWindow(_driver);
            _driver.isDialogPresent();
            _driver.WaitForPageLoad();

            //select the title
            _driver.FindElement(UploadLoanDocument_Page.bc_Title).SendKeys(title + Keys.Enter);
            _driver.isDialogPresent();

            //enter the text in the comment box 
            _driver.FindElement(UploadLoanDocument_Page.bc_Comments).EnterText(comment_in_textbox);

            _driver.SwitchTo().Frame(_driver.FindElement(UploadLoanDocument_Page.iframe_file));
            //upload pdf document      
            _driver.FindElement(UploadLoanDocument_Page.fileUpload).UploadDocument(filepath);
            _driver.WaitForPageLoad();

            //switch to default frame
            _driver.SwitchTo().DefaultContent();

            //click on save button
            _driver.FindElement(UploadLoanDocument_Page.Buttons_btnSave).Click();
            _driver.WaitForPageLoad();

            //switch to main window
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
        }

        [When(@"User Click on Display Link of the uploaded document")]
        public void WhenUserClickOnDisplayLinkOfTheUploadedDocument()
        {
            //click on display link
            _driver.FindElement(VE_LetterTemplates_Page.LDocs_lnkDisplay).Click();
            _driver.WaitForPageLoad();
        }

        [Then(@"Print button Should be displayed in the Print Preview Window")]
        public void ThenPrintButtonShouldBeDisplayedInThePrintPreviewWindow()
        {
            //switch to print preview window
            WindowHelper.switchToChildWindow(_driver);

            //switch to frame
            _driver.SwitchTo().Frame(PrintPreview_Page.frame);

            //verify print button should be displayed
            _driver.FindElement(PrintPreview_Page.btnPrint).AssertElementPresent();

            //close the print preview window
            _driver.FindElement(PrintPreview_Page.btnClose).Click();

            //switch to main window
            WindowHelper.switchToMainWindow(_driver, main_window);

        }

        [Then(@"The same PDF document should be displayed in the scanned /Uploaded documents")]
        public void ThenTheSamePDFDocumentShouldBeDisplayedInTheScannedUploadedDocuments()
        {
            Assert.AreEqual(filename, _driver.FindElement(VE_LetterTemplates_Page.LDocs_dg_filename).GetText());

        }

        [When(@"User Attached pdf document of more than 4mb")]
        public void WhenUserAttachedPdfDocumentOfMoreThan4Mb()
        {
            //click on attached documents
            _driver.FindElement(VE_LetterTemplates_Page.LDocs_btnAttachDoc).Click();
            _driver.WaitForPageLoad();

            //switch to upload document window window
            WindowHelper.switchToChildWindow(_driver);
            _driver.isDialogPresent();
            _driver.WaitForPageLoad();

            _driver.SwitchTo().Frame(_driver.FindElement(UploadLoanDocument_Page.iframe_file));
            // upload pdf document      
            _driver.FindElement(UploadLoanDocument_Page.fileUpload).UploadDocument(filepath_5mb);
            _driver.WaitForPageLoad();


        }

        [Then(@"Pop should be displayed as the file you are transferring is too big")]
        public void ThenPopShouldBeDisplayedAsTheFileYouAreTransferringIsTooBig()
        {
            _driver.VerifyAlertText("The file you are transferring is too big");
            _driver.WaitForPageLoad();

            //switch to default frame
            _driver.SwitchTo().DefaultContent();

            //click on close button
            _driver.FindElement(UploadLoanDocument_Page.Close_button).Click();
            _driver.WaitForPageLoad();

            //switch to main window
            WindowHelper.switchToMainWindow(_driver, main_window);

        }

        [When(@"User Attached .jpg document of less than 4mb")]
        public void WhenUserAttached_JpgDocumentOfLessThanMb()
        {
            //click on attached documents
            _driver.FindElement(VE_LetterTemplates_Page.LDocs_btnAttachDoc).Click();
            _driver.WaitForPageLoad();

            //switch to upload document window window
            WindowHelper.switchToChildWindow(_driver);
            _driver.isDialogPresent();
            _driver.WaitForPageLoad();

            //select the title
            _driver.FindElement(UploadLoanDocument_Page.bc_Title).SendKeys(title + Keys.Enter);
            _driver.isDialogPresent();


            _driver.SwitchTo().Frame(_driver.FindElement(UploadLoanDocument_Page.iframe_file));
            // upload jpg document      
            _driver.FindElement(UploadLoanDocument_Page.fileUpload).UploadDocument(filepath_jpg);
            Thread.Sleep(2000);
            _driver.FindElement(UploadLoanDocument_Page.fileUpload).SendKeys(Keys.Enter);
            //_driver.isDialogPresent();
            _driver.SwitchTo().DefaultContent();
            //_driver.SwitchTo().Alert().Accept();


            //_driver.WaitForPageLoad();

            //Thread.Sleep(10000);
        }

        [Then(@"Pop up Should be displayed as file type .JPG is not allowed")]
        public void ThenPopUpShouldBeDisplayedAsFileType_JPGIsNotAllowed()
        {
            //switch to default frame

            //  _driver.isDialogPresent();
            // _driver.SwitchTo().Alert().Accept();


            //_driver.VerifyAlertText("allowed");
            //_driver.WaitForPageLoad();
            //Thread.Sleep(5000);


            //click on close button
            _driver.FindElement(UploadLoanDocument_Page.Close_button).Click();
            _driver.WaitForPageLoad();

            //switch to main window
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();

        }

        [When(@"Click on show consumer link of the uploaded document  coming in the scanned/uploaded document")]
        public void WhenClickOnLinkOfTheUploadedDocumentComingInTheScannedUploadedDocument()
        {
            //click on show consumer
            Thread.Sleep(2000);
            _driver.FindElement(VE_LetterTemplates_Page.Btn_ShowConsumer).Click();
            _driver.WaitForPageLoad();
        }

        [Then(@"YES should be displayed In the consumer column of the uploaded document present in the Scanned / uploaded Documents section")]
        public void ThenShouldBeDisplayedInTheConsumerColumnOfTheUploadedDocumentPresentInTheScannedUploadedDocumentsSection()
        {
            String consumer_visibility = _driver.FindElement(VE_LetterTemplates_Page.Consumer_visible).GetText();
            Assert.IsTrue(consumer_visibility.StartsWith("YES"));
        }

        [When(@"Copy the generated link")]
        public void WhenCopyTheGeneratedLink()
        {
            _driver.WaitForPageLoad();
            //click on remote doc upload
            _driver.FindElement(VE_LetterTemplates_Page.Button_btnRequestDocUpload).Click();

            //switch to document upload link window
            WindowHelper.switchToChildWindow(_driver);

            //click on generate link
            _driver.FindElement(DocumentUploadLink_Page.Link_lnkGenerateLink).Click();

            //copy generated link
            generatedlink = _driver.FindElement(DocumentUploadLink_Page.Text_link).GetText();
            Console.WriteLine(generatedlink);
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);

        }

        [When(@"Open the generated link")]
        public void WhenOpenTheGeneratedLink()
        {
            //navigate to the generated link
            _driver2 = new InternetExplorerDriver();
            _driver2.Navigate().GoToUrl(generatedlink);
            _driver2.WaitForPageLoad();

            //click on send document link
            _driver2.FindElement(FileShare_Page.SendDocument_lnk).Click();

            //select the value from the dropdown
            _driver2.FindElement(FileShare_Page.DocumentType_ddn).SelectDropDown("doc");
            _driver2.WaitForPageLoad();

        }


        [When(@"Upload the PDF document less than 3.91 mb")]
        public void WhenUploadThePDFDocument()
        {
            
            //upload pdf document

            _driver2.FindElement(FileShare_Page.BrowseFile_btn).UploadDocument(filepath);
            _driver2.WaitForPageLoad();
            Thread.Sleep(2000);

            //click on send document button
            _driver2.FindElement(FileShare_Page.SendDocument_btn).Click();

            //close the window
            _driver2.Close();
            _driver.WaitForPageLoad();

            //refresh the window
            _driver.RefreshPage();
            _driver.WaitForPageLoad();
        }
        [When(@"Upload the PDF document of more than 3.91 mb")]
        public void UploadThePDFDocument()
        {
            //upload pdf document

            _driver2.FindElement(FileShare_Page.BrowseFile_btn).UploadDocument(filepath_5mb);
            _driver2.WaitForPageLoad();
            Thread.Sleep(2000);
        }

        [Then(@"The file you are transferring is too big Max file size is 3.91MB Message should be there")]
        public void UploadStatusDisplay()
        {
           
            _driver2.FindElement(FileShare_Page.UploadStatusDisplay_lbl).AssertTagText(expected_uploadStatusDisplay);
            _driver2.Close();
        }
    }
}
