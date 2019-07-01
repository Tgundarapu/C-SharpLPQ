using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MLAutoFramework.Helpers
{

    public static class PopUpHelper
    {

        //This will reject an alert
        public static void DismissAlert(this IWebDriver driver, IWebElement element)
        {
            element.Click();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            if (alert != null)
            {
                driver.SwitchTo().Alert();
                Console.WriteLine(alert.Text);
                Thread.Sleep(3000);
                alert.Dismiss();
            }
        }


        //This will accept an alert
        public static void AcceptAlert(this IWebDriver driver, IWebElement element)
        {
            element.Click();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            if (alert != null)
            {
                driver.SwitchTo().Alert();
                Console.WriteLine(alert.Text);
                Thread.Sleep(3000);
                alert.Accept();
            }

        }


        //This will switch and close new  pop up window
        public static void ClosePopUpWindow(this IWebDriver driver, IWebElement element)
        {
            // Get the current window handle so you can switch back later.
            string currentHandle = driver.CurrentWindowHandle;

            // Find the element that triggers the popup when clicked on.
            element = driver.FindElement(By.XPath("//*[@id='webtraffic_popup_start_button']"));

            // The Click method of the PopupWindowFinder class will click
            // the desired element, wait for the popup to appear, and return
            // the window handle to the popped-up browser window. Note that
            // you still need to switch to the window to manipulate the page
            // displayed by the popup window.
            PopupWindowFinder finder = new PopupWindowFinder(driver);
            string popupWindowHandle = finder.Click(element);

            driver.SwitchTo().Window(popupWindowHandle);

            // Do whatever you need to on the popup browser, then...
            driver.Close();
            driver.SwitchTo().Window(currentHandle);

        }


        //This will verify whether alert text is same as expected
        public static void AlertTextVerify(this IWebDriver driver, IWebElement element, string text)
        {
            element.Click();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 50));
            IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            if (alert != null)
            {
                driver.SwitchTo().Alert();
                Thread.Sleep(2000);
                Console.WriteLine("Text: " + alert.Text);
                Assert.IsTrue(alert.Text.Contains(text));
                alert.Accept();
            }

        }


        //This will accept alert if alert is present
        public static void isDialogPresent(this IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            if (alert != null)
            {
                driver.SwitchTo().Alert();
                alert.Accept();
            }
        }

        public static void VerifyAlertText(this IWebDriver driver, string text)
        {

            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 50));
            IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            if (alert != null)
            {
                driver.SwitchTo().Alert();
                Thread.Sleep(2000);
                Console.WriteLine("Text: " + alert.Text);
                Assert.IsTrue(alert.Text.Contains(text));
                alert.Accept();
            }

        }
    }
}
