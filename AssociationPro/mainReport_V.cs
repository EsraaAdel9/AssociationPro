using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssociationPro
{
    public partial class mainReport_V : Form
    {
        public mainReport_V()
        {
            InitializeComponent();
        }

        private void mainReport_V_Load(object sender, EventArgs e)
        {
            mainReport m = new mainReport();
            m.SetDatabaseLogon("sa", "mterp");
            m.SetParameterValue("asName", mainReport_F.asName);
            m.SetParameterValue("emp_F", mainReport_F.Femp);
            m.SetParameterValue("emp_S", mainReport_F.Semp);
            crystalReportViewer1.ReportSource = m;
            crystalReportViewer1.Refresh();
            this.Dock = DockStyle.Fill;
        }
    }
}
