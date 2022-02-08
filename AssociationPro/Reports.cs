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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AssCenterF acv = new AssCenterF();
            acv.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AssConTypeV astv = new AssConTypeV();
            astv.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AssociationTotalsP ap = new AssociationTotalsP();
            ap.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DetailsP dv = new DetailsP();
            dv.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mainReport_F f = new mainReport_F();
            f.Show();
        }
    }
}
