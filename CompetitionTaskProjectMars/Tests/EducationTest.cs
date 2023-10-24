
using AventStack.ExtentReports;
using CompetitionTaskProjectMars.Pages;
using CompetitionTaskProjectMars.TestMap;
using CompetitionTaskProjectMars.Utilities;
using NuGet.Frameworks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CompetitionTaskProjectMars.Tests
{
    [TestFixture]
    public class EducationTest : CommonDriver
    {

        Login loginPageObj;
        ProfileHomePage profileHomePageObj;
        EducationPage educationPageObj;
        JsonReader reader;

        public EducationTest()
        {
            loginPageObj = new Login();
            profileHomePageObj = new ProfileHomePage();
            educationPageObj = new EducationPage();
             reader = new JsonReader();
        }

        [SetUp]
        public void SetUp()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            loginPageObj.LoginFunction("srireka87@gmail.com", "Rosesri@23");
            loginPageObj.LoginAssertion();
            profileHomePageObj.GoToProfileEducation();
        }

        [Test, Description("Adding Education")]
        public void AddEducation_Test()
        {
            List<AddEducationTestMap> addEducationTestData = reader.ReadAddEducationJsonDataFile();

            foreach (var inputJsonData in addEducationTestData)
            {
                string collegeName = inputJsonData.CollegeUniversityName;
                string country = inputJsonData.CountryOfCollege;
                string title = inputJsonData.Title;
                string degree = inputJsonData.Degree;
                string year = inputJsonData.YearOfGraduation;
                educationPageObj.AddEducation(inputJsonData);
                Thread.Sleep(4000);

                string actualCountryName = educationPageObj.GetActualCountryNameAssertion();
                Assert.That(inputJsonData.CountryOfCollege == actualCountryName, "Country Name is not matching");

                string actualUniversityName = educationPageObj.GetActualUniversityNameAssertion();
                Assert.That(inputJsonData.CollegeUniversityName == actualUniversityName, "CollegeName is not matching");
            }

        }

        [Test, Description("Update Education")]
        public void UpdateEducation_Test()
        {
            List<UpdateEducationTestMap> updateEducationTestData = reader.ReadUpdateEducationJsonDataFile();

            foreach (var updateEducationInputJsonData in updateEducationTestData)
            {
                string collegeName = updateEducationInputJsonData.CollegeUniversityName;
                string country = updateEducationInputJsonData.CountryOfCollege;
                string title = updateEducationInputJsonData.Title;
                string degree = updateEducationInputJsonData.Degree;
                string year = updateEducationInputJsonData.YearOfGraduation;
                educationPageObj.AddEducation(updateEducationInputJsonData);
            }
            foreach (var updateEducationInputJsonData in updateEducationTestData)
            {
                string NewcollegeName = updateEducationInputJsonData.NewCollegeUniversityName;
                string Newcountry = updateEducationInputJsonData.NewCountryOfCollege;
                string Newtitle = updateEducationInputJsonData.NewTitle;
                string Newdegree = updateEducationInputJsonData.NewDegree;
                string Newyear = updateEducationInputJsonData.NewYearOfGraduation;
                educationPageObj.UpdateEducation(updateEducationInputJsonData);
                Thread.Sleep(4000);
                string actualUpdatedCountryName = educationPageObj.ActualUpdatedCountryNameAssertion();
                Assert.That(updateEducationInputJsonData.NewCountryOfCollege == actualUpdatedCountryName, "Updated Country Name is not matching");
                string actualUpdatedUniversityName = educationPageObj.ActualUpdatedUniversityNameAssertion();
                Assert.That(updateEducationInputJsonData.NewCollegeUniversityName == actualUpdatedUniversityName, "CollegeName is not matching");
           }
        }


        [Test, Description("Delete Education")]
        public void DeleteEducation_Test()
        {
            List<AddEducationTestMap> addEducationTestData = reader.ReadDeleteEducationJsonDataFile();

            foreach (var inputJsonData in addEducationTestData)
            {
                string collegeName = inputJsonData.CollegeUniversityName;
                string country = inputJsonData.CountryOfCollege;
                string title = inputJsonData.Title;
                string degree = inputJsonData.Degree;
                string year = inputJsonData.YearOfGraduation;
                educationPageObj.AddEducation(inputJsonData);
            }
            educationPageObj.DeleteEduation();
            string actualDeletePopUpMsg = educationPageObj.DeleteAssertion();
            string expectedDeletePopUpMsg = "Education entry successfully removed";
            Assert.That(expectedDeletePopUpMsg == actualDeletePopUpMsg, "DeleteEducationTest is Unsuccessful");
        }


        [Test, Description("Cancel Education")]
        public void CancelEducation_Test()
        {
            List<CancelEducationTestMap> cancelEducationTestData = reader.ReadCancelEducationJsonDataFile();

            foreach (var inputJsonData in cancelEducationTestData)
            {
                string collegeName = inputJsonData.CollegeUniversityName;
                string country = inputJsonData.CountryOfCollege;
                string title = inputJsonData.Title;
                string degree = inputJsonData.Degree;
                string year = inputJsonData.YearOfGraduation;
                educationPageObj.CancelEducation(inputJsonData);
            }
        }


        [Test, Description("AlreadyExist Education Details")]
        public void AlreadyExistEducation_Test()
        {
            List<AlreadyExistingEducationTestMap> alreadyExistingEducationTestData =reader.ReadExistingEducationJsonDataFile();

            foreach (var inputJsonData in alreadyExistingEducationTestData)
            {
                string collegeName = inputJsonData.CollegeUniversityName;
                string country = inputJsonData.CountryOfCollege;
                string title = inputJsonData.Title;
                string degree = inputJsonData.Degree;
                string year = inputJsonData.YearOfGraduation;
                educationPageObj.AlreadyExistEduationDetails(inputJsonData);
            }
            string actualPopUpMsg = educationPageObj.AlreadyExistingAssertion();
            string expectedPopUpMsg = "This information is already exist.";
            Assert.That(actualPopUpMsg == expectedPopUpMsg, "AlreadyExisting Education Test is unsuccessful");
        }


        [Test, Description("InvalidInput Education")]
        public void EnterAllFieldsEducation_Test()
        {  
            List<EnterAllFieldsEducationTestMap> allFieldsEducationTestData = reader.ReadEnterAllFieldsEducationJsonDataFile();

            foreach (var inputJsonData in allFieldsEducationTestData)
            {
                string collegeName = inputJsonData.CollegeUniversityName;
                string country = inputJsonData.CountryOfCollege;
                string title = inputJsonData.Title;
                string degree = inputJsonData.Degree;
                string year = inputJsonData.YearOfGraduation;
                educationPageObj.EnterAllFieldsEducation(inputJsonData);
            }
                string actualPopUpMsg = educationPageObj.EnterAllFieldsAssertion();
                string expectedPopUpMsg = "Please enter all the fields";
                Assert.That(expectedPopUpMsg == actualPopUpMsg, "EnterAllFieldsEducationTest is Unsuccessful");      
        }


        [Test, Description("DuplicateData Educations")]
        public void DuplicateEducationData_Test()
        {
            List<DuplicateEducationTestMap> duplicateEducationTestData = reader.ReadDuplicateEducationJsonDataFile();

            foreach (var inputJsonData in duplicateEducationTestData)
            {
                string collegeName = inputJsonData.CollegeUniversityName;
                string country = inputJsonData.CountryOfCollege;
                string title = inputJsonData.Title;
                string degree = inputJsonData.Degree;
                string year = inputJsonData.YearOfGraduation;    
                educationPageObj.DuplicateEduationData(inputJsonData);
            }
            string actualDuplicatePopUpMsg = educationPageObj.DuplicateEducationsDataAssertion();
            string expectedDuplicatePopUpMsg = "Duplicated data";
            Assert.That(actualDuplicatePopUpMsg == expectedDuplicatePopUpMsg, "DuplicateEducationData Test is unsuccessful");
        }
    }
}

