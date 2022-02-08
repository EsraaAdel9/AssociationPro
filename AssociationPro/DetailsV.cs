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
    public partial class DetailsV : Form
    {
        public DetailsV()
        {
            InitializeComponent();
        }

        private void DetailsV_Load(object sender, EventArgs e)
        {
            details d = new details();
            d.SetDatabaseLogon("sa", "mterp");
            d.SetParameterValue("AssName", DetailsP.AssName);
            crystalReportViewer1.ReportSource = d;
            crystalReportViewer1.Refresh();
            this.Dock = DockStyle.Fill;
        }
    }
}
