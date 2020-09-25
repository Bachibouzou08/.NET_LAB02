using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace WordUnscrambler
{
    class WordMatcher
    {
        public List<MatchedWords> Match(string[] scrambleWords, string[] wordList)
        {
            List<MatchedWords> matchedWords = new List<MatchedWords>();
            foreach (var scrambledWord in scrambleWords)
            {
                foreach (var word in wordList)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWords(scrambledWord, word));
                    }
                    else
                    {
                        char[] scrambledWordArray = scrambledWord.ToCharArray();
                        Array.Sort<Char>(scrambledWordArray);
                        string CharSorted = new string(scrambledWordArray);
                        char[] wordListArray = word.ToCharArray();
                        Array.Sort<Char>(wordListArray);
                        string WordSorted = new string(wordListArray);
                        if (CharSorted.Equals(WordSorted, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWords(scrambledWord, word));
                        }
                    }
                }
            }
            return matchedWords;
        }
        MatchedWords BuildMatchedWords(string scrambleWord, string word)
        {
            MatchedWords matchedWord = new MatchedWords
            {
                ScrambleWord = scrambleWord,
                Word = word
            };
            return matchedWord;
        }
    }
}
