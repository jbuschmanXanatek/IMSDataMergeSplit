using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace IMSDataMergeSplit
{
    public partial class SettingsForm : Form
    {
        public Setting Setting { get; set; }
        public bool HasErrors { get; set; }

        private string _customerName;
        public SettingsForm(string customerName, Setting setting)
        {
            InitializeComponent();

            Setting = setting;
            _customerName = customerName;
            //txtRecordTrackingPath.Text = Path.GetFullPath(@".\");

            UpdateSourceView();
            DisplaySettingData();
        }

        private void NeedsSaved()
        {
            bool needsSaved = false;
            if (Setting == null)
            {
                needsSaved = true;
            }
            else
            {
                if (Setting.SQLDestination != null)
                {
                    if (txtDestCatalog.Text != Setting.SQLDestination.Catalog)
                        needsSaved = true;
                    else if (txtDestComputerName.Text != Setting.SQLDestination.ComputerName)
                        needsSaved = true;
                    else if (txtDestInstance.Text != Setting.SQLDestination.Instance)
                        needsSaved = true;
                    else if (txtDestPort.Text != Setting.SQLDestination.Port)
                        needsSaved = true;                    
                }
                if (Setting.SQLSource != null)
                {
                    if (txtSourceCatalog.Text != Setting.SQLSource.Catalog)
                        needsSaved = true;
                }
                //if (!needsSaved)
                //{
                //    if (txtRecordTrackingPath.Text != Setting.RecordTrackingPath)
                //        needsSaved = true;
                //}
            }
            btnSave.Enabled = needsSaved;
            btnOK.Enabled = !needsSaved;
        }

        private void ClearAllErrors()
        {
            errorProvider1.SetError(txtSourceCatalog, "");
            errorProvider1.SetError(txtDestCatalog, "");
            errorProvider1.SetError(txtDestComputerName, "");
            errorProvider1.SetError(txtDestInstance, "");
            errorProvider1.SetError(txtDestPort, "");
        }

        private void UpdateSourceView()
        {
            errorProvider1.SetError(txtSourceCatalog, "");
        }

        private void btnLoadSetting_Click(object sender, EventArgs e)
        {
            using (var file = new OpenFileDialog())
            {
                file.Filter = "XML files (*.xml)|*.xml";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    using (Stream stream = file.OpenFile())
                    {
                        using (StreamReader sr = new StreamReader(file.FileName, true))
                        {
                            XDocument xdoc = XDocument.Load(sr);
                            XmlSerializer s = new XmlSerializer(typeof(Setting));
                            Setting = (Setting)s.Deserialize(xdoc.CreateReader());
                            Setting.FilePath = file.FileName;
                        }
                    }
                    txtFilePath.Text = Path.GetFileName(Setting.FilePath);
                }
            }
            DisplaySettingData();
            ClearAllErrors();
        }

        private void DisplaySettingData()
        {
            if (Setting != null)
            {
                //txtRecordTrackingPath.Text = Setting.RecordTrackingPath;
                if (Setting.SQLDestination != null)
                {
                    txtDestCatalog.Text = Setting.SQLDestination.Catalog;
                    txtDestComputerName.Text = Setting.SQLDestination.ComputerName;
                    txtDestInstance.Text = Setting.SQLDestination.Instance;
                    txtDestPort.Text = Setting.SQLDestination.Port;
                }
                if (Setting.UseDB)
                {
                    txtSourceCatalog.Text = Setting.SQLSource.Catalog;
                }
            }
            NeedsSaved();
        }

        private string ConverToXML(object data)
        {
            var sw = new System.IO.StringWriter();
            var serializer = new System.Xml.Serialization.XmlSerializer(data.GetType());
            serializer.Serialize(sw, data);
            return sw.ToString();
        }

        private bool ErrorsOnForm()
        {
            foreach (Control mainControl in this.Controls)
            {
                if (mainControl is GroupBox)
                {
                    if (errorProvider1.GetError(mainControl).Length > 0)
                        return true;
                    foreach (Control parentGB in mainControl.Controls)
                    {
                        if (parentGB is GroupBox)
                        {
                            foreach (Control childGB in parentGB.Controls)
                            {
                                if (errorProvider1.GetError(childGB).Length > 0)
                                    return true;
                            }
                        }
                        else
                        {
                            if (errorProvider1.GetError(parentGB).Length > 0)
                                return true;
                        }
                    }
                }
                else
                {
                    if (errorProvider1.GetError(mainControl).Length > 0)
                        return true;
                }
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.ValidateChildren();
            if (ErrorsOnForm())
            {
                MessageBox.Show("Please fix any errors on the form and try again.", "Error");
            }
            else
            {
                string tempFilePath = "";
                if (Setting != null && Setting.FilePath != "")
                    tempFilePath = Setting.FilePath;
                
                    Setting = new Setting(_customerName, "", new SQLSetting()
                    {
                        Catalog = txtDestCatalog.Text,
                        ComputerName = txtDestComputerName.Text,
                        Instance = txtDestInstance.Text,
                        Port = txtDestPort.Text
                    },
                    new SQLSetting()
                    {
                        Catalog = txtSourceCatalog.Text
                    }
                    );

                var xml = ConverToXML(Setting);
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = _customerName + ".xml";
                saveFile.Filter = "XML files (*.xml)|*.xml";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                        sw.WriteLine(xml);

                    Setting.FilePath = saveFile.FileName;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtDestCatalog_TextChanged(object sender, EventArgs e)
        {
            NeedsSaved();
        }

        private void txtSourceCatalog_TextChanged(object sender, EventArgs e)
        {
            NeedsSaved();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ValidateChildren();
            if (ErrorsOnForm())
                HasErrors = true;

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtDestCatalog_Validating(object sender, CancelEventArgs e)
        {
            if (txtDestCatalog.Text == "")
                errorProvider1.SetError(txtDestCatalog, "Catalog cannot be blank");
            else
                errorProvider1.SetError(txtDestCatalog, "");
        }

        private void txtSourceCatalog_Validating(object sender, CancelEventArgs e)
        {

                if (txtSourceCatalog.Text == "")
                    errorProvider1.SetError(txtSourceCatalog, "Catalog cannot be blank");
                else
                    errorProvider1.SetError(txtSourceCatalog, "");

        }

        private void txtRecordTrackingPath_TextChanged(object sender, EventArgs e)
        {
            NeedsSaved();
        }

        private void btnRecordTrackingPath_Click(object sender, EventArgs e)
        {
            //txtRecordTrackingPath.Text = SelectPath();
            NeedsSaved();
        }

        private string SelectPath()
        {
            string path = "";
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    path = fbd.SelectedPath;
                }
            }
            return path;
        }
    }
}