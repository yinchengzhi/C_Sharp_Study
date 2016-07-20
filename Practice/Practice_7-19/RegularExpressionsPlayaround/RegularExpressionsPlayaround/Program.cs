using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegularExpressionsPlayaround
{
    class Program
    {
        static void WriteMatches(string text, MatchCollection matches)
        {
            Console.WriteLine("Original text was: \n\n" + text + "\n");
            Console.WriteLine("No. of matches: " + matches.Count);

            foreach(Match nextMatch in matches)
            {
                int index = nextMatch.Index;
                string result = nextMatch.ToString();
                int charsBefore = (index < 5) ? index : 5;
                int fromEnd = text.Length - index - result.Length;
                int charsAfter = (fromEnd < 5) ? fromEnd : 5;
                int charsToDisplay = charsBefore + charsAfter + result.Length;

                Console.WriteLine("Index:{0},\tString:{1},\t{2}", index, result, text.Substring(index - charsBefore, charsToDisplay));

            }
        }

        static void Find2()
        {
            string text = @"This comprehensive compendium provides a broad and through investigation of all aspects of programming"
        }

        static void Main(string[] args)
        {

        }
    }
}
