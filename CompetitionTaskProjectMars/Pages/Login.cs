using CompetitionTaskProjectMars.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionTaskProjectMars.Pages
{
    public class Login:CommonDriver
    {
       
        private IWebElement SignInButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        private IWebElement EmailAddressTextbox => driver.FindElement(By.Name("email"));
        private IWebElement PasswordTextbox => driver.FindElement(By.Name("password"));
        private IWebElement RememberMeCheckbox => driver.FindElement(By.Name("rememberDetails"));
        private IWebElement LoginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
        private IWebElement HiSrireka => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/div[1]/div[2]/div[1]/span[1]"));
       
        public void LoginFunction(string email, string password)
        {
            try
            {
                SignInButton.Click();
                EmailAddressTextbox.SendKeys(email);
                PasswordTextbox.SendKeys(password);
                RememberMeCheckbox.Click();
                LoginButton.Click();

            }catch( Exception ex) { throw; }

        }
        public void LoginAssertion()

        {
            Thread.Sleep(4000);
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//body/div[@id='account-profile-section']/div[1]/div[1]/div[2]/div[1]/span[1]", 50);
            string actualUserName = HiSrireka.Text;
            Assert.That(actualUserName == "Hi Srireka", "Login Unsuccessful");
            Console.Out.WriteLine(actualUserName);
        }

    }
}

