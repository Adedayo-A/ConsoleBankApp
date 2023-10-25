using BankApp.CustomerAccount;
using BankApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Helpers
{
    // Newtonsoft/JsonFileUtils.cs
    public static class JsonFileUtilsNewton
    {
        private static readonly JsonSerializerSettings _options
            = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public static void SimpleWrite(object obj, string fileName)
        {
            // string jsonString = await JsonConvert.SerializeObjectAsync(obj, Formatting.Indented, _options);

            var jsonString = JsonConvert.SerializeObject(obj, _options);

            File.WriteAllText(fileName, jsonString);

            //File.AppendAllText(fileName, jsonString);
        }

        public static void PrettyWrite(object obj, string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new ArgumentException("Filename does not exist");
            }

            var jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented, _options);
            File.WriteAllText(fileName, jsonString);
        }

        public static async Task<List<T>> ReadFiles<T>(string fileName)
        {
            List<T> list;

            var options = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            string[] arrayOfEachLines = File.ReadAllLines(fileName);

            string jsonTextBigString = File.ReadAllText(fileName);

            Task<List<T>>? li = JsonConvert.DeserializeObjectAsync<List<T>>(jsonTextBigString);

            //await JsonConvert.DeserializeObjectAsync

            list = await li;


            return list;
        }

        public static T ReadFile<T>(string fileName, int index)
        {
            if (!File.Exists(fileName))
            {
                throw new ArgumentException("Filename does not exist");
            }

            var options = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            string[] arrayOfEachLines = File.ReadAllLines(fileName);
            string jsonTextBigString = File.ReadAllText(fileName);

            //await JsonConvert.DeserializeObjectAsync

            var obj = JsonConvert.DeserializeObject<T>(arrayOfEachLines[index], options);

            return obj;
        }

        public static T ReadLastElement<T>(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new ArgumentException("Filename does not exist");
            }

            var options = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            string[] arrayOfEachLines = File.ReadAllLines(fileName);
            string jsonTextBigString = File.ReadAllText(fileName);

            int lastElementCount = arrayOfEachLines.Length - 1;

            //await JsonConvert.DeserializeObjectAsync

            var obj = JsonConvert.DeserializeObject<T>(arrayOfEachLines[lastElementCount], options);

            return obj;
        }
    }
}