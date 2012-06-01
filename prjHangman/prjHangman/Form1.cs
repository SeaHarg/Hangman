using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace prjHangman
{
    public partial class Form1 : Form
    {
        private dictionary Words = new dictionary();
        private string GuessedLetters = "";
        private string WordMask = "";
        private int WrongGuesses = 0;
        private bool Initialized = false;
        private int Points = 0;
        StreamReader SR;
        StreamWriter SW;
        int streak = 0;

        private void ReadingStreak()
        {
            SR = new StreamReader("Streak.txt", false);
            while (SR.Peek() != -1)
            {
                streak = Convert.ToInt16(SR.ReadLine());
            }
            SR.Close();
        }

        private void WritingSreak()
        {
            SW = new StreamWriter("Streak.txt");
            if (streak > Points)
                SW.WriteLine(streak);
            else
                SW.WriteLine(Points);
            SW.Close();
        }

        private void ResetGame(bool Win)
        {
            #region ResetGame
            /*Displays the word in the maskeed textbox
             * the long line of code is an if statement. if win is true then the message box displays you win.
             * if it is set to lose then it displays you lose. it always asks if you want to play again in a new line
             * it then re displays all the letter lables.
             * reassigns all the varibles to the defult position
             * if they dont want to play again it exits the program.
             * control finds all the lables on the form and makes them visible
             */
            mtbAnswer.Mask = Regex.Replace(Words.CurrentWord, "[A-Za-z]", "A");
            mtbAnswer.Text = Words.CurrentWord.ToUpper();

            WritingSreak();

            if (Win == true)
                Points++;
            else
                Points = 0;

            if (MessageBox.Show((Win ? "You Win" : "You Lose!") + Environment.NewLine + "Would you like to play again?", "Game Over", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                WritingSreak();
                Application.Exit();
            }
            #endregion
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void InitGame()
        {
            Words.GetWord();
            ReadingStreak();
            WritingSreak();
            #region LetterLableCreation
            /*has an if statement to decided if it needs to intialize the lables or not
             * creates a for loop that is 26 iterations long
             * the loop only goes through while c is inbetween the ascii values of letters A-Z
             * it creates a new lable named lable 
             * assigns the text to the ascii value of c 
             * assgins the position then creates a lbel click event 
             * lastly creates the lable and makes the if statement false
             */
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
            #region InstructionsLabel
            /* this creates the instructions lable.
             * it assigns the text to it, positon on the form, and creates the mouse hover event.
             */
            Label Instructions = new Label();
            Instructions.Text = "Instructions";
            Instructions.Top = 100;
            Instructions.Left = 352;
            Instructions.Font = mtbAnswer.Font;
            Instructions.AutoSize = true;
            Instructions.MouseHover += new EventHandler(Instructions_MouseHover);
            this.Controls.Add(Instructions);
            #endregion
            #region ScoreLabel
            /* gives the streaks lable and points lable font size and location
             */
            lblScore.Top = 150;
            lblScore.Left = 350;
            lblScore.Font = mtbAnswer.Font;
            lblScore.AutoSize = true;

            lblPoints.Top = 150;
            lblPoints.Text = Convert.ToString(Points);
            lblPoints.Left = 455;
            lblPoints.Font = mtbAnswer.Font;
            lblPoints.AutoSize = true;

            lblHigh.Top = 200;
            lblHigh.Left = 350;
            lblHigh.Font = mtbAnswer.Font;
            lblHigh.Text = "Highest" + Environment.NewLine + "Streak:";
            lblHigh.AutoSize = true;

            lblHighValue.Top = 240;
            lblHighValue.Text = Convert.ToString(streak);
            lblHighValue.Left = 455;
            lblHighValue.Font = mtbAnswer.Font;
            lblHighValue.AutoSize = true;

            #endregion
            #region MaskExplanationAndInitalization
            /*wordmask is a varible that holds the the hidden word.
             * used a regular expression becuase its faster than useing a loop and uses less code.
             * and draws the first picture
             */
            WordMask = Regex.Replace(Words.CurrentWord, "[A-Za-z]", "A");
            mtbAnswer.Mask = WordMask;
            picDrawing.Image = imageList1.Images[0];
            #endregion
        }

        void Instructions_MouseHover(object sender, EventArgs e)
        {
            /*this displays a messagebox when you hover over the instructions lable
             */
            MessageBox.Show("How to play:" + Environment.NewLine + Environment.NewLine + "You can ether click on the letter to enter" + Environment.NewLine + "that letter in as your guess. Or you can" + Environment.NewLine + "type the letter on your keyboard. If you" + Environment.NewLine + "think you can guess the full word, then" + Environment.NewLine + "click anywhere on the form and type in the" + Environment.NewLine + "remaning letters and click submit.", "Instructions");
        }

        void Letter_Click(object sender, EventArgs e)
        {
            #region Indexing
            /* assigns the text value of the clicked lable to the varible clickedletter
             * turns that lable to invisible
             * assigns clickedletter.text to the varible guessedletter
             * creates a while loop to check to see if the clicked letter is in the word
             */
            Label ClickedLetter = sender as Label;
            ClickedLetter.Visible = false;
            GuessedLetters += ClickedLetter.Text;
            int i = 0;//index spot
            int s = 0;//the number of slashes before the insertion point
            int j = -1;//index of the slashed character in the mask
            while (Words.CurrentWord.ToUpper().IndexOf(ClickedLetter.Text, (i)) > -1)
            {
                i = Words.CurrentWord.ToUpper().IndexOf(ClickedLetter.Text, (i));
                while ((j = WordMask.IndexOf('\\', j + 1)) > -1 && j <= (i + s))//(i+s) = index spot 
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
            #endregion
            mtbAnswer.Mask = WordMask;
            #region PictureChanging
            /* if the letter is not in the word then it has to show the next picture
             * to get the picture in the picture box it has to look for the next picture in the imagsList
             * it increases the wrong guesses and uses it as the index of the imagelist for the picture
             * if wrong guesses is equal to 6 (the last guess) then it calls the reset function with the peramitor of false
             * the false peramitor makes the losing message box display "you lose" 
             */
            if (i == 0)
            {
                picDrawing.Image = imageList1.Images[++WrongGuesses];

                if (WrongGuesses == 6)
                {
                    ResetGame(false);
                }
            }
            #endregion
            #region CorrectAnswer
            /*if the answer in the masked textbox = the current word then you win
             */
            if (mtbAnswer.Text.ToUpper() == Words.CurrentWord.ToUpper())
            {
                ResetGame(true);

            }
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitGame();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            #region Focusing
            /*allows for typing and submiting depending on if the  the formed is clicked. its always equal to what its not
             this.foucus re focuses the form so that you can type letters in and have them be your letter guesses
             */
            mtbAnswer.Enabled = !mtbAnswer.Enabled;
            btnSubmit.Visible = !btnSubmit.Visible;
            mtbAnswer.Text = "";
            this.Focus();
            #endregion
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region keypressing
            /*if guessedletters contains the text value of the key getting pressed it shows a messagebox stating its already been pressed
             * else it goes through the controls on the form to acces the label that represents the key
             * once this label is found it sends the game over to the label click event
             */
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
            #endregion

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //once the submit button is pressed it calls the reset game with the peraimtor true or false depending if the text in the masked textbox is equal to the word.
            ResetGame(mtbAnswer.Text.ToUpper() == Words.CurrentWord.ToUpper());
        }

        private void picDrawing_Click(object sender, EventArgs e)
        {
            //does the exact same as clicking the form
            mtbAnswer.Enabled = !mtbAnswer.Enabled;
            btnSubmit.Visible = !btnSubmit.Visible;
            mtbAnswer.Text = "";
            this.Focus();
        }


    }
}