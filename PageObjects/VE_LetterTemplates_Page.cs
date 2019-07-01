using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRSAutoFramework.PageObjects
{
    class VE_LetterTemplates_Page
    {
        public static By LDocs_btnAttachDoc = By.Id("LDocs_btnAttachDoc");

        public static By LDocs_lnkDisplay = By.Id("LDocs_dg_ctl02_lnkDisplay");

        public static By LDocs_dg_filename = By.XPath(".//table[@id='LDocs_dg']//tr[2]/td[2]");

        public static By Btn_ShowConsumer = By.Id("LDocs_dg_ctl02_btnShowC");

        public static By Consumer_visible = By.XPath(".//table[@id='LDocs_dg']//tr[2]/td[5]");

        public static By Button_btnRequestDocUpload = By.Id("LDocs_RemoteDocUploadButton_btnRequestDocUpload");

        

    }
}
