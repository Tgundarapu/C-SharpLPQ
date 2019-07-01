using OpenQA.Selenium;
using MLAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAutoFramework.Helpers
{
    public class WindowHelper : TestBase
    {
        //This will switch to child window
        public static void switchToChildWindow(IWebDriver driver)
        {
            main_window = driver.CurrentWindowHandle;
            string child_handle = " ";
            var handles = driver.WindowHandles.GetEnumerator();
            while (handles.MoveNext())
            {
                if (handles.Current != main_window)
                {
                    child_handle = handles.Current;
                    driver.SwitchTo().Window(child_handle);
                    break;
                }
            }
        }


        //This will switch back to parent window
        public static void switchToMainWindow(IWebDriver driver, String main_window)
        {
            driver.SwitchTo().Window(main_window);
        }
    }
}