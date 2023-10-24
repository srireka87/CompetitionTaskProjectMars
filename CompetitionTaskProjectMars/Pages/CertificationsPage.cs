using CompetitionTaskProjectMars.TestMap;
using CompetitionTaskProjectMars.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionTaskProjectMars.Pages
{
    public class CertificationsPage : CommonDriver
    {

        Login loginPageObj;
        ProfileHomePage profileHomePageObj;
        
        public CertificationsPage()
        {
            loginPageObj = new Login();
            profileHomePageObj = new ProfileHomePage();
        }

        //div[@class='ui teal button']
        private IWebElement AddNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        private IWebElement AddCertificateAwardTextBox => driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']"));
        private IWebElement AddCertifiedFromTextBox => driver.FindElement(By.XPath("//input[@name='certificationFrom']"));
        private IWebElement SelectYearDropDown => driver.FindElement(By.XPath("//select[@name='certificationYear']"));
        private IWebElement AddButton => driver.FindElement(By.XPath("//input[@value='Add']"));

        private IWebElement CertificationsTable => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table"));
        private IList<IWebElement> CertificationsTableRows => CertificationsTable.FindElements(By.TagName("tr"));
        private IWebElement ActualCertificateAwardName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement ActualCertifiedFrom => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]"));

        //Update Certifications
        private IWebElement UpdateIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i"));
        private IWebElement UpdateCertificateAwardTextBox => driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']"));
        private IWebElement UpdateCertifiedFromTextBox => driver.FindElement(By.XPath("//input[@name='certificationFrom']"));
        private IWebElement UpdateSelectYearDropDown => driver.FindElement(By.XPath("//select[@name='certificationYear']"));
        private IWebElement UpdateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement ActualUpdatedCertificateAwardName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement ActualUpdatedCertifiedFrom => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]"));

        //Delete 
        private IWebElement DeleteIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]/i"));
        private IWebElement ActualPopUpDeleteMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //Cancel
        private IWebElement CancelButton => driver.FindElement(By.XPath("//input[@value='Cancel']"));

        //AlreadyExisting
        private IWebElement AlreadyExistingPopUpMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //EnterAllFields
        private IWebElement EnterAllFieldsPopUpMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        //Duplicate Data
        private IWebElement DuplicateCertificationsDataPopUpMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));




        public void AddCertifications(AddCertificationsTestMap inputJsonData)
        {
            if (CertificationsTableRows.Count > 0)
            {
                Thread.Sleep(1000);
                try
                {
                    for (int i = 1; i < CertificationsTableRows.Count; i++)
                    {
                        IWebElement row = CertificationsTableRows[i];
                        IWebElement DeleteButton = row.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[2]/i"));
                        DeleteButton.Click();
                    }
                }
                catch (StaleElementReferenceException) { }
            }

            Thread.Sleep(3000);
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div", 50);
            AddNewButton.Click();
            AddCertificateAwardTextBox.SendKeys(inputJsonData.CertificateAwardName);
            AddCertifiedFromTextBox.SendKeys(inputJsonData.CertifiedFrom);
            SelectYearDropDown.SendKeys(inputJsonData.Year);
            AddButton.Click();

        }

        public string GetActualCertificateAwardNameAssertion()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]", 20);
            string actualCertificateAwardName1 = ActualCertificateAwardName.Text;
            return actualCertificateAwardName1;
        }
        public string GetActualCertifiedFromAssertion()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]", 20);
            string actualCertifiedFrom1 = ActualCertifiedFrom.Text;
            return actualCertifiedFrom1;
        }

        public void AddCertifications(UpdateCertificationsTestMap updateCertificationsInputJsonData)
        {
            if (CertificationsTableRows.Count > 0)
            {
                Thread.Sleep(1000);
                try
                {
                    for (int i = 1; i < CertificationsTableRows.Count; i++)
                    {
                        IWebElement row = CertificationsTableRows[i];
                        IWebElement DeleteButton = row.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[2]/i"));
                        DeleteButton.Click();
                    }
                }
                catch (StaleElementReferenceException) { }
            }

            Thread.Sleep(3000);
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div", 50);
            AddNewButton.Click();
            AddCertificateAwardTextBox.SendKeys(updateCertificationsInputJsonData.CertificateAwardName);
            AddCertifiedFromTextBox.SendKeys(updateCertificationsInputJsonData.CertifiedFrom);
            SelectYearDropDown.SendKeys(updateCertificationsInputJsonData.Year);
            AddButton.Click();

        }

        public void UpdateCertifications(UpdateCertificationsTestMap updateCertificationsInputJsonData)
        {
            Thread.Sleep(3000);
            UpdateIcon.Click();
            UpdateCertificateAwardTextBox.Clear();
            UpdateCertificateAwardTextBox.SendKeys(updateCertificationsInputJsonData.NewCertificateAwardName);
            UpdateCertifiedFromTextBox.Clear();
            UpdateCertifiedFromTextBox.SendKeys(updateCertificationsInputJsonData.NewCertifiedFrom); 
            UpdateSelectYearDropDown.Click();
            UpdateSelectYearDropDown.SendKeys(updateCertificationsInputJsonData.NewYear);
            UpdateButton.Click();

        }

        public string ActualUpdatedCertificateAwardNameAssertion()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]", 70);
            string actualUpdatedCertificateAwardName1 = ActualUpdatedCertificateAwardName.Text;
            return actualUpdatedCertificateAwardName1;
        }
        public string ActualUpdatedCertifiedFromAssertion()
        {
            Thread.Sleep(1000);
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]", 70);
            string actualUpdatedCertifiedFrom1 = ActualUpdatedCertifiedFrom.Text;
            return actualUpdatedCertifiedFrom1;
        }

        public void DeleteCertifications()
        {
            Thread.Sleep(3000);
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]/i ", 50);
            DeleteIcon.Click();
        }
        public string DeleteAssertion()
        {

            Thread.Sleep(5000);
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 90);
            string actualPopUpDeleteMsg1 = ActualPopUpDeleteMsg.Text;
            return actualPopUpDeleteMsg1;
        }

        public void CancelCertifications(CancelCertificationsTestMap inputJsonData)
        {
            if (CertificationsTableRows.Count > 0)
            {
                Thread.Sleep(1000);
                try
                {
                    for (int i = 1; i < CertificationsTableRows.Count; i++)
                    {
                        IWebElement row = CertificationsTableRows[i];
                        IWebElement DeleteButton = row.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[2]/i"));
                        DeleteButton.Click();
                    }
                }
                catch (StaleElementReferenceException) { }
            }

            Thread.Sleep(3000);
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div", 50);
            AddNewButton.Click();
            AddCertificateAwardTextBox.SendKeys(inputJsonData.CertificateAwardName);
            AddCertifiedFromTextBox.SendKeys(inputJsonData.CertifiedFrom);
            SelectYearDropDown.SendKeys(inputJsonData.Year);
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//input[@value='Cancel']", 20);
            CancelButton.Click();
        }

        public void AlreadyExistingCertifications(AlreadyExistingCertificationsTestMap inputJsonData)
        {
            if (CertificationsTableRows.Count > 1)
            {
                Thread.Sleep(1000);
                try
                {
                    for (int i = 0; i < CertificationsTableRows.Count; i++)
                    {
                        IWebElement row = CertificationsTableRows[i];
                        IWebElement DeleteButton = row.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[2]/i"));
                        DeleteButton.Click();
                    }
                }
                catch (StaleElementReferenceException) { }
            }

            Thread.Sleep(3000);
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div", 50);
            AddNewButton.Click();
            AddCertificateAwardTextBox.SendKeys(inputJsonData.CertificateAwardName);
            AddCertifiedFromTextBox.SendKeys(inputJsonData.CertifiedFrom);
            SelectYearDropDown.SendKeys(inputJsonData.Year);
            AddButton.Click();

        }

        public string AlreadyExistingAssertion()
        {

            Thread.Sleep(2000);
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 40);
            string existingPopUpMsg = AlreadyExistingPopUpMsg.Text;
            return existingPopUpMsg;
        }
        public void EnterAllFieldsCertifications(EnterAllFieldsCertificationsTestMap inputJsonData)
        {
            if (CertificationsTableRows.Count > 0)
            {
                Thread.Sleep(1000);
                try
                {
                    for (int i = 1; i < CertificationsTableRows.Count; i++)
                    {
                        IWebElement row = CertificationsTableRows[i];
                        IWebElement DeleteButton = row.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[2]/i"));
                        DeleteButton.Click();
                    }
                }
                catch (StaleElementReferenceException) { }
            }

            Thread.Sleep(3000);
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div", 50);
            AddNewButton.Click();
            AddCertificateAwardTextBox.SendKeys(inputJsonData.CertificateAwardName);
            AddCertifiedFromTextBox.SendKeys(inputJsonData.CertifiedFrom);
            SelectYearDropDown.SendKeys(inputJsonData.Year);
            AddButton.Click();
            CancelButton.Click();

        }
        public string EnterAllFieldsAssertion()
        {
            Thread.Sleep(3000);
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 50);
            string existingPopUpMsg = EnterAllFieldsPopUpMsg.Text;
            return existingPopUpMsg;
        }
        public void DuplicateCertificationsData(DuplicateCertificationsTestMap inputJsonData)
        {
            if (CertificationsTableRows.Count > 1)
            {
                Thread.Sleep(1000);
                try
                {
                    for (int i = 1; i < CertificationsTableRows.Count; i++)
                    {
                        IWebElement row = CertificationsTableRows[i];
                        IWebElement DeleteButton = row.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[2]/i"));
                        DeleteButton.Click();
                    }
                }
                catch (StaleElementReferenceException) { }
            }

            Thread.Sleep(2000);
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div", 50);
            AddNewButton.Click();
            AddCertificateAwardTextBox.SendKeys(inputJsonData.CertificateAwardName);
            AddCertifiedFromTextBox.SendKeys(inputJsonData.CertifiedFrom);
            SelectYearDropDown.SendKeys(inputJsonData.Year);
            AddButton.Click();
         
        }
        public string DuplicateCertificationsDataAssertion()
        {
            Thread.Sleep(4000);
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 90);
            string existingDuplicatePopUpMsg = DuplicateCertificationsDataPopUpMsg.Text;
            return existingDuplicatePopUpMsg;
        }


    }
}
