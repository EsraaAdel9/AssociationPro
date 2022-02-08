using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Imaging;

namespace AssociationPro
{
    public partial class picsprint : Form
    {
        public picsprint()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Show print dialog
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Print image
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
        }
        Class1 c = new Class1();
        private void picsprint_Load(object sender, EventArgs e)
        {
            DataTable dt=c.selectImage_case(search.id);
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                dataGridView1.Rows.Add(dt.Rows[i][0].ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
           // button2.Enabled = false;
            int id = int.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
            Class1 c = new Class1();
            byte[] s = c.selectImage(id);

            Image img = (Bitmap)((new ImageConverter()).ConvertFrom(s));
            pictureBox1.Image = img;
            button2.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            // button2.Enabled = false;
            int id = int.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
            Class1 c = new Class1();
            byte[] s = c.selectImage(id);

            Image img = (Bitmap)((new ImageConverter()).ConvertFrom(s));
            pictureBox1.Image = img;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = @"jpg|*.jpg" })
            {

                //{ Filter = @"PNG|*.png" }
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(saveFileDialog.FileName);
                }
            }
        }

    }
}
