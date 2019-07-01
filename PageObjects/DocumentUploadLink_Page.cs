using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRSAutoFramework.PageObjects
{
    class DocumentUploadLink_Page
    {

        public static By Link_lnkGenerateLink = By.Id("lnkGenerateLink");

        public static By Text_link = By.XPath(".//span[@class='link']");
    }
}
