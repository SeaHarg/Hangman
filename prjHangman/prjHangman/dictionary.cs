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
            WordBank.Add("Computer");
            WordBank.Add("Keyboard");
            WordBank.Add("Mouse");
            WordBank.Add("Compiler");
            WordBank.Add("Linker");
            WordBank.Add("Embedded");
            WordBank.Add("Visual Studio");
            WordBank.Add("Architecture");
            WordBank.Add("Design");
            WordBank.Add("Debug");
            WordBank.Add("Argument");
            WordBank.Add("Parameter");
            WordBank.Add("Test");
            WordBank.Add("Database");
            WordBank.Add("Refactor");
            WordBank.Add("List");
            WordBank.Add("Constructor");
            WordBank.Add("Semi-colon");
            WordBank.Add("git");
            WordBank.Add("GitHub");
            WordBank.Add("Literal");
            WordBank.Add("Project");
            WordBank.Add("Solution");
            WordBank.Add("Commit");
            WordBank.Add("Fetch");
            WordBank.Add("Pull");
            WordBank.Add("Boolean");
            WordBank.Add("Binary");
            WordBank.Add("Command Line");
            WordBank.Add("Operator");
            WordBank.Add("Function");
            WordBank.Add("Method");
            WordBank.Add("Assignment");
            WordBank.Add("References");
            WordBank.Add("Properties");
            WordBank.Add("Program");
            WordBank.Add("Emulator");
            WordBank.Add("Configuration");
            WordBank.Add("Compile");
            WordBank.Add("Process");
            WordBank.Add("Thread");
            WordBank.Add("Processor");
            WordBank.Add("Repository");
            WordBank.Add("Branch");
            WordBank.Add("Fork");
            WordBank.Add("Merge");
            WordBank.Add("Remote");
            WordBank.Add("User");
            WordBank.Add("Interface");
            WordBank.Add("Private");
            WordBank.Add("Public");
            WordBank.Add("Clipboard");
            WordBank.Add("Patch");
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
