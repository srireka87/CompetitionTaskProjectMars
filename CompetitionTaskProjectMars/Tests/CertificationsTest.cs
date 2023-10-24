using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using CompetitionTaskProjectMars.Utilities;
using CompetitionTaskProjectMars.Pages;
using CompetitionTaskProjectMars.TestMap;

namespace CompetitionTaskProjectMars.Tests
{
    [TestFixture]
  
    public class CertificationsTest : CommonDriver
    {

        Login loginPageObj;
        ProfileHomePage profileHomePageObj;
        CertificationsPage  certificationsPageObj;
        JsonReader reader;

        public CertificationsTest()
        {
            loginPageObj = new Login();
            profileHomePageObj = new ProfileHomePage();
            certificationsPageObj = new CertificationsPage();
            reader = new JsonReader();
        }

        [SetUp]
        public void SetUp()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            loginPageObj.LoginFunction("srireka87@gmail.com", "Rosesri@23");
            loginPageObj.LoginAssertion();
            profileHomePageObj.GoToProfileCertifications();
        }

        [Test, Description("Adding Certifications")]
        public void AddCertifications_Test()
        {
            List<AddCertificationsTestMap> addCertificationsTestData =reader.ReadAddCertificationsJsonDataFile();

            foreach (var inputJsonData in addCertificationsTestData)
            {
                string certificateAwardName = inputJsonData.CertificateAwardName;
                string certifiedFrom = inputJsonData.CertifiedFrom;
                string year = inputJsonData.Year;
                certificationsPageObj.AddCertifications(inputJsonData);
                Thread.Sleep(4000);
                string actualCertificateAwardName = certificationsPageObj.GetActualCertificateAwardNameAssertion();
                Assert.That(inputJsonData.CertificateAwardName == actualCertificateAwardName, "CertificateAward Name is not matching");

                string actualCertifiedFrom = certificationsPageObj.GetActualCertifiedFromAssertion();
                Assert.That(inputJsonData.CertifiedFrom == actualCertifiedFrom, "CertifiedFrom is not matching");
            }
        }

        [Test, Description("Update Certifications")]
        public void UpdateCertifications_Test()
        {
            List<UpdateCertificationsTestMap> updateCertificationsTestData = reader.ReadUpdateCertificationsJsonDataFile();

            foreach (var updateCertificationsInputJsonData in updateCertificationsTestData)
            {
                string certificateAwardName = updateCertificationsInputJsonData.CertificateAwardName;
                string certifiedFrom = updateCertificationsInputJsonData.CertifiedFrom;
                string year = updateCertificationsInputJsonData.Year;
                certificationsPageObj.AddCertifications(updateCertificationsInputJsonData);
            }

           foreach (var updateCertificationsInputJsonData in updateCertificationsTestData)
            {
                string certificateAwardName = updateCertificationsInputJsonData.NewCertificateAwardName;
                string certifiedFrom = updateCertificationsInputJsonData.NewCertifiedFrom;
                string year = updateCertificationsInputJsonData.NewYear;
                certificationsPageObj.UpdateCertifications(updateCertificationsInputJsonData);

                Thread.Sleep(2000);
                string actualUpdatedCertificateAwardName = certificationsPageObj.ActualUpdatedCertificateAwardNameAssertion();
                Assert.That(updateCertificationsInputJsonData.NewCertificateAwardName == actualUpdatedCertificateAwardName, "Updated CertificateAwardName is not matching");

                string actualUpdatedCertifiedFrom = certificationsPageObj.ActualUpdatedCertifiedFromAssertion();
                Assert.That(updateCertificationsInputJsonData.NewCertifiedFrom == actualUpdatedCertifiedFrom, "CertifiedFrom is not matching");
            }
        }

        [Test, Description("Delete Certifications")]
        public void DeleteCertifications_Test()
        {
            List<AddCertificationsTestMap> addCertificationsTestData = reader.ReadDeleteCertificationsJsonDataFile();
            string certificateAwardName = " ";

            foreach (var inputJsonData in addCertificationsTestData)
            {
                certificateAwardName = inputJsonData.CertificateAwardName;
                string certifiedFrom = inputJsonData.CertifiedFrom;
                string year = inputJsonData.Year;
                certificationsPageObj.AddCertifications(inputJsonData);
            }    
            certificationsPageObj.DeleteCertifications();
            string actualDeletePopUpMsg = certificationsPageObj.DeleteAssertion();
            string expectedPopUpMsg = certificateAwardName + " has been deleted from your certification";
            Assert.That(actualDeletePopUpMsg == expectedPopUpMsg, "Delete certifications is unsuccessful");                
        }

        [Test, Description("Cancel Certifications")]
        public void CancelCertifications_Test()
        {
            List<CancelCertificationsTestMap> cancelCertificationsTestData = reader.ReadCancelCertificationsJsonDataFile();

            foreach (var inputJsonData in cancelCertificationsTestData)
            {
                string certificateAwardName = inputJsonData.CertificateAwardName;
                string certifiedFrom = inputJsonData.CertifiedFrom;
                string year = inputJsonData.Year;
                certificationsPageObj.CancelCertifications(inputJsonData);
            }
        }


        [Test, Description("AlreadyExist Certifications")]
        public void AlreadyExistCertifications_Test()
        {
            List<AlreadyExistingCertificationsTestMap> alreadyExistingCertificationsTestData = reader.ReadAlreadyExistCertificationsJsonDataFile();

            foreach (var inputJsonData in alreadyExistingCertificationsTestData)
            {
                string certificateAwardName = inputJsonData.CertificateAwardName;
                string certifiedFrom = inputJsonData.CertifiedFrom;
                string year = inputJsonData.Year;
                certificationsPageObj.AlreadyExistingCertifications(inputJsonData);
            }
            string actualPopUpMsg = certificationsPageObj.AlreadyExistingAssertion();
            string expectedPopUpMsg = "This information is already exist.";
            Assert.That(actualPopUpMsg == expectedPopUpMsg, "AlreadyExisting Education Test is unsuccessful");
        }

        [Test, Description("InvalidInput Certifications")]
        public void EnterAllFieldsCertifications_Test()
        {
            List<EnterAllFieldsCertificationsTestMap> allFieldsCertificationsTestData = reader.ReadEnterAllFieldsCertificationsJsonDataFile();

            foreach (var inputJsonData in allFieldsCertificationsTestData)
            {
                string certificateAwardName = inputJsonData.CertificateAwardName;
                string certifiedFrom = inputJsonData.CertifiedFrom;
                string year = inputJsonData.Year;
                certificationsPageObj.EnterAllFieldsCertifications(inputJsonData);
            }
            string actualPopUpMsg = certificationsPageObj.EnterAllFieldsAssertion();
            string expectedPopUpMsg = "Please enter Certification Name, Certification From and Certification Year";
            Assert.That(expectedPopUpMsg == actualPopUpMsg, "EnterAllFieldsCertificationsTest is Unsuccessful");

        }

        [Test, Description("DuplicateData Certifications")]
        public void DuplicateCertificationsData_Test()
        {
            List<DuplicateCertificationsTestMap> duplicateCertificationsTestData = reader.ReadDuplicateCertificationsJsonDataFile();

            foreach (var inputJsonData in duplicateCertificationsTestData)
            {
                string certificateAwardName = inputJsonData.CertificateAwardName;
                string certifiedFrom = inputJsonData.CertifiedFrom;
                string year = inputJsonData.Year;
                certificationsPageObj.DuplicateCertificationsData(inputJsonData);
            }
            string actualDuplicatePopUpMsg = certificationsPageObj.DuplicateCertificationsDataAssertion();
            string expectedDuplicatePopUpMsg = "Duplicated data";
            Assert.That(actualDuplicatePopUpMsg == expectedDuplicatePopUpMsg, "DuplicateCertificationsData Test is unsuccessful");
        }
       
    }
}
