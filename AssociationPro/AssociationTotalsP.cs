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
    public partial class AssociationTotalsP : Form
    {
        public AssociationTotalsP()
        {
            InitializeComponent();
        }
        public static string type;
        private void button1_Click(object sender, EventArgs e)
        {


            type = comboBox1.Text;
            AssociationTotalsV d = new AssociationTotalsV();
            d.Show();
            
        }
    }
}
