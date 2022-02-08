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
    public partial class CasePrint : Form
    {
        public CasePrint()
        {
            InitializeComponent();
        }

        private void CasePrint_Load(object sender, EventArgs e)
        {
            PrintCase p = new PrintCase();
            p.SetParameterValue("id", search.id);
            p.SetDatabaseLogon("sa", "mterp");
            crystalReportViewer1.ReportSource = p;
            crystalReportViewer1.Refresh();
            this.Dock = DockStyle.Fill;
        }
    }
}
