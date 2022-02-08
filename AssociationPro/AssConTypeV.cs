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
    public partial class AssConTypeV : Form
    {
        public AssConTypeV()
        {
            InitializeComponent();
        }

        private void AssConTypeV_Load(object sender, EventArgs e)
        {
            AssConType d = new AssConType();
            d.SetDatabaseLogon("sa", "mterp");
            crystalReportViewer1.ReportSource = d;
            crystalReportViewer1.Refresh();
            this.Dock = DockStyle.Fill;
        }
    }
}
