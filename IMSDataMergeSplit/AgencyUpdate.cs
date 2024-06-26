using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMSDataMergeSplit
{
    public partial class AgencyUpdate : Form
    {
        Setting _setting;
        public AgencyUpdate(Setting setting)
        {
            InitializeComponent();

            _setting = setting;
        }

        private void btnRunAgency_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAgency.Text))
            {
                string connectionString = _setting.GenerateConnectionString(_setting.SQLDestination.Catalog);

                string sql = "";

               
            }
        }
    }
}
