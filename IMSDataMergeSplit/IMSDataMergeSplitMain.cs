using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using XanatekEventAPI;

namespace IMSDataMergeSplit
{
    public partial class IMSDataMergeSplitMain : Form
    {
        private string VERSION = "1.0.1"; //doing my for own sanity j.buschman 04032019

        private string SOURCE_SCRIPT_PATH = @"\\vmdev\develop\Current Files\IMS (4.x)\Insert Scripts";
        private string SCRIPT_PATH = @".\Insert Scripts\";
        private Setting _setting;
        List<string> _files = new List<string>();
        List<string> _splitSkipFiles = new List<string>() { "100 AL3MessageHeaders.txt", "101 AL3Transactions.txt", "102 AL3Groups.txt","104 CommissionTransactions.txt","105 CommissionEntries.txt","106 ProducerCommissionEntries.txt" };

        EventCollection _eventLog = new EventCollection(@".\Logs", " IMSDataMergeSplitErrorLog");

        public IMSDataMergeSplitMain()
        {
            InitializeComponent();
            chkAgencies.Enabled = false;
            chkProducers.Enabled = false;
            lblAgencies.Enabled = false;
            lblProducers.Enabled = false;
            DisableEnableForm();
            GetScripts(true);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSettingsFile();
            DisableEnableForm();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewEditSettings();
            DisableEnableForm();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewEditSettings(true);
            DisableEnableForm();
        }

        private void btnLoadSetup_Click(object sender, EventArgs e)
        {
            LoadSettingsFile();
            DisableEnableForm();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            txtInfo.Text = "";
            if (rdoMerge.Checked)
            {
                var processThread = new System.Threading.Thread(() => RunMerge());
                processThread.Start();
            }
            else if (rdoSplit.Checked)
            {
                var processThread = new System.Threading.Thread(() => RunSplit());
                processThread.Start();
            }
        }

        private void RunSplit()
        {
            string sql = "";
            try
            {
                string connectionString = _setting.GenerateConnectionString(_setting.SQLDestination.Catalog);
                if (connectionString != "")
                {
                    using (IMSDatabase database = new IMSDatabase(connectionString))
                    {


                        int count = 0;
                        database.Connect();

                        try
                        {
                            database.ExecuteSQL("ALTER TABLE [" + _setting.SQLSource.Catalog + "].[dbo].ImportKey ADD ParentID uniqueidentifier null");
                        }
                        catch
                        {
                        }
                        try
                        {
                            database.ExecuteSQL("ALTER TABLE [" + _setting.SQLDestination.Catalog + "].[dbo].ImportKey ADD ParentID uniqueidentifier null");
                        }
                        catch
                        {
                        }

                        try
                        {
                            database.ExecuteSQL("ALTER TABLE [" + _setting.SQLSource.Catalog + "].[dbo].ImportKey ADD CreateDate datetime null");
                        }
                        catch
                        {
                        }
                        try
                        {
                            database.ExecuteSQL("ALTER TABLE [" + _setting.SQLDestination.Catalog + "].[dbo].ImportKey ADD CreateDate datetime null");
                        }
                        catch
                        {
                        }

                        _files.Clear();
                        _files.AddRange(Directory.GetFiles(SCRIPT_PATH).CustomSort().ToArray());
                        _files.AddRange(Directory.GetFiles(SCRIPT_PATH + @"Additional\"));
                        var cleanFiles = Directory.GetFiles(SCRIPT_PATH + @"Clean Up Scripts\").CustomSort().ToArray();                        
                        txtInfo.Invoke((MethodInvoker)(() => progressBar.Maximum = _files.Count()));
                        lblMessage.Invoke((MethodInvoker)(() => lblMessage.Text = ""));
                        progressBar.Invoke((MethodInvoker)(() => progressBar.Value = 1));
                        int counter = 1;
                        string name = "";

                        List<string> selectedProducers = chkProducers.Properties.GetCheckedItems().ToString().Split(',').ToList();
                        List<string> selectedAgencies = chkAgencies.Properties.GetCheckedItems().ToString().Split(',').ToList();

                        if (selectedProducers != null)
                        {
                            foreach (var item in selectedProducers)
                            {
                                if (item.Trim() == string.Empty)
                                    continue;
                                foreach (var data in _files)
                                {
                                    name = Path.GetFileName(data);

                                    if (_splitSkipFiles.Contains(name))
                                        continue;

                                    lblMessage.Invoke((MethodInvoker)(() => lblMessage.Text = "File " + counter + " of " + _files.Count() + " (" + name + ")"));
                                    sql = File.ReadAllText(data);

                                    //we are using the merge scripts so we need to reverse the insert.
                                    sql = sql.Replace("[other]", "[" + _setting.SQLSource.Catalog + "~]");
                                    sql = sql.Replace("[Other]", "[" + _setting.SQLSource.Catalog + "~]");
                                    sql = sql.Replace("[OTHER]", "[" + _setting.SQLSource.Catalog + "~]");

                                    sql = sql.Replace("OTHER.", _setting.SQLSource.Catalog + "~.");
                                    sql = sql.Replace("Other.", _setting.SQLSource.Catalog + "~.");
                                    sql = sql.Replace("other.", _setting.SQLSource.Catalog + "~.");

                                    sql = sql.Replace("[IMS]", "[" + _setting.SQLDestination.Catalog + "]");
                                    sql = sql.Replace("[ims]", "[" + _setting.SQLDestination.Catalog + "]");

                                    sql = sql.Replace("IMS.", _setting.SQLDestination.Catalog + ".");
                                    sql = sql.Replace("ims.", _setting.SQLDestination.Catalog + ".");

                                    sql = sql.Replace("[" + _setting.SQLSource.Catalog + "~]", "[" + _setting.SQLSource.Catalog + "]");
                                    sql = sql.Replace(_setting.SQLSource.Catalog + "~.", _setting.SQLSource.Catalog + ".");

                                    if (name.ToLower().Contains("entities.txt"))
                                    {
                                        sql += Environment.NewLine + " and [UID] in (select [EntityUID] from [ims].[dbo].Customers where ProducerUID = @ProducerUID) ";
                                        
                                    }
                                    else if (name.ToLower().Contains("FileHeaders.txt"))
                                        sql += Environment.NewLine + " AND FileFolderUID != '00000000-0000-0000-0000-000000000000' ";

                                    count = database.ExecuteSQLByProducer(sql, Guid.Parse(item.Trim()));
                                    txtInfo.Invoke((MethodInvoker)(() => txtInfo.AppendText(count + " rows affected    -   " + name + " completed" + Environment.NewLine)));
                                    progressBar.Invoke((MethodInvoker)(() => progressBar.Increment(1)));
                                    counter++;
                                }
                            }
                        }

                        if (selectedAgencies != null)
                        {
                            foreach (var item in selectedAgencies)
                            {
                                if (item.Trim() == string.Empty)
                                    continue;
                                foreach (var data in _files)
                                {
                                    name = Path.GetFileName(data);

                                    if (_splitSkipFiles.Contains(name))
                                        continue;

                                    lblMessage.Invoke((MethodInvoker)(() => lblMessage.Text = "File " + counter + " of " + _files.Count() + " (" + name + ")"));
                                    sql = File.ReadAllText(data);
                                    
                                    //we are using the merge scripts so we need to reverse the insert.
                                    sql = sql.Replace("[other]", "[" + _setting.SQLSource.Catalog+"~]");
                                    sql = sql.Replace("[Other]", "[" + _setting.SQLSource.Catalog + "~]");
                                    sql = sql.Replace("[OTHER]", "[" + _setting.SQLSource.Catalog + "~]");

                                    sql = sql.Replace("OTHER.", _setting.SQLSource.Catalog + "~.");
                                    sql = sql.Replace("Other.", _setting.SQLSource.Catalog + "~.");
                                    sql = sql.Replace("other.", _setting.SQLSource.Catalog + "~.");

                                    sql = sql.Replace("[IMS]", "[" + _setting.SQLDestination.Catalog + "]");
                                    sql = sql.Replace("[ims]", "[" + _setting.SQLDestination.Catalog + "]");

                                    sql = sql.Replace("IMS.", _setting.SQLDestination.Catalog + ".");
                                    sql = sql.Replace("ims.", _setting.SQLDestination.Catalog + ".");

                                    sql = sql.Replace("[" + _setting.SQLSource.Catalog + "~]", "[" + _setting.SQLSource.Catalog + "]");
                                    sql = sql.Replace(_setting.SQLSource.Catalog + "~.", _setting.SQLSource.Catalog + ".");

                                    if (name.ToLower().Contains("entities.txt"))
                                    {
                                        sql += Environment.NewLine + " and [AgencyUID] = @AgencyUID ";
                                        if(chkExcludeAgencyAndMerge.Checked)
                                            sql += Environment.NewLine + @" And EntityType = 'C' ";

                                    }
                                    else if (name.ToLower().Contains("policies.txt"))
                                    {                                        
                                        sql += Environment.NewLine + " and [AgencyUID] = @AgencyUID ";
                                    }
                                    else if (name.ToLower().Contains("FileHeaders.txt"))
                                        sql += Environment.NewLine + " AND FileFolderUID != '00000000-0000-0000-0000-000000000000' ";

                                    count = database.ExecuteSQLByAgency(sql, Guid.Parse(item.Trim()));
                                    txtInfo.Invoke((MethodInvoker)(() => txtInfo.AppendText(count + " rows affected    -   " + name + " completed" + Environment.NewLine)));
                                    progressBar.Invoke((MethodInvoker)(() => progressBar.Increment(1)));
                                    counter++;
                                }
                            }
                        }

                        count = 0;
                        counter = 1;
                        foreach (var file in cleanFiles)
                        {
                            name = Path.GetFileName(file);
                            lblMessage.Invoke((MethodInvoker)(() => lblMessage.Text = "File " + counter + " of " + _files.Count() + " (" + name + ")"));
                            sql = File.ReadAllText(file);

                            count = database.ExecuteSQL(sql);
                            txtInfo.Invoke((MethodInvoker)(() => txtInfo.AppendText(count + " rows affected    -   " + name + " completed" + Environment.NewLine)));
                            progressBar.Invoke((MethodInvoker)(() => progressBar.Increment(1)));
                            counter++;

                        }

                        database.Disconnect();
                    }
                    txtInfo.Invoke((MethodInvoker)(() => txtInfo.AppendText("Finished!")));
                }
            }
            catch (Exception ex)
            {
                ErrorLog("RunSplit", ex.ToString());                
            }
        }

        //private void RunCheck()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    try
        //    {
        //        string connectionString = GenerateConnectionString(_setting.SQLDestination);
        //        if (connectionString != "")
        //        {
        //            using (IMSDatabase database = new IMSDatabase(connectionString))
        //            {
        //                _files.Clear();
        //                database.Connect();
        //                _files.AddRange(Directory.GetFiles(SCRIPT_PATH).CustomSort().ToArray());
        //                _files.AddRange(Directory.GetFiles(SCRIPT_PATH + @"Additional\"));
        //                string sql = "";
        //                //txtInfo.Invoke((MethodInvoker)(() => progressBar.Maximum = _files.Count()));
        //                //lblMessage.Invoke((MethodInvoker)(() => lblMessage.Text = ""));
        //                //progressBar.Invoke((MethodInvoker)(() => progressBar.Value = 1));
        //                int counter = 1;
        //                string name = "";
        //                foreach (var data in _files)
        //                {
        //                    //name = Path.GetFileName(data);
        //                    //lblMessage.Invoke((MethodInvoker)(() => lblMessage.Text = "File " + counter + " of " + _files.Count() + " (" + name + ")"));
        //                    //sql = File.ReadAllText(data);

        //                    var splt = data.Replace(".txt","").Split(' ');

        //                    sql = "select * from [" + _setting.SQLSource.Catalog + "].dbo." + splt[1];

        //                    sql = "select * from [" + _setting.SQLDestination.Catalog + "].dbo." + splt[1];


        //                    var count = database.ExecuteSQL(sql);
        //                    txtInfo.Invoke((MethodInvoker)(() => txtInfo.AppendText(count + " rows affected    -   " + name + " completed" + Environment.NewLine)));
        //                    progressBar.Invoke((MethodInvoker)(() => progressBar.Increment(1)));
        //                    counter++;
        //                }
        //                database.Disconnect();
        //            }
        //            txtInfo.Invoke((MethodInvoker)(() => txtInfo.AppendText("Finished!")));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog("RunMerge", ex.ToString());
        //    }
        //}

        private void RunMerge()
        {
            string sql = "";
            try
            {
                string connectionString = _setting.GenerateConnectionString(_setting.SQLDestination.Catalog);
                if (connectionString != "")
                {
                    using (IMSDatabase database = new IMSDatabase(connectionString))
                    {
                        database.Connect();
                        try
                        {
                            database.ExecuteSQL("ALTER TABLE [" + _setting.SQLSource.Catalog + "].[dbo].ImportKey ADD ParentID uniqueidentifier null");
                        }
                        catch
                        {
                        }
                        try
                        {
                            database.ExecuteSQL("ALTER TABLE [" + _setting.SQLDestination.Catalog + "].[dbo].ImportKey ADD ParentID uniqueidentifier null");
                        }
                        catch
                        {
                        }

                        try
                        {
                            database.ExecuteSQL("ALTER TABLE [" + _setting.SQLSource.Catalog + "].[dbo].ImportKey ADD CreateDate datetime null");
                        }
                        catch
                        {
                        }
                        try
                        {
                            database.ExecuteSQL("ALTER TABLE [" + _setting.SQLDestination.Catalog + "].[dbo].ImportKey ADD CreateDate datetime null");
                        }
                        catch
                        {
                        }

                        _files.Clear();

                        _files.AddRange(Directory.GetFiles(SCRIPT_PATH).CustomSort().ToArray());
                        _files.AddRange(Directory.GetFiles(SCRIPT_PATH + @"Additional\"));

                        txtInfo.Invoke((MethodInvoker)(() => progressBar.Maximum = _files.Count()));
                        lblMessage.Invoke((MethodInvoker)(() => lblMessage.Text = ""));
                        progressBar.Invoke((MethodInvoker)(() => progressBar.Value = 1));
                        int counter = 1;
                        string name = "";
                        foreach (var data in _files)
                        {
                            name = Path.GetFileName(data);
                            lblMessage.Invoke((MethodInvoker)(() => lblMessage.Text = "File " + counter + " of " + _files.Count() + " (" + name + ")"));
                            sql = File.ReadAllText(data);
                            
                            sql = sql.Replace("[other]", "[" + _setting.SQLSource.Catalog + "~]");
                            sql = sql.Replace("[Other]", "[" + _setting.SQLSource.Catalog + "~]");
                            sql = sql.Replace("[OTHER]", "[" + _setting.SQLSource.Catalog + "~]");

                            sql = sql.Replace("OTHER.", _setting.SQLSource.Catalog + "~.");
                            sql = sql.Replace("Other.", _setting.SQLSource.Catalog + "~.");
                            sql = sql.Replace("other.", _setting.SQLSource.Catalog + "~.");                            
                            

                            sql = sql.Replace("[IMS]", "[" + _setting.SQLDestination.Catalog + "]");
                            sql = sql.Replace("[ims]", "[" + _setting.SQLDestination.Catalog + "]");

                            sql = sql.Replace("IMS.", _setting.SQLDestination.Catalog + ".");
                            sql = sql.Replace("ims.", _setting.SQLDestination.Catalog + ".");

                            sql = sql.Replace("[" + _setting.SQLSource.Catalog + "~]", "[" + _setting.SQLSource.Catalog + "]");
                            sql = sql.Replace(_setting.SQLSource.Catalog + "~.", _setting.SQLSource.Catalog + ".");

                            if (name.ToLower().Contains("entities.txt") && chkExcludeAgencyAndMerge.Checked)
                            {                                
                                sql += Environment.NewLine + @" And EntityType = 'C' ";
                            }

                            var count = database.ExecuteSQL(sql);
                            txtInfo.Invoke((MethodInvoker)(() => txtInfo.AppendText(count + " rows affected    -   " + name + " completed" + Environment.NewLine)));
                            progressBar.Invoke((MethodInvoker)(() => progressBar.Increment(1)));
                            counter++;
                        }
                        database.Disconnect();
                    }
                    txtInfo.Invoke((MethodInvoker)(() => txtInfo.AppendText("Finished!")));
                }
            }
            catch (Exception ex)
            {
                ErrorLog("RunMerge", ex.ToString());

                txtInfo.Invoke((MethodInvoker)(() => txtInfo.AppendText("Errors, check scripts and rerun.")));
            }
        }        

        private void DisableEnableForm()
        {
            btnRun.Enabled = false;
            rdoSplit.Enabled = false;
            rdoMerge.Enabled = false;
            chkExcludeAgencyAndMerge.Enabled = false;
            if (_setting != null)
            {
                rdoSplit.Enabled = true;
                rdoMerge.Enabled = true;
                chkExcludeAgencyAndMerge.Enabled = true;
                if (rdoMerge.Checked)
                {
                    btnRun.Enabled = true;
                }
                else if (rdoSplit.Checked)
                {
                    var selectedProducers = chkProducers.Properties.GetCheckedItems().ToString();
                    var selectedAgencies = chkAgencies.Properties.GetCheckedItems().ToString();
                    if (!string.IsNullOrWhiteSpace(selectedAgencies) || !string.IsNullOrWhiteSpace(selectedProducers))
                    {
                        btnRun.Enabled = true;
                    }
                }
            }
        }

        private void LoadSettingsFile()
        {
            try
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
                                _setting = (Setting)s.Deserialize(xdoc.CreateReader());
                                _setting.FilePath = file.FileName;
                                if (_setting != null)
                                {
                                    txtCurrentSettingFile.Text = Path.GetFileName(_setting.FilePath);
                                }
                                else
                                {
                                    txtCurrentSettingFile.Text = "None";
                                }
                            }
                        }
                    }
                }

                if (_setting != null)
                {
                    var results = new List<ValidationResult>();
                    Validator.TryValidateObject(_setting, new ValidationContext(_setting, null, null), results);

                    if (results.Count > 0)
                    {
                        StringBuilder errorString = new StringBuilder();
                        errorString.AppendLine("The settings file you loaded has some errors:");
                        errorString.AppendLine("");
                        foreach (var r in results)
                        {
                            errorString.AppendLine(r.ErrorMessage);
                        }
                        errorString.AppendLine("");
                        errorString.AppendLine("Would you like to edit this settings file?");

                        var result = MessageBox.Show(errorString.ToString(), "Error", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            NewEditSettings();
                        }
                        else
                        {
                            _setting = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog("LoadSettingsFile", ex.ToString());
            }
        }
        private void NewEditSettings(bool isNew = false)
        {
            try
            {
                if (isNew)
                    _setting = null;

                using (SettingsForm sf = new SettingsForm("newfile", _setting))
                {
                    sf.Setting = _setting;
                    var results = sf.ShowDialog();
                    if (results == DialogResult.OK)
                    {
                        _setting = sf.Setting;
                        if (_setting != null)
                            txtCurrentSettingFile.Text = Path.GetFileName(_setting.FilePath);
                        else
                            txtCurrentSettingFile.Text = "None";
                    }
                    else if (!isNew && (results == DialogResult.Cancel && sf.HasErrors))
                    {
                        _setting = null;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog("NewEditSettings", ex.ToString());
            }
        }
        private void ErrorLog(string funcitonName, string message)
        {
            try
            {
                _eventLog.AddNewEvent(LevelEnum.Error, DateTime.Now, funcitonName, SectionEnum.None, EventTypeEnum.None, message, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Exception Occurred Adding to ErrorLog: \n\n" + ex.ToString() + "\n\n Original Message:\n\n" + message, "Error");
            }
            MessageBox.Show("An Exception Occurred in " + funcitonName + ": \n\n" + message, "Error");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoSplit_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSplit.Checked)
            {
                if (_setting != null)
                {
                    string connectionString = _setting.GenerateConnectionString(_setting.SQLSource.Catalog);
                    if (connectionString != "")
                    {
                        using (IMSDatabase database = new IMSDatabase(connectionString))
                        {
                            database.Connect();
                            var agencies = database.GetAgencies();
                            foreach (DataRow row in agencies.Rows)
                                chkAgencies.Properties.Items.Add(row[0].ToString(), row[1].ToString(), CheckState.Unchecked, true);

                            var producers = database.GetProducers();
                            foreach (DataRow row in producers.Rows)
                                chkProducers.Properties.Items.Add(row[0].ToString(), row[1].ToString(), CheckState.Unchecked, true);
                        }
                    }
                }
                chkAgencies.Enabled = true;
                chkProducers.Enabled = true;
                lblAgencies.Enabled = true;
                lblProducers.Enabled = true;
            }
            else
            {
                chkAgencies.Properties.Items.Clear();
                chkAgencies.Enabled = false;

                chkProducers.Properties.Items.Clear();
                chkProducers.Enabled = false;
                lblAgencies.Enabled = false;
                lblProducers.Enabled = false;
            }
            DisableEnableForm();
        }

        private void rdoMerge_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkAgencies_EditValueChanged(object sender, EventArgs e)
        {
            DisableEnableForm();
        }

        private void chkProducers_EditValueChanged(object sender, EventArgs e)
        {
            DisableEnableForm();
        }

        private void btnUpdateScripts_Click(object sender, EventArgs e)
        {
            GetScripts();
        }

        private void GetScripts(bool launch = false)
        {
            try
            {
                if (Directory.Exists(SCRIPT_PATH))
                {
                    if (launch)
                        return;

                    var result = MessageBox.Show("This will delete all files in the local Insert Scripts folder and pull down the current, are you sure you want to do this?", "Update Scripts", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DeleteDirectory(SCRIPT_PATH);
                    }
                    else
                    {
                        return;
                    }

                }
                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(SOURCE_SCRIPT_PATH, "*", SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(SOURCE_SCRIPT_PATH, SCRIPT_PATH));

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(SOURCE_SCRIPT_PATH, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(SOURCE_SCRIPT_PATH, SCRIPT_PATH), true);
            }
            catch (Exception ex)
            {
                ErrorLog("GetScripts", ex.ToString());
                MessageBox.Show("There was an issue with getting the scripts. Please manually copy the Insert Scripts folder/contents from " + SOURCE_SCRIPT_PATH + " into " + System.Reflection.Assembly.GetEntryAssembly().Location);

            }
        }
        private void DeleteDirectory(string source)
        {
            string[] files = Directory.GetFiles(source);
            string[] dirs = Directory.GetDirectories(source);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(source, false);
        }

        private void addAgencyUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version: " + VERSION);
        }
    }

    public static class MyExtensions
    {
        public static IEnumerable<string> CustomSort(this IEnumerable<string> list)
        {
            int maxLen = list.Select(s => s.Length).Max();

            return list.Select(s => new
            {
                OrgStr = s,
                SortStr = Regex.Replace(s, @"(\d+)|(\D+)", m => m.Value.PadLeft(maxLen, char.IsDigit(m.Value[0]) ? ' ' : '\xffff'))
            })
            .OrderBy(x => x.SortStr)
            .Select(x => x.OrgStr);
        }

    }
}
