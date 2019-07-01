using OpenQA.Selenium;
using MLAutoFramework.PageObjects;
using MLAutoFramework.Extensions;
using System.Collections.Generic;
using NUnit.Framework;
using System;
using MLAutoFramework.Helpers;

namespace MLAutoFramework.Base
{
    public static class Utility
    {
        //Login LPQ application
        public static void login(this IWebDriver driver, string userName, string password, string answer1, string answer2)
        {
            driver.FindElement(LoginPage.LoginMain_txtLogin).EnterText(userName);
            driver.FindElement(LoginPage.LoginMain_btnLogin).Click();

            IReadOnlyCollection<IWebElement> element = driver.FindElements(LoginPage.MFLQuestions_Answer1);

            if (element.Count > 0)
            {
                Assert.IsTrue(driver.FindElement(LoginPage.MFLQuestions_lblLogin).GetText().Equals(userName, StringComparison.CurrentCultureIgnoreCase));
                driver.FindElement(LoginPage.MFLQuestions_Answer1).EnterText(answer1);
                driver.FindElement(LoginPage.MFLQuestions_Answer2).EnterText(answer2);
                driver.FindElement(LoginPage.MFLQuestions_RegisterComputer_Yes).Click();
                driver.FindElement(LoginPage.MFLQuestions_btnContinue).Click();
            }
            driver.FindElement(LoginPage.MFLPasswordPrompt_Image).AssertElementPresent();
            driver.FindElement(LoginPage.MFLPasswordPrompt_Password).EnterText(password);
            driver.FindElement(LoginPage.MFLPasswordPrompt_btnSignIn).Click();
            driver.FindElement(HomePage.MainContent_lblWelcome).AssertElementPresent();
        }


        //Logout LPQ application
        public static void logout(this IWebDriver driver)
        {
            var elements = driver.FindElements(HomePage.Qs_ibtnLogout);
            if(elements.Count>0)
            {
                IWebElement element = driver.FindElement(HomePage.Qs_ibtnLogout);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                element.Click();
                driver.isDialogPresent();
            }
        }
    }
}
