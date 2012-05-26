﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace prjHangman
{
    public partial class Form1 : Form
    {
        private dictionary Words = new dictionary();
        private string GuessedLetters = "";
        private string WordMask = "";
        private int WrongGuesses = 0;
        private bool Initialized = false;

        private void ResetGame(bool Win)
        {
            mtbAnswer.Mask = Regex.Replace(Words.CurrentWord, "[A-Za-z]", "A");
            mtbAnswer.Text = Words.CurrentWord.ToUpper();
            if (MessageBox.Show((Win ? "You Win!" : "You Lose!") + Environment.NewLine + "Would you like to play again?", "Game Over", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(Label))
                    {
                        c.Visible = true;
                    }
                }
                GuessedLetters = "";
                mtbAnswer.Text = "";
                InitGame();
                WrongGuesses = 0;
            }
            else
            {
                Application.Exit();
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void  InitGame()
        {
            Words.GetWord();
            #region LetterLableCreation
            if (!Initialized)
            {
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
                Initialized = true;
            }
            #endregion

            Label Instructions = new Label();
            Instructions.Text = "Instructions";
            Instructions.Top = 100;
            Instructions.Left = 352;
            Instructions.Font = mtbAnswer.Font;
            Instructions.AutoSize = true;
            Instructions.MouseHover += new EventHandler(Instructions_MouseHover);
            this.Controls.Add(Instructions);

            WordMask = Regex.Replace(Words.CurrentWord, "[A-Za-z]", "A");
            mtbAnswer.Mask = WordMask;
            picDrawing.Image = imageList1.Images[0];
        }
        void Instructions_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("How to play:" + Environment.NewLine + Environment.NewLine + "You can ether click on the letter to enter" + Environment.NewLine + "that letter in as your guess. Or you can" + Environment.NewLine + "type the letter on your keyboard. If you" + Environment.NewLine + "think you can guess the full word, then" + Environment.NewLine + "click anywhere on the form and type in the" + Environment.NewLine + "remaning letters and click submit.", "Instructions");
        }

        void Letter_Click(object sender, EventArgs e)
        {
            Label ClickedLetter = sender as Label;
            ClickedLetter.Visible = false;
            GuessedLetters += ClickedLetter.Text;
            int i = 0;
            int s = 0;
            int j = -1;
            while (Words.CurrentWord.ToUpper().IndexOf(ClickedLetter.Text, (i)) > -1)
            {
                i = Words.CurrentWord.ToUpper().IndexOf(ClickedLetter.Text, (i));
                while ( (j=WordMask.IndexOf('\\',j+1)) > -1 && j <=(i+s))
                {
                    s++;
                }
                WordMask = WordMask.Remove((i + s), 1).Insert((i + s), '\\' + ClickedLetter.Text);
                s = 0;
                i += 1;
                j = -1;
                if (i == mtbAnswer.TextLength)
                    break;
            }
            mtbAnswer.Mask = WordMask;

            if (i == 0)
            {
                picDrawing.Image=imageList1.Images[++WrongGuesses];

                if (WrongGuesses == 6)
                {
                    ResetGame(false);
                }
            }

            if (mtbAnswer.Text.ToUpper() == Words.CurrentWord.ToUpper())
            {
                ResetGame(true);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitGame();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            mtbAnswer.Enabled = !mtbAnswer.Enabled;
            btnSubmit.Visible = !btnSubmit.Visible;
            mtbAnswer.Text = "";
            this.Focus();
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ResetGame(mtbAnswer.Text.ToUpper() == Words.CurrentWord.ToUpper());
        }

        private void picDrawing_Click(object sender, EventArgs e)
        {
            mtbAnswer.Enabled = !mtbAnswer.Enabled;
            btnSubmit.Visible = !btnSubmit.Visible;
            mtbAnswer.Text = "";
            this.Focus();
        }

        
    }
}
