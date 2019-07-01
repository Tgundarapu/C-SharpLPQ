using BoDi;
using OpenQA.Selenium;
using MLAutoFramework.Helpers;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MLAutoFramework.Config;

namespace MLAutoFramework.Base
{
    [Binding]
    public class Hooks : TestBase
    {
        public static string stepname, scenario;
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        //public static ExtentReportBase objExtentReportBase = new ExtentReportBase();
        public static TestBase objTestBase = new TestBase();


        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }


        //Execute before Suite and create object for extent report and Log File
        [BeforeTestRun]
        public static void InitialSetUp()
        {
            objTestBase.TestSetUp("MLSmoke");
        }


        //Execute before every scenario, open browser and launch url
        [BeforeScenario]
        public void CreateTestSetUp()
        {
            scenario = ScenarioContext.Current.ScenarioInfo.Title;
            _driver = objTestBase.StartTestExecution("IE", scenario);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            objTestBase.NavigateToURL();
            if(Settings.UserName==null)
            {
                ConfigReader.SetFrameworkSettings();
            }
            _driver.login(Settings.UserName, Settings.Password, Settings.Question1, Settings.Question2);
            //ngDriver = new NgWebDriver(_driver);
            //ngDriver.IgnoreSynchronization = true;
        }

        [BeforeStep]
        public void CheckStatus()
        {
           stepname = ScenarioStepContext.Current.StepInfo.Text;            
        }

        //Execute after every scenario, logout application, flush extent report and close browser
        [AfterScenario]
        public void CleanUpTest()
        {
            _driver.logout();
            ExtentReportBase.StopReport(_driver, stepname, scenario);
            if(_driver != null)
            {
                _driver.Close();
            }            
        }


        //Execute after suite
        [AfterTestRun]
        public static void Teardown()
        {

        }

    }
}
