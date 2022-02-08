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
    public partial class emp : Form
    {
        public emp()
        {
            InitializeComponent();
        }
        Class1 c = new Class1();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("برجاء ادخال اسم الموظف");
            }
            else
            {
                c.Insertemp(textBox1.Text);
                MessageBox.Show("تم الادخال بنجاح");
            }
        }
    }
}
