using OpenQA.Selenium;

namespace MLAutoFramework.PageObjects
{
    class LoginPage
    {
        // Login screen objects
        public static By Lender_login_banner = By.XPath(".//*[@src='/images/lender_login_banner.jpg']");

        public static By LoginMain_txtLogin = By.Id("ctl00_bc_LoginMain_txtLogin");

        public static By LoginMain_btnLogin = By.Id("ctl00_bc_LoginMain_btnLogin");

        public static By MFLQuestions_lblLogin = By.Id("ctl00_bc_MFLQuestions_lblLogin");

        public static By MFLQuestions_Answer1 = By.Id("ctl00_bc_MFLQuestions_Answer1");

        public static By MFLQuestions_Answer2 = By.Id("ctl00_bc_MFLQuestions_Answer2");

        public static By MFLQuestions_RegisterComputer_Yes = By.Id("ctl00_bc_MFLQuestions_RegisterComputer_0");

        public static By MFLQuestions_RegisterComputer_No = By.Id("ctl00_bc_MFLQuestions_RegisterComputer_1");

        public static By MFLQuestions_btnContinue = By.Id("ctl00_bc_MFLQuestions_btnContinue");

        public static By MFLQuestions_btnCancel = By.Id("ctl00_bc_MFLQuestions_btnCancel");

        public static By MFLPasswordPrompt_Image = By.Id("ctl00_bc_MFLPasswordPrompt_Image");

        public static By MFLPasswordPrompt_Password = By.Id("ctl00_bc_MFLPasswordPrompt_Password");

        public static By MFLPasswordPrompt_btnSignIn = By.Id("ctl00_bc_MFLPasswordPrompt_btnSignIn");

    }
}
