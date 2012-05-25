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
        private string GuessedLetters = "";


        public Form1()
        {
            InitializeComponent();
        }

        private void  InitGame()
        {
            Words.GetWord();
            for (int c = 65; c < 91; c++)
            {
                Label Letter = new Label();
                Letter.Text = ((char)c).ToString();
                Letter.Top = c < 80 ? 300 : 340;
                Letter.Left = c < 80 ? (c - 65) * 34 + 12 : (c - 80) * 44 + 23;
                Letter.Font = mtbAnswer.Font;
                Letter.AutoSize = true;
                Letter.Click += new EventHandler(Letter_Click);
                this.Controls.Add(Letter);

            }
        }

        void Letter_Click(object sender, EventArgs e)
        {
            Label ClickedLetter = sender as Label;
            MessageBox.Show(ClickedLetter.Text);
            ClickedLetter.Visible = false;
            GuessedLetters += ClickedLetter.Text;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitGame();
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (GuessedLetters.Contains(e.KeyChar.ToString().ToUpper()))
            {
                MessageBox.Show("Already guessed");
            }
            else
            {
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(Label))
                    {
                        if (c.Text.ToUpper() == e.KeyChar.ToString().ToUpper())
                        {
                            Letter_Click(c, EventArgs.Empty);
                        }
                    }
                }
            }

        }

        
    }
}
