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
    public partial class Def : Form
    {
        public Def()
        {
            InitializeComponent();
        }
        Class1 c = new Class1();
        DataTable dt;

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox3.Items.Clear();
            dt = c.centers(ComboBox2.Text.Trim());
            foreach (DataRow dr in dt.Rows)
            {
                ComboBox3.Items.Add(dr[0]);
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || textBox1.Text=="")
            {
                MessageBox.Show("يجب ادخال جميع البيانات");
            }
            else
            {
                c.InsertAssociaton(comboBox4.Text, ComboBox1.Text, ComboBox2.Text, ComboBox3.Text, TextBox2.Text, TextBox3.Text, textBox1.Text,textBox5.Text);
                MessageBox.Show("تم الادخال بنجاح");
                comboBox4.Text = "";
                comboBox4.Items.Clear();
                DataTable dt1 = new DataTable();
                dt1 = c.getAssNames();
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox4.Items.Add(dr[0].ToString());
                }
                comboBox4.SelectedIndex = -1;
            }
           
        }

        private void Def_Load(object sender, EventArgs e)
        {
           
            ComboBox1.SelectedIndex = 1;
            ComboBox2.SelectedIndex = 11;
            ComboBox3.SelectedIndex = 1;

            DataTable dt1 = new DataTable();
            dt1 = c.getAssNames();
            foreach (DataRow dr in dt1.Rows)
            {
                comboBox4.Items.Add(dr[0].ToString());
            }
            comboBox4.SelectedIndex = -1;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
       //     comboBox4.Items.Clear();
            DataTable dt = c.getAssData(comboBox4.Text);
            ComboBox1.Text = dt.Rows[0][2].ToString();
            ComboBox2.Text = dt.Rows[0][3].ToString();
            ComboBox3.Text = dt.Rows[0][4].ToString();
            textBox1.Text = dt.Rows[0][8].ToString();
            textBox5.Text = dt.Rows[0][9].ToString();
            TextBox2.Text = dt.Rows[0][5].ToString();
            TextBox3.Text = dt.Rows[0][6].ToString();
           
            if (dt.Rows.Count > 0)
            {
                button2.Visible = true;
                button3.Visible = true;
                Button1.Visible = false;
            }
            else
            {
                button2.Visible = false;
                Button1.Visible = true;
                button3.Visible = false;
            }
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            //if (comboBox4.Text == "")
            //{
                button2.Visible = false;
                clear();
                try
                {
                    comboBox4_SelectedIndexChanged(sender, e);
                }
                catch (Exception)
                {
                }
            //}
        }

        private void clear()
        {
           // comboBox4.Items.Clear();
            ComboBox1.SelectedIndex = -1;
            ComboBox2.SelectedIndex = -1;
            ComboBox3.SelectedIndex = -1;
            TextBox2.Text = "";
            TextBox3.Text = "";
           
            textBox1.Text = "";
            textBox5.Text = "";  

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "")
            {
                MessageBox.Show("برجاء اختيار الجمعية اولاً");
            }
            else
            {
                try
                {
                    if (MessageBox.Show("هل تريد حذف الجمعية؟", "تحذير", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        c.deleteAss(comboBox4.Text);
                        MessageBox.Show("تم الحذف بنجاح");
                        comboBox4.Items.Clear();
                        comboBox4.Text = "";

                        DataTable dt1 = new DataTable();
                        dt1 = c.getAssNames();
                        foreach (DataRow dr in dt1.Rows)
                        {
                            comboBox4.Items.Add(dr[0].ToString());
                        }
                        comboBox4.SelectedIndex = -1;
                      //  comboBox4_SelectedIndexChanged(sender, e);
                    }
                   
                }
                catch(Exception)
                {
                    MessageBox.Show("هذه الجمعيه غير موجودة");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("يجب ادخال جميع البيانات");
            }
            else
            {
                c.updateAss(comboBox4.Text, ComboBox1.Text, ComboBox2.Text, ComboBox3.Text, TextBox2.Text, TextBox3.Text,textBox1.Text, textBox5.Text);
                MessageBox.Show("تم التعديل بنجاح");
                comboBox4.Text = "";
                comboBox4.Items.Clear();
                DataTable dt1 = new DataTable();
                dt1 = c.getAssNames();
                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox4.Items.Add(dr[0].ToString());
                }
                comboBox4.SelectedIndex = -1;
                button3.Visible = false;
                Button1.Visible = true;
            }
           
        }
    }
}
