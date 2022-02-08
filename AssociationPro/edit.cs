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
    public partial class edit : Form
    {
        public edit()
        {
            InitializeComponent();
        }
        Class1 c = new Class1();
        private void edit_load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.emp' table. You can move, or remove it, as needed.
            this.empTableAdapter.Fill(this.dataSet2.emp);
            // TODO: This line of code loads data into the 'dataSet11.Def' table. You can move, or remove it, as needed.
            this.defTableAdapter.Fill(this.dataSet11.Def);
            // TODO: This line of code loads data into the 'dataSet1.Def' table. You can move, or remove it, as needed.
            comboBox9.SelectedIndex = -1;
            comboBox8.SelectedIndex = -1;
            ComboBox1.SelectedIndex = -1;
           DataTable dttt= c.GetCase(search.id);
           ComboBox1.Text = dttt.Rows[0][1].ToString().Trim();
           TextBox1.Text = dttt.Rows[0][2].ToString().Trim();
           ComboBox3.Text = dttt.Rows[0][3].ToString().Trim();
           //MessageBox.Show(dttt.Rows[0][4].ToString().Trim());
           comboBox2.Text = dttt.Rows[0][4].ToString();//.Trim();
           comboBox4.Text = dttt.Rows[0][5].ToString().Trim();
           textBox2.Text = dttt.Rows[0][6].ToString().Trim();
           textBox3.Text = dttt.Rows[0][7].ToString().Trim();
           textBox4.Text = dttt.Rows[0][8].ToString().Trim();
           comboBox5.Text = dttt.Rows[0][9].ToString().Trim();
           textBox5.Text = dttt.Rows[0][16].ToString().Trim();
           comboBox9.Text = dttt.Rows[0][10].ToString().Trim();
           comboBox8.Text = dttt.Rows[0][11].ToString().Trim();
           comboBox6.Text = dttt.Rows[0][12].ToString().Trim();
           if (dttt.Rows[0][12].ToString().Trim() == "محال الى اللجنة")
           {
               comboBox7.Visible = true;
               comboBox7.Text = dttt.Rows[0][13].ToString().Trim();

           }
           else
           {
               comboBox7.Visible = false;
           }
           if (dttt.Rows[0][13].ToString().Trim() == "مرفوضة")
           {
               comboBox10.Visible = true;
               comboBox10.Text = dttt.Rows[0][18].ToString().Trim();
           }
           try
           {
               if (bool.Parse(dttt.Rows[0][14].ToString()) == null)
               {
                   checkBox1.Checked = false;
               }

               else
               {
                   checkBox1.Checked = bool.Parse(dttt.Rows[0][14].ToString());
               }
               if (bool.Parse(dttt.Rows[0][14].ToString()) == null)
               {
                   checkBox2.Checked = false;
               }
               else
               {
                   checkBox2.Checked = bool.Parse(dttt.Rows[0][15].ToString());
               }
           }
           catch (Exception ex)
           {

           }

        }

        private void clear()
        {
            ComboBox1.SelectedIndex = -1;
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
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text.Trim() == "محال الى اللجنة")
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

                    if (z > c.waterNo(ComboBox1.Text))
                    {
                        MessageBox.Show("تم تجاوز العدد المسموح به للتوصيل بقرار اللجنة لتوصيلات المياه لهذه الجمعية");
                    }
                    else
                    {
                        y = 1;
                    }
                    //if (comboBox5.SelectedIndex == 0)
                    //{
                    //    if (c.count(ComboBox1.Text, comboBox5.Text) > c.waterNo(ComboBox1.Text))
                    //    {
                    //        MessageBox.Show("تم تجاوز العدد المسموح به للتوصيل بقرار اللجنة لتوصيلات المياه لهذه الجمعية");
                    //    }
                    //    else
                    //    {
                    //        y = 1;
                    //    }
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
                    }
                    if (y == 1)
                    {
                        c.updateCase(search.id, ComboBox1.Text, TextBox1.Text, ComboBox3.Text, comboBox2.Text, comboBox4.Text, textBox2.Text, float.Parse(textBox3.Text), int.Parse(textBox4.Text), comboBox5.Text, comboBox9.Text, comboBox8.Text, comboBox6.Text, comboBox7.Text, checkBox1.Checked, checkBox2.Checked, textBox5.Text,dateTimePicker1.Value,comboBox10.Text);

                        if (AddPics.dtt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in AddPics.dtt.Rows)
                            {
                                c.InsertCase_image(int.Parse(dr[0].ToString()), search.id, 1);
                            }
                        }
                        if (AddPics.dtt2.Rows.Count > 0)
                        {
                            foreach (DataRow dr in AddPics.dtt2.Rows)
                            {
                                c.InsertCase_image(int.Parse(dr[0].ToString()), search.id, 2);
                            }
                        }
                        
                        
                        MessageBox.Show("تم التعديل بنجاح");
                       // clear();
                        y = 0;
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
            int x = c.count2(ComboBox1.Text) * 2;
            int y = c.count(ComboBox1.Text, comboBox5.Text);
            z = x + y;
           
            label15.Text = " تم السماح بعمل عدد " + z.ToString() + " توصيلة بقرار اللجنة من اصل " + c.waterNo(ComboBox1.Text) + "توصيلة ";



        }

        private void button2_Click(object sender, EventArgs e)
        {
            type = 2;
            x = 1;
            AddPics a = new AddPics();
            a.Show();
        }
       public static int x;
       public static int type;
        private void button3_Click(object sender, EventArgs e)
        {
            type = 1;
            x = 1;
            AddPics a = new AddPics();
            a.Show();
        }

        private void edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            x = 0;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text.Trim() == "مرفوضة")
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
    }
}
