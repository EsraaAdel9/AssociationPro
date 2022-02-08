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
    public partial class mainReport_F : Form
    {
        public mainReport_F()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public static string asName;
        public static string Femp;
        public static string Semp;
        private void button1_Click(object sender, EventArgs e)
        {
            asName = comboBox1.Text;
            Femp = comboBox2.Text;
            Semp = comboBox3.Text;
            mainReport_V mv = new mainReport_V();
            mv.Show();
           

        }
        Class1 c = new Class1();
        private void mainReport_F_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            foreach (DataRow dr in c.getProAssName().Rows)
            {
                comboBox1.Items.Add(dr[0].ToString());
            }


            foreach (DataRow dr in c.getemp().Rows)
            {
                comboBox2.Items.Add(dr[0].ToString());
            }

            foreach (DataRow dr in c.getemp().Rows)
            {
                comboBox3.Items.Add(dr[0].ToString());
            }


        }
    }
}
