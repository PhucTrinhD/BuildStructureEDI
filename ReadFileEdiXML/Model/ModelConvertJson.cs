using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReadFileEdiXML.Model
{
    public class ModelConvertJson
    {
        public class ModleObjetJsonTemp
        {
            public long ID { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string StartWith { get; set; }
            public long ParentComponentID { get; set; }
            public string ParentName { get; set; }
            public bool IsRepeatable { get; set; }

           [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
            public IList<ModleObjetJsonTemp> ListChild { get; set; } = new List<ModleObjetJsonTemp>();
        }

        public class ModleObjetJson
        {
            public long ID { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string StartWith { get; set; }
            //[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public long ParentComponentID { get; set; }
            public bool IsRepeatable { get; set; }

            [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
            public IList<ModleObjetJson> ListChild { get; set; } = new List<ModleObjetJson>();
        }


        public class ComponentModelJson
        {
            [JsonProperty("Component")]
            public List<ModleObjetJson> Component { get; set; }
        }
    }
}