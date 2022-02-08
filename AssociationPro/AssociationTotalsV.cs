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
    public partial class AssociationTotalsV : Form
    {
        public AssociationTotalsV()
        {
            InitializeComponent();
        }

        private void AssociationTotalsV_Load(object sender, EventArgs e)
        {
            AssociationTotals d = new AssociationTotals();
            d.SetDatabaseLogon("sa", "mterp");
            d.SetParameterValue("type", AssociationTotalsP.type);
            crystalReportViewer1.ReportSource = d;
            crystalReportViewer1.Refresh();
            this.Dock = DockStyle.Fill;
        }
    }
}
