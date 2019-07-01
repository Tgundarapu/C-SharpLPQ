using OpenQA.Selenium;

namespace MLAutoFramework.PageObjects
{
    class ReportsPage
    {
        //Custom Reports objects
        public static By bc_ddlReportType = By.Id("ctl00_bc_ddlReportType");

        public static By bc_lbtnManageCustomReports = By.Id("ctl00_bc_lbtnManageCustomReports");


        //Manage Custom Reports page objects
        public static By reportsPage = By.Id("ctl00_Pagehistory2_PageHistory_ctl01_PageHistoryStep");

        public static By add_NewCustomReport_Button = By.XPath("//input[@type='button'][@value='Add New Custom Report']");

        public static By table_CustomReports = By.XPath(".//table[@id='ctl00_bc_dg']/tbody/tr");

        //Custome Reports Designer New Window Objects
        public static By textBox_Report_Title = By.Id("TextBoxReportTitle");

        public static By add_NewColumn_Link = By.LinkText("[Click here to add new column]");

        public static By general_Loan_Fields = By.XPath("//a[@id='QueryColumns_entities_t_4']/img");

        public static By approved_Amount = By.XPath("//a[@id='QueryColumns_entities_t_64']/img");

        public static By btnRunReport = By.Id("btnRunReport");

        public static By ButtonSave = By.Id("ButtonSave");

        //Standard Report objects
        public static By approved_Loans = By.Id("ctl00_bc_lstPrebuildReports_ctl01_rdo");

        public static By credit_Score = By.Id("ctl00_bc_lstPrebuildReports_ctl03_rdo");

        public static By show_Report = By.Id("ctl00_bc_btnRunReport");

        public static By loan_Type = By.Id("ctl00_bc_LoanType");

        public static By display_Type = By.Id("ctl00_bc_ExportOption");

        //Standard report new window objects
        public static By nobr_Tags = By.TagName("nobr");

        public static By creditScore = By.XPath(".//span/nobr[text()='MARISOL']/parent::span[1]/following-sibling::span[2]/nobr");

    }
}
