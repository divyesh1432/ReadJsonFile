using ConsoleApp1.Info;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1.Helper
{
    class JsonFileReader: IPetOwnerReader
    {
        private readonly string _jsonFilePath;

        public JsonFileReader(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        public IList<PetOwner> GetPetOwners()
        {
            using (StreamReader file = File.OpenText(_jsonFilePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                var jToken = JToken.ReadFrom(reader);
                return jToken.ToObject<IList<PetOwner>>();

            }
        }
    }
}
