using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace BankApp.Helpers
{
    // Native/JsonFileUtils.cs
    public static class JsonFileUtilsText
    {
        private static readonly JsonSerializerOptions _options = new() { 
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        public static void SimpleWrite(object obj, string fileName)
        {
            string jsonString = JsonSerializer.Serialize(obj, _options);
            File.WriteAllText(fileName, jsonString);
        }

        public static void PrettyWrite(object obj, string fileName)
        {
            var options = new JsonSerializerOptions(_options)
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(obj, options);
            File.WriteAllText(fileName, jsonString);
        }

        public static List<T> ReadFiles<T>(string fileName)
        {
            List<T> list;

            string[] arrayOfEachLines = File.ReadAllLines(fileName);
            string jsonTextBigString = File.ReadAllText(fileName);

            var options = new JsonSerializerOptions(_options)
            {
                WriteIndented = true,
            };

            list = JsonSerializer.Deserialize<List<T>>(jsonTextBigString);

            return list;
        }
    }
}
