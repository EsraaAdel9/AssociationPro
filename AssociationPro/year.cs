﻿using System;
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
    public partial class year : Form
    {
        public year()
        {
            InitializeComponent();
        }

        private void year_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            c.updateYear(comboBox1.Text.Trim());
            MessageBox.Show("تم الحفظ بنجاح");
        }
    }
}
