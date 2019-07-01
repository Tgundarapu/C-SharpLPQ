using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRSAutoFramework.PageObjects
{
    class FileShare_Page
    {
        public static By SendDocument_lnk = By.Id("btnUploadDocumentLink");

        public static By DocumentType_ddn = By.Id("DocumentTypeDropDown");

        public static By BrowseFile_btn = By.Id("fileInput");

        public static By SendDocument_btn = By.Id("btnSend");

        public static By UploadStatusDisplay_lbl = By.XPath(".//span[@class='c-uploaderStatusDisplay-errorLabel']");
    }
}
