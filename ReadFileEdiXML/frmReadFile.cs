using Newtonsoft.Json;
using ReadFileEdiXML.Libraries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using static ReadFileEdiXML.Model.ModelConvertJson;

namespace ReadFileEdiXML
{
    public partial class frmReadFile : Form
    {
        private readonly string titlePopup = "Annoucement From System";
        private readonly string extensionFileInvalid = "Extention invalid.";
        private readonly string readFileSuccess = "Success!";
        private readonly string chooseFileBeforeSubmit = "Please choose file before submit!";

        public frmReadFile()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var filePath = txtNameFile.Text;
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show(chooseFileBeforeSubmit, titlePopup, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SetText(filePath);
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (openDialogXML.ShowDialog() == DialogResult.OK)
            {
                txtNameFile.Text = string.Empty;
                txtShowData.Text = string.Empty;
                ValidateFile(openDialogXML);
            }
        }

        #region Method

        public void ValidateFile(OpenFileDialog openFile)
        {
            var fileName = openFile.FileName;
            if (Path.GetExtension(fileName).ToLower() != ".xml".ToLower())
            {
                MessageBox.Show(extensionFileInvalid, titlePopup, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtNameFile.Text = fileName;
        }

        public void SetText(string path)
        {
            var listPlane = ConvertXmlToListPlane(path);
            txtShowData.Text = File.ReadAllText(path);
            //txtDataPure.Text = BuildListPlaneToJson(listPlane);
            txtDataPure.Text = ConvertDataXmlToJson(path);
            MessageBox.Show(readFileSuccess, titlePopup, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string ConvertDataXmlToJson(string path)
        {
            XDocument xmlPart = XDocument.Load(path);

            var modelListXElement = new List<ModleElement>();

            var dataModle = xmlPart.Descendants().SelectMany(x => x.Descendants()).Distinct();

            int index = 1;
            foreach (var item in dataModle)
            {
                var objXElement = new ModleElement();

                objXElement.Name = item.Attribute("name")?.Value;
                objXElement.Type = item.Name.LocalName;
                objXElement.StartWith = item.Attribute("startWith")?.Value;

                bool isRepeatable;
                bool.TryParse(item.Attribute("IsRepeatable")?.Value, out isRepeatable);

                objXElement.IsRepeatable = isRepeatable;
                objXElement.ParentName = item.Parent.Attribute("name")?.Value.ToString();

                if (!string.IsNullOrWhiteSpace(objXElement.ParentName))
                    objXElement.ParentComponentID = modelListXElement.FirstOrDefault(a => a.Name == objXElement.ParentName)?.ID ?? 0;

                //Key first
                if (string.IsNullOrWhiteSpace(objXElement.Name) && string.IsNullOrWhiteSpace(objXElement.StartWith) && string.IsNullOrWhiteSpace(objXElement.StartWith))
                    continue;

                objXElement.ID = index;
                modelListXElement.Add(objXElement);
                index++;
            }

            var listWithoutCol = modelListXElement.Select(x => new ModleDataObject
            {
                ID = x.ID,
                Name = x.Name,
                Type = x.Type,
                StartWith = x.StartWith,
                ParentComponentID = x.ParentComponentID,
                IsRepeatable = x.IsRepeatable
            }).ToList();

            ComponentModel component = new ComponentModel()
            {
                Component = listWithoutCol
            };
            return JsonConvert.SerializeObject(component, Formatting.Indented);
        }

        public static List<ModleObjetJson> ConvertXmlToListPlane(string path)
        {
            XDocument xmlPart = XDocument.Load(path);

            var modelListXElement = new List<ModleObjetJsonTemp>();

            var dataModle = xmlPart.Descendants().SelectMany(x => x.Descendants()).Distinct();

            int index = 1;
            foreach (var item in dataModle)
            {
                var objXElement = new ModleObjetJsonTemp();

                objXElement.Name = item.Attribute("name")?.Value;
                objXElement.Type = item.Name.LocalName;
                objXElement.StartWith = item.Attribute("startWith")?.Value;

                bool isRepeatable;
                bool.TryParse(item.Attribute("IsRepeatable")?.Value, out isRepeatable);

                objXElement.IsRepeatable = isRepeatable;
                objXElement.ParentName = item.Parent.Attribute("name")?.Value.ToString();

                if (!string.IsNullOrWhiteSpace(objXElement.ParentName))
                    objXElement.ParentComponentID = modelListXElement.FirstOrDefault(a => a.Name == objXElement.ParentName)?.ID ?? 0;

                //Key first
                if (string.IsNullOrWhiteSpace(objXElement.Name) && string.IsNullOrWhiteSpace(objXElement.StartWith) && string.IsNullOrWhiteSpace(objXElement.StartWith))
                    continue;

                objXElement.ID = index;
                modelListXElement.Add(objXElement);
                index++;
            }

            // map data
            var resultData = modelListXElement.Select(x => new ModleObjetJson
            {
                ID = x.ID,
                Name = x.Name,
                Type = x.Type,
                StartWith = x.StartWith,
                ParentComponentID = x.ParentComponentID,
                IsRepeatable = x.IsRepeatable,
                ListChild = x.ListChild.Select(a => new ModleObjetJson
                {
                    ID = a.ID,
                    Name = a.Name,
                    Type = a.Type,
                    StartWith = a.StartWith,
                    ParentComponentID = a.ParentComponentID,
                    IsRepeatable = a.IsRepeatable,
                }).ToList()
            }).ToList();

            return resultData;
        }

        public string BuildListPlaneToJson(List<ModleObjetJson> list)
        {
            var listParent = new Dictionary<long, ModleObjetJson>();
            var nested = new List<ModleObjetJson>();
            string json = string.Empty;

            foreach (ModleObjetJson item in list)
            {
                if (listParent.ContainsKey(item.ParentComponentID))
                    // add to the parent's child list
                    listParent[item.ParentComponentID].ListChild.Add(item);
                else
                    // no parent added yet (or this is the first time)
                    nested.Add(item);

                listParent.Add(item.ID, item);
            }

            ComponentModelJson component = new ComponentModelJson()
            {
                Component = nested
            };
            json = JsonConvert.SerializeObject(component, Formatting.Indented,
                               new JsonSerializerSettings
                               {
                                   NullValueHandling = NullValueHandling.Ignore,
                                   ContractResolver = ScheduleShouldSerializeContractResolver.Instance
                               });

            return json;
        }

        #endregion Method

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNameFile.Text = string.Empty;
            txtShowData.Text = string.Empty;
            txtDataPure.Text = string.Empty;
        }
    }

    #region Class

    internal class ModleElement
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string StartWith { get; set; }
        public long ParentComponentID { get; set; }
        public string ParentName { get; set; }
        public bool IsRepeatable { get; set; }
    }

    internal class ModleDataObject
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string StartWith { get; set; }
        public long ParentComponentID { get; set; }
        public bool IsRepeatable { get; set; }
    }

    internal class ComponentModel
    {
        [JsonProperty("Component")]
        public List<ModleDataObject> Component { get; set; }
    }

    #endregion Class
}