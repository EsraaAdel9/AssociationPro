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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }
        Class1 c = new Class1();
        private void Add_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.emp' table. You can move, or remove it, as needed.
            this.empTableAdapter.Fill(this.dataSet2.emp);
            // TODO: This line of code loads data into the 'dataSet11.Def' table. You can move, or remove it, as needed.
            this.defTableAdapter.Fill(this.dataSet11.Def);
            // TODO: This line of code loads data into the 'dataSet1.Def' table. You can move, or remove it, as needed.
            comboBox9.SelectedIndex = -1;
            comboBox8.SelectedIndex = -1;
            ComboBox1.Items.Clear();


            foreach(DataRow dr in c.getProAssName().Rows)
            {
                ComboBox1.Items.Add(dr[0].ToString());
            }


        }

        private void clear()
        {
            comboBox2.SelectedIndex = -1;
            ComboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            comboBox7.SelectedIndex = -1;
            comboBox8.SelectedIndex = -1;
            comboBox9.SelectedIndex = -1;
            TextBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            label15.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            textBox5.Text = "";
            button3.Visible = false;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == 2)
            {
                label11.Visible = true;
                comboBox7.Visible = true;
                button3.Visible = true;

                //if (comboBox5.SelectedIndex== 0)
                //{

                //    label15.Text = " تم السماح بعمل عدد " + c.count(ComboBox1.Text,comboBox5.Text).ToString() + " توصيلة بقرار اللجنة من اصل " + c.waterNo(ComboBox1.Text) + "توصيلة مياه";
                //}
                //else if (comboBox5.SelectedIndex == 1)
                //{

                //    label15.Text = " تم السماح بعمل عدد "+c.count(ComboBox1.Text,comboBox5.Text).ToString()+" توصيلة بقرار اللجنة من اصل "+c.sewerNo(ComboBox1.Text)+"توصيلة صرف";
                //}
                //else
                //{
                //    label15.Text = " تم السماح بعمل عدد " + c.count(ComboBox1.Text, "مياه").ToString() + " توصيلة بقرار اللجنة من اصل " + c.waterNo(ComboBox1.Text) + "توصيلة مياه\r\nكما تم السماح بعمل عدد" + c.count(ComboBox1.Text, "صرف").ToString() + " توصيلة بقرار اللجنة من اصل " + c.sewerNo(ComboBox1.Text) + "توصيلة صرف";
                //}
            }
            else
            {
                label11.Visible = false;
                comboBox7.Visible = false;
                comboBox7.SelectedIndex = -1;
               
            }
        }
        int y=0;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (ComboBox1.Text == "" || TextBox1.Text == "" || comboBox2.Text == "" || ComboBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox9.Text == "" || comboBox6.Text == ""||textBox5.Text=="")
            {
                MessageBox.Show("برجاء ادخال جميع البيانات");
            }
            else
            {
                if (comboBox6.SelectedIndex == 2 && comboBox7.Text == "")
                {
                    MessageBox.Show("برجاء ادخال قرار اللجنة");
                }
                else
                {
                    if (comboBox6.SelectedIndex == 1 && comboBox10.Text == "")
                    {
                        MessageBox.Show("برجاء ادخال سبب رفض اللجنة");
                    }
                    else
                    { 
                    //if (comboBox5.SelectedIndex == 0)
                    //{
                        if (z > c.waterNo(ComboBox1.Text))
                        {
                            MessageBox.Show("تم تجاوز العدد المسموح به للتوصيل بقرار اللجنة لتوصيلات المياه لهذه الجمعية");
                        }
                        else
                        {
                            y = 1;
                        }
                        //}
                        //else if (comboBox5.SelectedIndex == 1)
                        //{
                        //    if (c.count(ComboBox1.Text, comboBox5.Text) > c.sewerNo(ComboBox1.Text))
                        //    {
                        //        MessageBox.Show("تم تجاوز العدد المسموح به للتوصيل بقرار اللجنة لتوصيلات الصرف لهذه الجمعية");
                        //    }
                        //    else
                        //    {
                        //        y = 1;
                        //    }
                        //}
                        //else
                        //{
                        //    if (c.count(ComboBox1.Text, comboBox5.Text) > c.sewerNo(ComboBox1.Text) || c.count(ComboBox1.Text, comboBox5.Text) > c.waterNo(ComboBox1.Text))
                        //    {
                        //        MessageBox.Show("تم تجاوز العدد المسموح به للتوصيل بقرار اللجنة للتوصيلات فى المياه او الصرف  لهذه الجمعية");
                        //    }
                        //    else
                        //    {
                        //        y = 1;
                        //    }
                        //}
                        if (y == 1)
                        {
                            if (c.CheckCaseID(txt_id.Text) == 0)
                            {
                                int id = c.InsertCase(ComboBox1.Text, TextBox1.Text, ComboBox3.Text, comboBox2.Text, comboBox4.Text, textBox2.Text, float.Parse(textBox3.Text), int.Parse(textBox4.Text), comboBox5.Text, comboBox9.Text, comboBox8.Text, comboBox6.Text, comboBox7.Text, checkBox1.Checked, checkBox2.Checked, textBox5.Text, dateTimePicker1.Value, comboBox10.Text);
                                if (AddPics.dtt.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in AddPics.dtt.Rows)
                                    {
                                        c.InsertCase_image(int.Parse(dr[0].ToString()), id, 1);
                                    }
                                }
                                if (AddPics.dtt2.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in AddPics.dtt2.Rows)
                                    {
                                        c.InsertCase_image(int.Parse(dr[0].ToString()), id, 2);
                                    }
                                }
                                MessageBox.Show("تم الادخال بنجاح");
                                clear();
                                y = 0;
                            }
                            else MessageBox.Show("الرقم القومي مسجل من قبل");
                        }
                    }
                }
            }

        }
        DataTable dt;
        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            dt=c.sections(ComboBox3.Text);
            foreach(DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr[0].ToString());

            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            dt = c.village(comboBox2.Text);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox4.Items.Add(dr[0].ToString());

            }
            
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(comboBox6.SelectedIndex==2)
            //{
            //    if (comboBox5.SelectedIndex == 0)
            //    {

            //        label15.Text = " تم السماح بعمل عدد " + c.count(ComboBox1.Text, comboBox5.Text).ToString() + " توصيلة بقرار اللجنة من اصل " + c.waterNo(ComboBox1.Text) + "توصيلة مياه";
            //    }
            //    else if (comboBox5.SelectedIndex == 1)
            //    {

            //        label15.Text = " تم السماح بعمل عدد " + c.count(ComboBox1.Text, comboBox5.Text).ToString() + " توصيلة بقرار اللجنة من اصل " + c.sewerNo(ComboBox1.Text) + "توصيلة صرف";
            //    }
            //    else
            //    {
            //        label15.Text = " تم السماح بعمل عدد " + c.count(ComboBox1.Text, "مياه").ToString() + " توصيلة بقرار اللجنة من اصل " + c.waterNo(ComboBox1.Text) + "توصيلة مياه\r\nكما تم السماح بعمل عدد" + c.count(ComboBox1.Text, "صرف").ToString() + " توصيلة بقرار اللجنة من اصل " + c.sewerNo(ComboBox1.Text) + "توصيلة صرف";
            //    }
            //}
        }
        int z;
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
           int x = c.count2(ComboBox1.Text)*2 ;
           int y= c.count(ComboBox1.Text, comboBox5.Text);
            z = x + y;
           //MessageBox.Show(y.ToString());
           //MessageBox.Show(x.ToString());
           label15.Text = " تم السماح بعمل عدد " + z.ToString() + " توصيلة بقرار اللجنة من اصل " + c.waterNo(ComboBox1.Text) + "توصيلة ";








            //if (comboBox6.SelectedIndex == 2)
            //{
            //    if (comboBox5.SelectedIndex == 0)
            //    {
            //       // MessageBox.Show(c.count(ComboBox1.Text, comboBox5.Text).ToString());
            //        label15.Text = " تم السماح بعمل عدد " + c.count(ComboBox1.Text, comboBox5.Text).ToString() + " توصيلة بقرار اللجنة من اصل " + c.waterNo(ComboBox1.Text) + "توصيلة مياه";
            //    }
            //    else if (comboBox5.SelectedIndex == 1)
            //    {

            //        label15.Text = " تم السماح بعمل عدد " + c.count(ComboBox1.Text, comboBox5.Text).ToString() + " توصيلة بقرار اللجنة من اصل " + c.sewerNo(ComboBox1.Text) + "توصيلة صرف";
            //    }
            //    else
            //    {
            //        label15.Text = " تم السماح بعمل عدد " + c.count(ComboBox1.Text, "مياه").ToString() + " توصيلة بقرار اللجنة من اصل " + c.waterNo(ComboBox1.Text) + "توصيلة مياه\r\nكما تم السماح بعمل عدد" + c.count(ComboBox1.Text, "صرف").ToString() + " توصيلة بقرار اللجنة من اصل " + c.sewerNo(ComboBox1.Text) + "توصيلة صرف";
            //    }
            //}
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedIndex == 1)
            {
                label19.Visible = true;
                comboBox10.Visible = true;
                button2.Visible = true;
            }
            else
            {
                label19.Visible = false;
                comboBox10.Visible = false;
                button2.Visible = false;
            }
        }
        public static  int type;
       
        private void button3_Click(object sender, EventArgs e)
        {
            type = 1;
            AddPics ap = new AddPics();
            ap.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            type = 2;
            AddPics ap = new AddPics();
            ap.Show();
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
