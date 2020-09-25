using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Constants
    {
        public string Sentences(int id)
        {
            string[] sentences = {
                    "Enter scrambled word(s) manually or as a file: F- file / M - manual",
                    "Awnser entered not recognized, try again (F or M)",
                    "Enter the full path inclding the file name",
                    "Enter the word(s) manually (seperated by commas if multiple)",
                    "The entered option was not recognized",
                    "Do you which to continue: Y or N?",
                    "Awnser entered not recognized, try again (Y or N)",
                    "System has not recognized case for trying again",
                    "{0} matched with {1}",
                    "No matches found in the list"
            };
            string sentence = sentences[id];
            return sentence;
        }
        public string Errors(int id)
        {
            string[] sentences = {
                    "String is empty/null",
                    "There was a problem encountered (Exceptions) {0}",
                    "There was a problem encountered (FILE READER){0}"
            };
            string sentence = sentences[id];
            return sentence;
        }
    }
}
