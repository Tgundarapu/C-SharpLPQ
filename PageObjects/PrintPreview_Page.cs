using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRSAutoFramework.PageObjects
{
    class PrintPreview_Page
    {
        public static By btnPrint = By.Id("btnPrint");

        public static By btnClose = By.Id("btnClose");

        public static String frame = "menu";
    }
}
