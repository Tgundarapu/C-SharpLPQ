using OpenQA.Selenium;

namespace MLAutoFramework.PageObjects
{
    class HomePage
    {
        public static By MainContent_lblWelcome = By.Id("ctl00_MainContent_lblWelcome");

        public static By Qs_txtQuickLoanNumber = By.Id("ctl00_h_ctl00_qs_txtQuickLoanNumber");

        public static By Headerbutton_search = By.XPath(".//img[contains(@src,'/headerbutton_search.gif')]");

        public static By Qs_SearchBy = By.Id("ctl00_h_ctl00_qs_SearchBy");

        public static By Qs_ibtnLogout = By.XPath(".//*[contains(@id,'ibtnLogout')]");

        public static By MainContent_dg = By.XPath(".//table[@id='ctl00_MainContent_dg']//tr");

        public static By FirstRow = By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[1]/td");

        public static By MouseHover_Tools = By.XPath("//*[@class='rollover'][@alt='Tools']");

        public static By MouseHover_Reports = By.XPath(".//a[contains(@href,'ProgramSearch.aspx')]/parent::li/following-sibling::li[1]/img");

        public static By MouseHover_RunSchedule = By.XPath(".//a[@href='/lender/reports/newreports.aspx']");

        public static By ViewAPP = By.XPath(".//img[@title='View App']");

        public static By Roolover_NewAPP = By.XPath(".//img[@class='rollover' and @alt='New App']");

        public static By New_Vehicle = By.XPath(".//img[@class='rollover' and @alt='New App']//following-sibling::ul/li[6]/a");
    }
}
