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
    public partial class protocol : Form
    {
        public protocol()
        {
            InitializeComponent();
        }
        Class1 c = new Class1();
        string imagepath;

        private void protocol_Load(object sender, EventArgs e)
        {
           
            ComboBox1.Items.Clear();
            foreach (DataRow dr in c.getAssNames().Rows)
            {
                ComboBox1.Items.Add(dr[0].ToString());
            }
        }
        int Pid;
        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (ComboBox1.Text == "" || textBox1.Text == ""||TextBox4.Text=="")
                {
                    MessageBox.Show("برجاء ادخال جميع البيانات");
                }
                else
                {
                   c.insertProtocal(ComboBox1.Text, dateTimePicker1.Value, int.Parse(textBox1.Text),int.Parse(TextBox4.Text), pictureBox1.Image);
                    
                    MessageBox.Show("تم الادخال بنجاح");
                }
            }
            else
            {
                if (textBox2.Text == ""||TextBox4.Text==""||ComboBox1.Text=="")
                {
                    MessageBox.Show("برجاء ادخال جميع البيانات");
                }
                else
                {
                    Pid=c.selectprotocol(ComboBox1.Text, int.Parse(textBox2.Text));
                    c.insertProtocolHistory(Pid);
                    c.updateProtocal(ComboBox1.Text, int.Parse(textBox2.Text), int.Parse(TextBox4.Text));
                  //  c.insertProtocolHistory()
                    MessageBox.Show("تم الادخال بنجاح");
                }
            }

            ComboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text="";
            TextBox4.Text="";
            pictureBox1.Image = null;
            radioButton1.Checked=true;


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dateTimePicker1.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                label3.Visible = true;
                textBox2.Visible = false;
                label4.Visible = false;
            }
            else
            {
                dateTimePicker1.Visible = false;
                label2.Visible = false;
                textBox1.Visible = false;
                label3.Visible = false;
                textBox2.Visible = true;
                label4.Visible = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButton1.Checked)
            //{
            //    dateTimePicker1.Visible = true;
            //    textBox1.Visible = true;
            //}
            //else
            //{
            //    dateTimePicker1.Visible = false;
            //    textBox1.Visible = false;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    imagepath = openFileDialog1.FileName;
                    pictureBox1.ImageLocation = openFileDialog1.FileName;
                    // extension = Path.GetExtension(imagepath);
                }
                catch (Exception)
                {
                    imagepath = openFileDialog1.FileName;
                }
                //button2.Enabled = true;
            }
        }
    }
}
