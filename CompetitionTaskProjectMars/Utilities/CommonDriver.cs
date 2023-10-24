

using CompetitionTaskProjectMars.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium.Support.Extensions;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Constraints;

namespace CompetitionTaskProjectMars.Utilities
{
    public class CommonDriver
    {

        public static IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentTest test;


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            extent = new ExtentReports();
     
            string reportPath = @"C:\Srireka-Project Mars\CompetitionTaskProjectMars\CompetitionTaskProjectMars\Extent Reports\";
            var htmlReporter = new ExtentHtmlReporter(reportPath + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("HostName:", "http://localhost:5000/");
            extent.AddSystemInfo("ProjectName:", "Mars/Education");
            extent.AddSystemInfo("Environment:", "QA");
            extent.AddSystemInfo("Username:", "Srireka");
        }

        [TearDown]
        public void AfterTest()
        {
            var stackTrace= TestContext.CurrentContext.Result.StackTrace;

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string screenshotPath = @"C:\Srireka-Project Mars\CompetitionTaskProjectMars\CompetitionTaskProjectMars\ScreenShots\.png";
                string base64Screenshot = driver.TakeScreenshot().AsBase64EncodedString;
                test.Fail(TestContext.CurrentContext.Result.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64Screenshot).Build());
                test.Log(Status.Fail, screenshotPath + stackTrace);
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                string screenshotPath = @"C:\Srireka-Project Mars\CompetitionTaskProjectMars\CompetitionTaskProjectMars\ScreenShots\.png";
                string base64Screenshot = driver.TakeScreenshot().AsBase64EncodedString;
                test.Pass(TestContext.CurrentContext.Result.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64Screenshot).Build());
                test.Log(Status.Pass, screenshotPath + stackTrace);

            }

            if (driver != null)
            {
                
                driver.Quit();
            }
        }

        [OneTimeTearDown]
        public void OneTimeExtentReportTeardown()
        {
            extent.Flush();
        }




    }

}
