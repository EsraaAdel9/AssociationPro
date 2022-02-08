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
    public partial class AddPics : Form
    {
        public AddPics()
        {
            InitializeComponent();
        }
        string imagepath;
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
                button2.Enabled = true;
            }
           
        }
        public static DataTable dtt=new DataTable();
        public static DataTable dtt2 = new DataTable();
        
        int counter = 1;
        private void button2_Click(object sender, EventArgs e)
        {
           
           
            if (Add.type == 1 || edit.type == 1)
            {
                if (dtt.Columns.Count == 0)
                {
                    dtt.Columns.Add("imageid", typeof(string));
                }
                else
                {

                }
                int id;
                Class1 a = new Class1();
                id = a.insertImage(pictureBox1.Image, textBox1.Text);
                DataRow dr = dtt.NewRow();
                dtt.Rows.Add(dr);
               dr[0]= id.ToString();
                dataGridView1.Rows.Add(id.ToString());
                counter++;
            }
            if (Add.type == 2||edit.type == 2)
            {
                if (dtt2.Columns.Count == 0)
                {
                    dtt2.Columns.Add("imageid", typeof(string));
                }
                else
                {

                }
                int id;
                Class1 a = new Class1();
                id = a.insertImage(pictureBox1.Image, textBox1.Text);
                DataRow dr = dtt2.NewRow();
                dtt2.Rows.Add(dr);
                dr[0] = id.ToString();
                dataGridView1.Rows.Add(id.ToString());
                counter++;
            }
         
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // string imagetype;
            var senderGrid = (DataGridView)sender;
            button2.Enabled = false;
            int id = int.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
            Class1 c = new Class1();
            byte[] s = c.selectImage(id);

            Image img = (Bitmap)((new ImageConverter()).ConvertFrom(s));
            pictureBox1.Image = img; 
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            button2.Enabled = false;
            int id = int.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
            
            byte[] s = c.selectImage(id);

            Image img = (Bitmap)((new ImageConverter()).ConvertFrom(s));
            pictureBox1.Image = img; 
        }
        Class1 c = new Class1();
        private void AddPics_Load(object sender, EventArgs e)
        {
            if (edit.x == 1)
            {
                dataGridView1.Columns.Add("imageid", "imageid");
                DataTable dt;
                if (edit.type == 1)
                {
                     dt = c.selectImage_case2(search.id, 1);
                   
                }
                else
                {
                     dt = c.selectImage_case2(search.id, 2);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(dt.Rows[i][0].ToString());
                }
               
            }
            else
            {

                dataGridView1.Columns.Add("imageid", "imageid");
                if (Add.type == 1)
                {
                    if (dtt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtt.Rows)
                        {
                            dataGridView1.Rows.Add(dr[0].ToString());
                            //dataGridView1.DataSource = dtt2;
                        }
                    }
                    else
                    {
                        dtt = new DataTable();
                        dtt.Columns.Add("imageid", typeof(string));
                        // dataGridView1.Columns.Add("imageid", "imageid");
                    }
                }
                if (Add.type == 2)
                {
                    if (dtt2.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtt2.Rows)
                        {
                            dataGridView1.Rows.Add(dr[0].ToString());
                            //dataGridView1.DataSource = dtt2;
                        }
                    }
                    else
                    {
                        dtt2 = new DataTable();
                        dtt2.Columns.Add("imageid", typeof(string));

                    }
                }
            }
        }

        private void AddPics_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView1.DataSource = "";
        }
        
    }
}
