using CompetitionTaskProjectMars.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionTaskProjectMars.Pages
{
    public  class ProfileHomePage:CommonDriver
    {

        private IWebElement ProfileTab => driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[1]/div[1]/a[2]"));
        private IWebElement EducationTab => driver.FindElement(By.XPath("//a[contains(text(),'Education')]"));
        private IWebElement CertificationsTab => driver.FindElement(By.XPath("//a[contains(text(),'Certifications')]"));

        public void GoToProfileEducation()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", "/html[1]/body[1]/div[1]/div[1]/section[1]/div[1]/a[2]", 3);
            ProfileTab.Click();
            EducationTab.Click();
        }
        public void GoToProfileCertifications()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", "/html[1]/body[1]/div[1]/div[1]/section[1]/div[1]/a[2]", 3);
            ProfileTab.Click();
            CertificationsTab.Click();
        }


    }
}

