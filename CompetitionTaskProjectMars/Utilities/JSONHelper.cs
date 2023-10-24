
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.IO;


namespace CompetitionTaskProjectMars.Utilities
{


    public class JSONHelper 
    {

        public static string ReadJsonFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return json;
        }

        public static T DeserializeJson<T>(string json)
        {
            T obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }
    }


    
}
