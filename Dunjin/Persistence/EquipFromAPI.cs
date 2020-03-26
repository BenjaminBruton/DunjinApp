using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dunjin.Persistence
{
    public class EquipFromAPI
    {

        [JsonProperty("index")]
        public string index { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }
    }

    public class EquipmentList
    {

        [JsonProperty("results")]
        public IList<EquipFromAPI> equipFromAPIs { get; set; }
    }



}
