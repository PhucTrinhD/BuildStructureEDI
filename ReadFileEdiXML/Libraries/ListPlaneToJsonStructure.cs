using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using static ReadFileEdiXML.Model.ModelConvertJson;

namespace ReadFileEdiXML.Libraries
{
    public static class ListPlaneToJsonStructure
    {
        public static string BuildListPlaneToJsonStructure(List<ModleObjetJson> listData)
        {
            string json = string.Empty;

            var listJson = BuildListPlaneToListJson(listData);
            var dynamicData = BuildListJsonToJsonStructure(listJson);

            json = JsonConvert.SerializeObject(dynamicData, Formatting.Indented);
            return json;
        }

        public static List<ModleObjetJson> BuildListPlaneToListJson(List<ModleObjetJson> list)
        {
            var listParent = new Dictionary<long, ModleObjetJson>();
            var nested = new List<ModleObjetJson>();

            foreach (ModleObjetJson item in list)
            {
                if (listParent.ContainsKey(item.ParentComponentID))
                    listParent[item.ParentComponentID].ListChild.Add(item);
                else
                    nested.Add(item);

                listParent.Add(item.ID, item);
            }
            return nested;
        }

        public static dynamic BuildListJsonToJsonStructure(List<ModleObjetJson> list)
        {
            dynamic tempItem = new ExpandoObject();
            IDictionary<string, object> jHeader = new ExpandoObject(); var jDetail = new List<dynamic>(); ;
            IDictionary<string, object> jSummary = new ExpandoObject();

            foreach (ModleObjetJson item in list)
            {
                //build Header
                if (item.Name == "Header")
                {
                    addParent(item.ListChild, jHeader);
                }

                //build Detail
                if (item.Name == "Detail")
                {
                    IDictionary<string, object> objeDetail = new ExpandoObject();
                    addParent(item.ListChild, objeDetail);
                    jDetail.Add(objeDetail);
                }

                //build Summary
                if (item.Name == "Summary")
                {
                    addParent(item.ListChild, jSummary);
                }
            }

            tempItem.Header = jHeader;
            tempItem.Detail = jDetail;
            tempItem.Summary = jSummary;

            return tempItem;
        }

        #region Private static

        private static void addChildren(List<ModleObjetJson> listChild, IDictionary<string, object> jHeader, string keyParent)
        {
            IDictionary<string, object> clidRow = new ExpandoObject();
            foreach (var item in listChild)
            {
                var key = item.Name; var value = item.StartWith;
                var listSame = listChild.Where(a => a.Name == item.Name).ToList();

                if (item.ListChild.Count <= 1 && listSame.Count() <= 1)
                    addPropertyObject(clidRow, key, value);
                else
                {
                    if (listSame != null && listSame.Count > 0 && !clidRow.ContainsKey(key))
                    {
                        mergeObjectToList(listSame, clidRow, key);
                    }
                    else
                        addChildren(item.ListChild, clidRow, key);
                }
            }
            if (!jHeader.ContainsKey(keyParent))
                jHeader.Add(keyParent, clidRow);
        }

        private static void addPropertyObject(IDictionary<string, object> jTemp, string keys, string values)
        {
            if (!jTemp.ContainsKey(keys))
                jTemp.Add(keys, values);
            else
                jTemp[keys] = values;
        }

        private static void addParent(List<ModleObjetJson> listChild, IDictionary<string, object> jTemp)
        {
            foreach (var item in listChild)
            {
                var key = item.Name; var value = item.StartWith;

                var listSame = listChild.FindAll(a => a.Name == item.Name);

                if (item.ListChild.Count <= 1 && listSame.Count() <= 1)
                {
                    addPropertyObject(jTemp, key, value);
                }
                else
                {
                    if (listSame != null && listSame.Count > 1 && !jTemp.ContainsKey(key))
                    {
                        mergeObjectToList(listSame, jTemp, key);
                    }
                    else
                    {
                        addChildren(item.ListChild, jTemp, key);
                    }
                }
            }
        }

        private static void mergeObjectToList(List<ModleObjetJson> listChild, IDictionary<string, object> jTemp, string keyParent)
        {
            IDictionary<string, object> childRow = new ExpandoObject();
            int index = 1;
            foreach (var item in listChild)
            {
                var key = item.Name + index; var value = item.StartWith;
                if (item.ListChild.Count <= 1)
                    addPropertyObject(childRow, key, value);
                else
                    addChildren(item.ListChild, childRow, key);

                index++;
            }
            jTemp.Add(keyParent, childRow);
        }

        #endregion Private static
    }
}