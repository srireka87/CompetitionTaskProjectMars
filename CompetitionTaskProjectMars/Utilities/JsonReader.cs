using CompetitionTaskProjectMars.TestMap;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionTaskProjectMars.Utilities
{
    public class JsonReader
    {
        public List<AddEducationTestMap> ReadAddEducationJsonDataFile()
        {
            string jsonFile = JSONHelper.ReadJsonFile("C:\\Srireka-Project Mars\\CompetitionTaskProjectMars\\CompetitionTaskProjectMars\\TestData\\AddEducationJsonData.json");
            List<AddEducationTestMap> addEducationTestData = JSONHelper.DeserializeJson<List<AddEducationTestMap>>(jsonFile);
            return addEducationTestData;
        }

        public List<UpdateEducationTestMap> ReadUpdateEducationJsonDataFile()
        {
            string jsonFile = JSONHelper.ReadJsonFile("C:\\Srireka-Project Mars\\CompetitionTaskProjectMars\\CompetitionTaskProjectMars\\TestData\\UpdateEducationJsonData.json");
            List<UpdateEducationTestMap> updateEducationTestData = JSONHelper.DeserializeJson<List<UpdateEducationTestMap>>(jsonFile);
            return updateEducationTestData;
        }
        public List<AddEducationTestMap> ReadDeleteEducationJsonDataFile()
        {
            string jsonFile = JSONHelper.ReadJsonFile("C:\\Srireka-Project Mars\\CompetitionTaskProjectMars\\CompetitionTaskProjectMars\\TestData\\AddEducationJsonData.json");
            List<AddEducationTestMap> addEducationTestData = JSONHelper.DeserializeJson<List<AddEducationTestMap>>(jsonFile);
            return addEducationTestData;
        }
        public List<CancelEducationTestMap> ReadCancelEducationJsonDataFile()
        {
            string jsonFile = JSONHelper.ReadJsonFile("C:\\Srireka-Project Mars\\CompetitionTaskProjectMars\\CompetitionTaskProjectMars\\TestData\\CancelEducationJsonData.json");
            List<CancelEducationTestMap> cancelEducationTestData = JSONHelper.DeserializeJson<List<CancelEducationTestMap>>(jsonFile);
            return cancelEducationTestData;
        }
        
        public List<AlreadyExistingEducationTestMap> ReadExistingEducationJsonDataFile()
        {
            string jsonFile = JSONHelper.ReadJsonFile("C:\\Srireka-Project Mars\\CompetitionTaskProjectMars\\CompetitionTaskProjectMars\\TestData\\AlreadyExistingEducationJsonData.json");
            List<AlreadyExistingEducationTestMap> alreadyExistingEducationTestData = JSONHelper.DeserializeJson<List<AlreadyExistingEducationTestMap>>(jsonFile);
            return alreadyExistingEducationTestData;
        }

        public List<EnterAllFieldsEducationTestMap> ReadEnterAllFieldsEducationJsonDataFile()
        {
            string jsonFile = JSONHelper.ReadJsonFile("C:\\Srireka-Project Mars\\CompetitionTaskProjectMars\\CompetitionTaskProjectMars\\TestData\\EnterAllFieldsEducationJsonData.json");
            List<EnterAllFieldsEducationTestMap> allFieldsEducationTestData = JSONHelper.DeserializeJson<List<EnterAllFieldsEducationTestMap>>(jsonFile);
            return allFieldsEducationTestData;
        }
        public List<DuplicateEducationTestMap> ReadDuplicateEducationJsonDataFile()
        {
            string jsonFile = JSONHelper.ReadJsonFile("C:\\Srireka-Project Mars\\CompetitionTaskProjectMars\\CompetitionTaskProjectMars\\TestData\\DuplicateEducationJsonData.json");  
            List<DuplicateEducationTestMap> duplicateEducationTestData = JSONHelper.DeserializeJson<List<DuplicateEducationTestMap>>(jsonFile);
            return duplicateEducationTestData;    
        }
        public List<AddCertificationsTestMap> ReadAddCertificationsJsonDataFile()
        {
            string jsonFile = JSONHelper.ReadJsonFile("C:\\Srireka-Project Mars\\CompetitionTaskProjectMars\\CompetitionTaskProjectMars\\TestData\\AddCertificationsJsonData.json");
            List<AddCertificationsTestMap> addCertificationsTestData = JSONHelper.DeserializeJson<List<AddCertificationsTestMap>>(jsonFile);
            return addCertificationsTestData;
        }
        public List<UpdateCertificationsTestMap> ReadUpdateCertificationsJsonDataFile()
        {
            string jsonFile = JSONHelper.ReadJsonFile("C:\\Srireka-Project Mars\\CompetitionTaskProjectMars\\CompetitionTaskProjectMars\\TestData\\UpdateCertificationsJsonData.json");
            List<UpdateCertificationsTestMap> updateCertificationsTestData = JSONHelper.DeserializeJson<List<UpdateCertificationsTestMap>>(jsonFile);
            return updateCertificationsTestData;
        }
        public List<AddCertificationsTestMap> ReadDeleteCertificationsJsonDataFile()
        {
            string jsonFile = JSONHelper.ReadJsonFile("C:\\Srireka-Project Mars\\CompetitionTaskProjectMars\\CompetitionTaskProjectMars\\TestData\\AddCertificationsJsonData.json");
            List<AddCertificationsTestMap> addCertificationsTestData = JSONHelper.DeserializeJson<List<AddCertificationsTestMap>>(jsonFile);
            return addCertificationsTestData;
        }

        public List<CancelCertificationsTestMap> ReadCancelCertificationsJsonDataFile()
        {
            string jsonFile = JSONHelper.ReadJsonFile("C:\\Srireka-Project Mars\\CompetitionTaskProjectMars\\CompetitionTaskProjectMars\\TestData\\CancelCertificationsJsonData.json");
            List<CancelCertificationsTestMap> cancelCertificationsTestData = JSONHelper.DeserializeJson<List<CancelCertificationsTestMap>>(jsonFile);
            return cancelCertificationsTestData;
        }
        public List<AlreadyExistingCertificationsTestMap> ReadAlreadyExistCertificationsJsonDataFile()
        {
            string jsonFile = JSONHelper.ReadJsonFile("C:\\Srireka-Project Mars\\CompetitionTaskProjectMars\\CompetitionTaskProjectMars\\TestData\\AlreadyExistingCertificationsJsonData.json");
            List<AlreadyExistingCertificationsTestMap> alreadyExistingCertificationsTestData = JSONHelper.DeserializeJson<List<AlreadyExistingCertificationsTestMap>>(jsonFile);
            return alreadyExistingCertificationsTestData;
        }
        public List<EnterAllFieldsCertificationsTestMap> ReadEnterAllFieldsCertificationsJsonDataFile()
        {
            string jsonFile = JSONHelper.ReadJsonFile("C:\\Srireka-Project Mars\\CompetitionTaskProjectMars\\CompetitionTaskProjectMars\\TestData\\EnterAllFieldsCertificationsJsonData.json");
            List<EnterAllFieldsCertificationsTestMap> allFieldsCertificationsTestData = JSONHelper.DeserializeJson<List<EnterAllFieldsCertificationsTestMap>>(jsonFile);
            return allFieldsCertificationsTestData;
        }

        public List<DuplicateCertificationsTestMap> ReadDuplicateCertificationsJsonDataFile()
        {
            string jsonFile = JSONHelper.ReadJsonFile("C:\\Srireka-Project Mars\\CompetitionTaskProjectMars\\CompetitionTaskProjectMars\\TestData\\DuplicateCertificationsJsonData.json");
            List<DuplicateCertificationsTestMap> duplicateCertificationsTestData = JSONHelper.DeserializeJson<List<DuplicateCertificationsTestMap>>(jsonFile);
            return duplicateCertificationsTestData;
        }
    }
}
