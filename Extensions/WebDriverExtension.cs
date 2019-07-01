using OpenQA.Selenium;
using System;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using MLAutoFramework.Helpers;
using MLAutoFramework.Config;

namespace MLAutoFramework.Extensions
{
    public static class WebDriverExtension
    {

        //Wait for page load
        public static void WaitForPageLoad(this IWebDriver driver)
        {
            Thread.Sleep(3000);
            driver.WaitForCondition(dri =>
            {
                string state = dri.ExecuteJS("return document.readyState").ToString();
                return state == "complete";

            }, 30);
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> Condition, int timeOuts)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return Condition(arg);
                    }

                    catch
                    {
                        return false;
                    }

                };

            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOuts)
            {
                if (execute(obj))
                {
                    break;
                }
            }


        }


        //Use this wait statement for all the editboxes & tables
        public static void WaitForObjectAvaialble(this IWebDriver driver, Type PropertyType, string ObjectProperty)
        {
            try
            {
                switch (PropertyType)
                {
                    case Type.Id:
                        IWebElement elementId = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(ObjectProperty)));
                        break;
                    case Type.ClassName:
                        IWebElement elementTitle = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(ObjectProperty)));
                        break;
                    case Type.Name:
                        IWebElement elementName = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name(ObjectProperty)));
                        break;
                    case Type.LinkText:
                        IWebElement elementLinkText = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(ObjectProperty)));
                        break;
                    case Type.XPath:
                        IWebElement elementXPath = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(ObjectProperty)));
                        break;
                    case Type.CssSelector:
                        IWebElement elementCssSelector = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(ObjectProperty)));
                        break;
                    default:
                        IWebElement elementDefault = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(ObjectProperty)));
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Use this wait statement before clicking on any Buttons, links, Dropdowns, Checkboxes, column headers, images, icons 
        //or on any element where you need to perform click operation
        public static void WaitForElementToBeClickable(this IWebDriver driver, Type PropertyType, string ObjectProperty)
        {
            try
            {
                switch (PropertyType)
                {
                    case Type.Id:
                        IWebElement elementId = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(ObjectProperty)));
                        break;
                    case Type.ClassName:
                        IWebElement elementTitle = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName(ObjectProperty)));
                        break;
                    case Type.Name:
                        IWebElement elementName = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name(ObjectProperty)));
                        break;
                    case Type.LinkText:
                        IWebElement elementLinkText = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText(ObjectProperty)));
                        break;
                    case Type.XPath:
                        IWebElement elementXPath = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(ObjectProperty)));
                        break;
                    case Type.CssSelector:
                        IWebElement elementCssSelector = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(ObjectProperty)));
                        break;
                    default:
                        IWebElement elementDefault = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(ObjectProperty)));
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Use this wait statement if the objects are loaded with the iFrame
        public static void WaitForiFrameLoad(this IWebDriver driver)
        {
            IWebElement iFrameHost = new WebDriverWait(driver, TimeSpan.FromSeconds(20))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("iFrameHost")));
            driver.SwitchTo().DefaultContent(); // you are now outside both frames
            driver.SwitchTo().Frame(iFrameHost);
        }


        public static void WaitForiDashLoad(this IWebDriver driver)
        {
            try
            {
                IWebElement iFrameHost = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                                        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Settings.iDashXPath)));
                driver.SwitchTo().DefaultContent(); // you are now outside both frames
                driver.SwitchTo().Frame(iFrameHost);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Use this wait statements if the page has to make ajax calls for certain objects to load.
        public static void WaitForAjaxLoad(this IWebDriver browser, bool pageHasJQuery = true)
        {
            while (true)
            {
                var ajaxIsComplete = false;

                if (pageHasJQuery)
                    ajaxIsComplete = (bool)(browser as IJavaScriptExecutor).ExecuteScript("if (!window.jQuery) { return false; } else { return jQuery.active == 0; }");
                else
                    ajaxIsComplete = (bool)(browser as IJavaScriptExecutor).ExecuteScript("return document.readyState == 'complete'");

                if (ajaxIsComplete)
                    break;

                Thread.Sleep(100);
            }
        }

        //Get current URL
        public static string GetCurrentURL(this IWebDriver driver)
        {
            return driver.Url;
        }


        public enum Type
        {
            Id,
            CssSelector,
            XPath,
            ClassName,
            Name,
            LinkText,
            IWebElement
        }


        //JavaScript Executer
        internal static object ExecuteJS(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }
    }
}
