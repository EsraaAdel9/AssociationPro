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
    public partial class DetailsP : Form
    {
        public DetailsP()
        {
            InitializeComponent();
        }

        private void DetailsP_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Def' table. You can move, or remove it, as needed.
            this.defTableAdapter.Fill(this.dataSet1.Def);

        }
        public static string AssName;
        private void button1_Click(object sender, EventArgs e)
        {
            AssName = comboBox1.Text;
            DetailsV d = new DetailsV();
            d.Show();
            
        }
    }
}
