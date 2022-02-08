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
    public partial class AssCenterV : Form
    {
        public AssCenterV()
        {
            InitializeComponent();
        }

        private void AssCenterV_Load(object sender, EventArgs e)
        {
            AssCenter d = new AssCenter();
            d.SetDatabaseLogon("sa", "mterp");
            crystalReportViewer1.ReportSource = d;
            crystalReportViewer1.Refresh();
            this.Dock = DockStyle.Fill;
        }
    }
}
