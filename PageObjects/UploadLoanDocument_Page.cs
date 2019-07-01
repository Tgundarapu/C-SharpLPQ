using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRSAutoFramework.PageObjects
{
    class UploadLoanDocument_Page
    {
        public static By bc_Title = By.XPath(".//select[@id='ctl00_bc_Title']/following-sibling::input");

        public static By fileUpload = By.XPath(".//input[@type='file']");

        public static By bc_Comments = By.Id("ctl00_bc_Comments");

        public static By Buttons_btnSave = By.Id("ctl00_Buttons_btnSave");

        public static By iframe_file = By.Id("ctl00_bc_FileAttached_ctl01");

        public static By Close_button = By.XPath(".//input[@value='Close']");
    }
}
