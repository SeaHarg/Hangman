using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjHangman
{
    class dictionary
    {
        #region Varibles
        /*WordBank stores a string arry as type list that holds the words.
         *CurrentWord is the active word.
         */
        private List<string> WordBank = new List<string> ();
        public string CurrentWord { get; private set; }
        #endregion
        #region Initializer
        /*Where we assign the words to our word bank.
         */
        public dictionary()
        {
            WordBank.Add("Sean");
            WordBank.Add("Garry");
            WordBank.Add("bob");
        }
        #endregion
        #region Functions
        /*
         * grabs a random word from the word bank and assings it to the active word
         */
        public void  GetWord()
        {
            Random r = new Random();
            CurrentWord = WordBank[r.Next(0,WordBank.Count)];

        }
        #endregion
    }
}
