using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prjHangman
{
    public partial class Form1 : Form
    {
        private dictionary Words = new dictionary();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Words.GetWord();
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
