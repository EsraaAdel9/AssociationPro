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
    public partial class first : Form
    {
        Class1 c = new Class1();
        public first()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Def d = new Def();
            d.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add a = new Add();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            emp em = new emp();
            em.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                c.backup();
                MessageBox.Show("تم عمل نسخه احتياطية من قاعدة البيانات");
            }
            catch (Exception)
            {
                MessageBox.Show("حدث خطأ فى عمل النسخة الاحتياطية برجاء مراجعه مسئول نظم المعلومات");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            search sh = new search();
            sh.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reports r = new Reports();
            r.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            year y = new year();
            y.Show();
        }

        private void first_Load(object sender, EventArgs e)
        {
            label1.Text = c.Getyear();
        }

        private void first_Activated(object sender, EventArgs e)
        {
            label1.Text = c.Getyear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            protocol p = new protocol();
            p.Show();
        }
    }
}
