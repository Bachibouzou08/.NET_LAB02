using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        static void Main(string[] args)
        {
            try
            {
                Constants constants = new Constants();
                Boolean restart = true;
                while (restart == true)
                {
                    Console.WriteLine(constants.Sentences(0));
                    String option = Console.ReadLine() ?? throw new Exception(constants.Errors(0));
                    while ((option != "F") && (option != "M"))
                    {
                        Console.WriteLine(constants.Sentences(1));
                        option = Console.ReadLine();
                    }
                    switch (option.ToUpper())
                    {
                        case "F":
                            Console.WriteLine(constants.Sentences(2));
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case "M":
                            Console.WriteLine(constants.Sentences(3));
                            ExecuteScrambledWordsInManualScenario();
                            break;
                        default:
                            Console.WriteLine(constants.Sentences(4));
                            break;
                    }

                    Console.WriteLine(constants.Sentences(5));
                    string awn = Console.ReadLine();
                    while ((awn != "Y") && (awn != "N"))
                    {
                        Console.WriteLine(constants.Sentences(6));
                        awn = Console.ReadLine();
                    }
                    switch (awn)
                    {
                        case "Y":
                            restart = true;
                            break;
                        case "N":
                            restart = false;
                            System.Environment.Exit(-1);
                            break;
                        default:
                            throw new InvalidOperationException(constants.Sentences(7));
                    }
                }
            } catch (Exception ex)
            {
                Constants constants = new Constants();
                Console.WriteLine(constants.Errors(1), ex);
            }
        }

        private static void ExecuteScrambledWordsInManualScenario()
        {
            string manualInput = Console.ReadLine();
            char[] seperator = {',', ' '};
            string[] scrambledWords = manualInput.Split(seperator);
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            var filename = Console.ReadLine();
            string[] scrambledWords = _fileReader.Read(filename);
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambleWords)
        {
            Constants constants = new Constants();
            string[] wordList = _fileReader.Read("wordlist.txt");
            List<MatchedWords> matchedWords = _wordMatcher.Match(scrambleWords, wordList);
            if (matchedWords.Any())
            {
                foreach (var mWord in matchedWords)
                {
                        Console.WriteLine(constants.Sentences(8), mWord.ScrambleWord, mWord.Word);
                }
            } else
            {
                Console.WriteLine(constants.Sentences(9));
            }
        }
    }
}
