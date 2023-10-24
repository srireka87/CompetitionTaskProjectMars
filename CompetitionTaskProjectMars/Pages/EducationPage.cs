
using CompetitionTaskProjectMars.TestMap;
using CompetitionTaskProjectMars.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionTaskProjectMars.Pages
{
    public class EducationPage : CommonDriver
    {
        Login loginPageObj;
        ProfileHomePage profileHomePageObj;
       

        public EducationPage()
        {
            loginPageObj = new Login();
            profileHomePageObj = new ProfileHomePage();
        }

        private IWebElement AddNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
        private IWebElement AddCollegeUniversityTextBox => driver.FindElement(By.XPath(" //input[@placeholder='College/University Name']"));
        private IWebElement SelectCountryOfCollegeDropdown => driver.FindElement(By.XPath("//select[@name='country']"));
        private IWebElement SelectTitleDropdown => driver.FindElement(By.XPath("//select[@name='title']"));
        private IWebElement AddDegreeTextBox => driver.FindElement(By.XPath("//input[@name='degree']"));
        private IWebElement SelectYearOfFraduationDropDown => driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));
        private IWebElement AddButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement EducationTable => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table"));
        private IList<IWebElement> EducationTableRows => EducationTable.FindElements(By.TagName("tr"));
        private IWebElement ActualCountryName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement ActualUniversityName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

        //Updating Education
        private IWebElement UpdateIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i"));
        private IWebElement UpdateCollegeUniversityTextBox => driver.FindElement(By.XPath("//input[@name='instituteName']"));
        private IWebElement UpdateSelectCountryOfCollegeDropdown => driver.FindElement(By.XPath("//select[@name='country']"));
        private IWebElement UpdateSelectTitleDropdown => driver.FindElement(By.XPath("//select[@name='title']"));
        private IWebElement UpdateDegreeTextBox => driver.FindElement(By.XPath("//input[@name='degree']"));
        private IWebElement UpdateSelectYearOfFraduationDropDown => driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));
        private IWebElement UpdateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement ActualUpdatedUniversityName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]"));
        private IWebElement ActualUpdatedCountryName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]"));

        //Delete 
        private IWebElement DeleteIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i"));
        private IWebElement ActualPopUpDeleteMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        
        //Cancel
        private IWebElement CancelButton => driver.FindElement(By.XPath("//input[@value='Cancel']"));
        private IWebElement EducationTab => driver.FindElement(By.XPath("//a[contains(text(),'Education')]"));

        //AlreadyExisting
        private IWebElement AlreadyExistingPopUpMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //EnterAllFields
       private IWebElement EnterAllFieldsPopUpMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //Duplicate Data
        private IWebElement DuplicateEducationPopUpMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));



        public void AddEducation(AddEducationTestMap inputJsonData)
        {
            if (EducationTableRows.Count > 0)
            {
                Thread.Sleep(1000);
                try
                {
                    for (int i = 1; i < EducationTableRows.Count; i++)
                    {
                        IWebElement row = EducationTableRows[i];
                        IWebElement DeleteButton = row.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]/i"));
                        DeleteButton.Click();
                    }
                }
                catch (StaleElementReferenceException) { }
            }

            Thread.Sleep(2000);
            AddNewButton.Click();
            AddCollegeUniversityTextBox.SendKeys(inputJsonData.CollegeUniversityName);
            SelectCountryOfCollegeDropdown.SendKeys(inputJsonData.CountryOfCollege);
            SelectTitleDropdown.SendKeys(inputJsonData.Title);
            AddDegreeTextBox.SendKeys(inputJsonData.Degree);
            SelectYearOfFraduationDropDown.SendKeys(inputJsonData.YearOfGraduation);
            AddButton.Click();

        }

       

        public string GetActualCountryNameAssertion()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 20);
            string actualCountryName1 = ActualCountryName.Text;
            return actualCountryName1;
        }
        public string GetActualUniversityNameAssertion()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]", 20);
            string actualUniversityName1 = ActualUniversityName.Text;
            return actualUniversityName1;
        }

        public void AddEducation(UpdateEducationTestMap updateEducationInputJsonData)
        {
            if (EducationTableRows.Count > 0)
            {
                Thread.Sleep(1000);
                try
                {
                    for (int i = 1; i < EducationTableRows.Count; i++)
                    {
                        IWebElement row = EducationTableRows[i];
                        IWebElement DeleteButton = row.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]/i"));
                        DeleteButton.Click();
                    }
                }
                catch (StaleElementReferenceException) { }
            }

            Thread.Sleep(2000);
            AddNewButton.Click();
            AddCollegeUniversityTextBox.SendKeys(updateEducationInputJsonData.CollegeUniversityName);
            SelectCountryOfCollegeDropdown.SendKeys(updateEducationInputJsonData.CountryOfCollege);
            SelectTitleDropdown.SendKeys(updateEducationInputJsonData.Title);
            AddDegreeTextBox.SendKeys(updateEducationInputJsonData.Degree);
            SelectYearOfFraduationDropDown.SendKeys(updateEducationInputJsonData.YearOfGraduation);
            AddButton.Click();

        }
        public void UpdateEducation(UpdateEducationTestMap updateEducationInputJsonData)
        {
            Thread.Sleep(3000);
            UpdateIcon.Click();
            UpdateCollegeUniversityTextBox.Clear();
            UpdateCollegeUniversityTextBox.SendKeys(updateEducationInputJsonData.NewCollegeUniversityName);
            UpdateSelectCountryOfCollegeDropdown.Click();
            UpdateSelectCountryOfCollegeDropdown.SendKeys(updateEducationInputJsonData.NewCountryOfCollege);
            UpdateSelectTitleDropdown.Click();
            UpdateSelectTitleDropdown.SendKeys(updateEducationInputJsonData.NewTitle);
            UpdateDegreeTextBox.Clear();
            UpdateDegreeTextBox.SendKeys(updateEducationInputJsonData.NewDegree);
            UpdateSelectYearOfFraduationDropDown.Click();
            SelectYearOfFraduationDropDown.SendKeys(updateEducationInputJsonData.NewYearOfGraduation);
            UpdateButton.Click();
            
        }

        public string ActualUpdatedCountryNameAssertion()
        {
          
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]", 90);
            string actualUpdatedCountryName1 = ActualUpdatedCountryName.Text;
            return actualUpdatedCountryName1;
        }
        public string ActualUpdatedUniversityNameAssertion()
        {
            
            WaitHelpers.WaitToBeVisible(driver, "XPath","//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]", 90);
            string actualUpdatedUniversityName1 = ActualUpdatedUniversityName.Text;
            return actualUpdatedUniversityName1;
        }


        public void DeleteEduation()
        {
            Thread.Sleep(3000);
            WaitHelpers.WaitToBeClickable(driver, "XPath", " //*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i", 50);
            DeleteIcon.Click();
        }
        public string DeleteAssertion()
        {

            Thread.Sleep(3000);
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 50);
            string actualPopUpDeleteMsg1 = ActualPopUpDeleteMsg.Text;
            return actualPopUpDeleteMsg1;
        }

               
        public void CancelEducation(CancelEducationTestMap inputJsonData)
        {
            if (EducationTableRows.Count > 0)
            {
                Thread.Sleep(1000);
                try
                {
                    for (int i = 1; i < EducationTableRows.Count; i++)
                    {
                        IWebElement row = EducationTableRows[i];
                        IWebElement DeleteButton = row.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]/i"));
                        DeleteButton.Click();
                    }
                }
                catch (StaleElementReferenceException) { }
            }

            Thread.Sleep(2000);
            AddNewButton.Click();
            AddCollegeUniversityTextBox.SendKeys(inputJsonData.CollegeUniversityName);
            SelectCountryOfCollegeDropdown.SendKeys(inputJsonData.CountryOfCollege);
            SelectTitleDropdown.SendKeys(inputJsonData.Title);
            AddDegreeTextBox.SendKeys(inputJsonData.Degree);
            SelectYearOfFraduationDropDown.SendKeys(inputJsonData.YearOfGraduation);
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//input[@value='Cancel']", 20);
            CancelButton.Click();

        }

        public void AlreadyExistEduationDetails(AlreadyExistingEducationTestMap inputJsonData)
        {
            if (EducationTableRows.Count > 1)
            {
                Thread.Sleep(1000);
                try
                {
                    for (int i = 0; i < EducationTableRows.Count; i++)
                    {
                        IWebElement row = EducationTableRows[i];
                        IWebElement DeleteButton = row.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]/i"));
                        DeleteButton.Click();
                    }
                }
                catch (StaleElementReferenceException) { }
            }
            Thread.Sleep(2000);
            AddNewButton.Click();
            AddCollegeUniversityTextBox.SendKeys(inputJsonData.CollegeUniversityName);
            SelectCountryOfCollegeDropdown.SendKeys(inputJsonData.CountryOfCollege);
            SelectTitleDropdown.SendKeys(inputJsonData.Title);
            AddDegreeTextBox.SendKeys(inputJsonData.Degree);
            SelectYearOfFraduationDropDown.SendKeys(inputJsonData.YearOfGraduation);
            AddButton.Click();       

        }
        public string AlreadyExistingAssertion()
        {

            Thread.Sleep(4000);
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 90);
            string existingPopUpMsg = AlreadyExistingPopUpMsg.Text;
            return existingPopUpMsg;
        }

        public void EnterAllFieldsEducation(EnterAllFieldsEducationTestMap inputJsonData)
        {
            if (EducationTableRows.Count > 0)
            {
                Thread.Sleep(1000);
                try
                {
                    for (int i = 1; i < EducationTableRows.Count; i++)
                    {
                        IWebElement row = EducationTableRows[i];
                        IWebElement DeleteButton = row.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]/i"));
                        DeleteButton.Click();
                    }
                }
                catch (StaleElementReferenceException) { }
            }

            Thread.Sleep(3000);
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div", 40);
            AddNewButton.Click();
            AddCollegeUniversityTextBox.SendKeys(inputJsonData.CollegeUniversityName);
            SelectCountryOfCollegeDropdown.SendKeys(inputJsonData.CountryOfCollege);
            SelectTitleDropdown.SendKeys(inputJsonData.Title);
            AddDegreeTextBox.SendKeys(inputJsonData.Degree);
            SelectYearOfFraduationDropDown.SendKeys(inputJsonData.YearOfGraduation);
            AddButton.Click();
            CancelButton.Click();
        }
        public string EnterAllFieldsAssertion()
        {
            Thread.Sleep(4000);
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 90);
            string existingPopUpMsg = EnterAllFieldsPopUpMsg.Text;
            return existingPopUpMsg;
        }

        public void DuplicateEduationData(DuplicateEducationTestMap inputJsonData)
        {
            if (EducationTableRows.Count > 1)
            {
                Thread.Sleep(1000);
                try
                {
                    for (int i = 0; i < EducationTableRows.Count; i++)
                    {
                        IWebElement row = EducationTableRows[i];
                        IWebElement DeleteButton = row.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]/i"));
                        DeleteButton.Click();
                    }
                }
                catch (StaleElementReferenceException) { }
            }
            Thread.Sleep(2000);
            AddNewButton.Click();
            AddCollegeUniversityTextBox.SendKeys(inputJsonData.CollegeUniversityName);
            SelectCountryOfCollegeDropdown.SendKeys(inputJsonData.CountryOfCollege);
            SelectTitleDropdown.SendKeys(inputJsonData.Title);
            AddDegreeTextBox.SendKeys(inputJsonData.Degree);
            SelectYearOfFraduationDropDown.SendKeys(inputJsonData.YearOfGraduation);
            AddButton.Click();

        }
        public string DuplicateEducationsDataAssertion()
        {

            Thread.Sleep(4000);
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 90);
            string existingDuplicatePopUpMsg = DuplicateEducationPopUpMsg.Text;
            return existingDuplicatePopUpMsg;
        }

    }

}

