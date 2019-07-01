using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using MLAutoFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using LocatorType = MLAutoFramework.Extensions.WebDriverExtension.Type;

namespace MLAutoFramework.Extensions
{
    public static class WebElementExtension
    {

        //This will Enter Text in text box
        public static void EnterText(this IWebElement element, string value)
        {
            try
            {
                element.Clear();
                element.SendKeys(value);
                LogHelper.Write("Entered the text in " + element);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //This will click a button, check box or radio button
        public static void Click(this IWebElement element)
        {
            try
            {
                element.Click();
                LogHelper.Write("Clicked the " + element);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //This will select a value from dropdown list using text
        public static void SelectDropDown(this IWebElement element, string value)
        {
            try
            {
                SelectElement ddl = new SelectElement(element);
                ddl.SelectByText(value);
                LogHelper.Write("Selected the dropdown value from " + element);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //This will verify ccs class of element is same as expected
        public static void VerifyCssClass(IWebElement element, string CssClass)
        {
            string className = element.GetAttributeValue("class");
            Assert.AreEqual(CssClass, className);
        }


        //This will hover mouse on element
        public static void Hover(this IWebDriver driver, IWebElement element)
        {
            try
            {
                Actions action = new Actions(driver);
                action.MoveToElement(element).Perform();
                action.MoveToElement(element).ToString();
                LogHelper.Write("Hover over action performed on " + element);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //This will hover mouse and click on element
        public static void HoverAndClick(this IWebDriver driver, IWebElement elementToHover, IWebElement elementToClick)
        {
            try
            {
                Actions action = new Actions(driver);
                action.MoveToElement(elementToHover).Click(elementToClick).Build().Perform();
                LogHelper.Write("Performed hover over on " + elementToHover + " and Click action on " + elementToClick);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Enter tab for any element
        public static void TabControl(this IWebElement element)
        {
            try
            {
                element.SendKeys(Keys.Tab);
                LogHelper.Write(element + " is tabbed");
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Handle date picker
        public static void TabDatePicker(this IWebElement element)
        {
            try
            {
                LogHelper.Write(element + " has default focus on mm");
                element.SendKeys(Keys.Tab);
                LogHelper.Write(element + " tabbed and focus in on dd");
                element.SendKeys(Keys.Tab);
                LogHelper.Write(element + " tabbed and focus in on yyyy");
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Get text from any element
        public static string GetText(this IWebElement element)
        {
            try
            {
                return element.Text;
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }

        }


        //Get Place holder text
        public static string GetPlaceHolderText(this IWebElement element)
        {
            try
            {
                return element.GetAttribute("placeholder");
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Assert Tag text using textcontent attribute
        public static void AssertTagText(this IWebElement element, string expected)
        {
            try
            {
                string actual = element.GetAttribute("textContent");
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Get the hover element text
        public static string GetHoverText(this IWebDriver driver, IWebElement element)
        {
            try
            {
                Actions action = new Actions(driver);
                return action.MoveToElement(element).ToString();
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Get text of first element from drop down
        public static string GetSelectedDropDown(this IWebElement element)
        {
            try
            {
                SelectElement ddl = new SelectElement(element);
                return ddl.AllSelectedOptions.First().ToString();
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Get text of first element or default value from drop down
        public static string GetTextFromDropDown(this IWebElement element)
        {
            try
            {
                return new SelectElement(element).AllSelectedOptions.SingleOrDefault() != null ? new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text : null;

            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Get all selected options from dropdown
        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            try
            {
                SelectElement ddl = new SelectElement(element);
                return ddl.AllSelectedOptions;
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Get all options from dropdown
        public static IList<IWebElement> GetOptions(this IWebElement element)
        {
            try
            {
                SelectElement ddl = new SelectElement(element);
                return ddl.Options;
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Get any attribute value of any element
        public static string GetAttributeValue(this IWebElement element, string attribute)
        {
            try
            {
                return element.GetAttribute(attribute);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        /// <summary>
        /// Check if the element exist
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>


        //Verify element is present
        private static bool IsElementPresent(IWebElement element)
        {
            Thread.Sleep(1000);
            try
            {
                return element.Displayed;
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                return false;
            }
        }


        //Verify element is Enabled, returns true value if it is
        private static bool IsElementEnabled(IWebElement element)
        {
            try
            {
                bool b = element.Enabled;
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                return false;
            }
        }



        /// <summary>
        /// Assert if the Element is present
        /// </summary>
        /// <param name="element"></param>


        //Verify Element is present
        public static void AssertElementPresent(this IWebElement element)
        {
            try
            {
                if (IsElementPresent(element))
                {
                    LogHelper.Write("element exist");
                    Console.WriteLine("element exist");
                }
                else
                {
                    LogHelper.Write("element does not exist");
                    Assert.Fail("AssertElementNotPresent TagName:" + element.TagName);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Verify Element is present with explicit wait
        public static void AssertElementPresent(this IWebDriver driver, IWebElement element, LocatorType PropertyType, string ObjectProperty)
        {
            try
            {
                driver.WaitForObjectAvaialble(PropertyType, ObjectProperty);
                if (IsElementPresent(element))
                {
                    LogHelper.Write("element exist");
                    Console.WriteLine("element exist");
                }
                else
                {
                    LogHelper.Write("element does not exist");
                    Assert.Fail("AssertElementNotPresent TagName:" + element.TagName);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Verify Element is not present
        public static void AssertElementIsNotPresent(this IWebElement element)
        {
            try
            {
                if (IsElementPresent(element))
                {
                    LogHelper.Write("element exist");
                    Assert.Fail("AssertElementPresent");
                }
                else
                {
                    LogHelper.Write("element does not exist");
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Verify Element is hidden
        public static void AssertElementHidden(this IWebElement element)
        {
            try
            {
                if (IsElementPresent(element))
                {
                    LogHelper.Write("element exist");
                    Assert.Fail("AssertElementPresent");
                }
                else
                {
                    LogHelper.Write("element does not exist");
                    Console.WriteLine("element does not exist");
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Verify element is enabled
        public static void AssertElementEnabled(this IWebElement element)
        {
            try
            {
                if (element.Enabled)
                {
                    LogHelper.Write("element enabled");
                    Console.WriteLine("element enabled");
                }
                else
                //throw new AssertionException(String.Format("AssertElementNotPresent exception"));
                {
                    LogHelper.Write("element disabled");
                    Assert.Fail("AssertElementDisabled");
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Verify Element is disabled
        public static void AssertElementDisabled(this IWebElement element)
        {
            try
            {
                Thread.Sleep(1000);
                if (element.Enabled)
                {
                    LogHelper.Write("element enabled");
                    Assert.Fail("AssertElementEnabled");
                }

                else
                {
                    Console.WriteLine("element exist");
                    LogHelper.Write("element disabled");
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Verify Element text to be from given string array
        public static void AssertElementText(this IWebElement element, string[] text)
        {
            try
            {
                var data = element.GetText();
                for (int i = 0; i < text.Length; i++)
                {
                    StringAssert.Contains(text[i], element.GetText());
                }

                //Assert.AreEqual(text, element.GetText());
            }
            catch (AssertionException ex)
            {
                LogHelper.LogException(ex);
                Assert.Fail("AssertElementText Failed");
            }
        }


        //This will return true if element is colored
        private static bool IsHeaderAppearsColored(IWebElement element, string cssClass)
        {
            try
            {
                string actual = element.GetAttribute("class");
                string expected = cssClass;
                Assert.AreEqual(expected, actual);
                return true;
            }
            catch (AssertionException)
            {
                return false;
            }
        }


        //This will verify given attribute value to be same as expected
        public static void AssertAttributeValue(this IWebElement element, string expected, string attribute)
        {
            try
            {
                string actual = element.GetAttribute(attribute);
                Assert.AreEqual(expected, actual);
            }
            catch (AssertionException)
            {
                Assert.Fail("AssertAttribute Failed");
            }
        }


        //This will verify whether Header is colored or not
        public static void AssertHeaderAppearsColored(this IWebElement element, string cssClass)
        {
            try
            {
                if (IsHeaderAppearsColored(element, cssClass))
                {
                    LogHelper.Write("Element Color Verified");
                }
                else
                {
                    LogHelper.Write("Element Color Not Verified");
                    Assert.Fail("AssertElementNotColored");
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //This will return true if element is clickable
        private static bool IsElementClickable(IWebElement element)
        {
            try
            {
                return (element.Displayed && element.Enabled);
            }
            catch (AssertionException)
            {
                return false;
            }
        }


        //This will verify whether element is clickable,and add log in log file
        public static void AssertElementClickable(this IWebElement element)
        {
            if (IsElementClickable(element))
            {
                LogHelper.Write("Element is clickable");
            }
            else
            {
                LogHelper.Write("Element is not clickable");
                Assert.Fail("AssertElementNotClickable");
            }
        }


        //This will verify whether checkbox is checked, and will add log in log file
        public static void AssertCheckBoxChecked(this IWebElement element)
        {
            if (element.Selected)
            {
                LogHelper.Write("Element is Selected");
                Assert.Pass("AssertElementSelected");
            }
            else
            {
                LogHelper.Write("Element is not Selected");
                Assert.Fail("AssertElementNotSelected");
            }
        }


        //This will verify whether checkbox is unchecked, and will add log in log file
        public static void AssertCheckBoxUnChecked(this IWebElement element)
        {
            if (!element.Selected)
            {
                LogHelper.Write("Element is not Selected");
                Assert.Pass("AssertElement not Selected");
            }
            else
            {
                LogHelper.Write("Element is Selected");
                Assert.Fail("AssertElementSelected");
            }
        }


        //This will check and uncheck the checkbox as per given string
        public static void SetCheckBox(this IWebElement element, string value)
        {
            if (value.ToLower().Equals("uncheck") && element.Selected)
            {
                element.Click();
            }
            else if (value.ToLower().Equals("check") && !element.Selected)
            {
                element.Click();
            }
        }


        //This will verify whether Tool Tip Text is same as expected
        public static void AsserttoolTipText(this IWebElement element, string atribute, string ExpectedToolTipText)
        {
            // Get tooltip text
            string ActualToolTipText = element.GetAttribute(atribute);

            // Compare toll tip text
            Assert.AreEqual(ExpectedToolTipText, ActualToolTipText);
        }


        //This will verify element is not clickable and add log into log file
        public static void AssertElementNotClickable(this IWebElement element)
        {
            if (!IsElementClickable(element))
            {
                LogHelper.Write("Element is mot clickable");
            }
            else
            {
                LogHelper.Write("Element is clickable");
                Assert.Fail("AssertElementClickable");
            }
        }

        //Refresh web page
        public static void RefreshPage(this IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }
    }
}

