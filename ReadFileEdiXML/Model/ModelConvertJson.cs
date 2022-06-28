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
            public List<ModleObjetJsonTemp> ListChild { get; set; } = new List<ModleObjetJsonTemp>();
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
            public List<ModleObjetJson> ListChild { get; set; } = new List<ModleObjetJson>();
        }


        public class ComponentModelJson
        {
            [JsonProperty("Component")]
            public List<ModleObjetJson> Component { get; set; }
        }

        public class JsonStructureRequest
        {
            [JsonProperty("Header")]
            public Header Header { get; set; }

            [JsonProperty("LineItems")]
            public IList<LineItem> LineItems { get; set; }

            [JsonProperty("Summary")]
            public Summary Summary { get; set; }
        }
        public class Header
        {
            public long ID { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string StartWith { get; set; }            
            public long ParentComponentID { get; set; }
            public bool IsRepeatable { get; set; }

            [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
            public IList<ModleObjetJson> ListChild { get; set; } = new List<ModleObjetJson>();
        }
        public class LineItem
        {
            public long ID { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string StartWith { get; set; }
            public long ParentComponentID { get; set; }
            public bool IsRepeatable { get; set; }

            [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
            public IList<ModleObjetJson> ListChild { get; set; } = new List<ModleObjetJson>();
        }
        public class Summary
        {
            public long ID { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string StartWith { get; set; }
            public long ParentComponentID { get; set; }
            public bool IsRepeatable { get; set; }

            [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
            public IList<ModleObjetJson> ListChild { get; set; } = new List<ModleObjetJson>();
        }
    }
}