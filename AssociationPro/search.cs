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
    public partial class search : Form
    {
        public search()
        {
            InitializeComponent();
        }
        DataTable dt1;
        Class1 a = new Class1();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox3.Text == "" && textBox2.Text == "")
            {
                dataGridView1.DataSource = "";
            }
            else
            {
                if (textBox3.Text == "" && textBox2.Text == "")
                {
                    dt1 = a.search(type, textBox1.Text);
                }
                else if (textBox3.Text == "" && radioButton1.Checked)
                {
                    dt1 = a.or(type, textBox1.Text, textBox2.Text);
                }
                else if (textBox3.Text == "" && radioButton2.Checked)
                {
                    dt1 = a.and(type, textBox1.Text, textBox2.Text);
                }
                else if (radioButton1.Checked && radioButton3.Checked)
                {
                    dt1 = a.oror(type, textBox1.Text, textBox2.Text, textBox3.Text);
                }
                else if (radioButton1.Checked && radioButton4.Checked)
                {
                    dt1 = a.orand(type, textBox1.Text, textBox2.Text, textBox3.Text);
                }
                else if (radioButton2.Checked && radioButton3.Checked)
                {
                    dt1 = a.andor(type, textBox1.Text, textBox2.Text, textBox3.Text);
                }
                else if (radioButton2.Checked && radioButton4.Checked)
                {
                    dt1 = a.andand(type, textBox1.Text, textBox2.Text, textBox3.Text);
                }

            }
            if (dt1.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt1;
                dataGridView1.Sort(this.dataGridView1.Columns["id"],ListSortDirection.Ascending);
            }
            else
            {
                dataGridView1.DataSource = "";
            }
        }
        string type;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0)
            {
                type = "ass_name";
            }
            else if(comboBox1.SelectedIndex==1)
            {
                type = "case_name";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                type = "village";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                type = "street";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                type = "comm_decision";
            }
        }
        public static int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button7.Visible = true;

            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد من الحذف؟", "تحذير", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                a.deleteCase(id);               
                MessageBox.Show("تم الحذف بنجاح");
                button1.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edit ed = new edit();
            ed.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            CasePrint c = new CasePrint();
            c.Show();
        }

        private void search_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            first f = new first();
            f.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            picsprint p = new picsprint();
            p.Show();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
