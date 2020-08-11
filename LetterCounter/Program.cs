using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterCounter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string resultString = "";

            if (InputValidation.IsValidInput(args, ref resultString) == true)
            {
                LetterCounterEngine letterCounterEngine = new LetterCounterEngine();
                LetterCounts letterCounts = letterCounterEngine.GetLetteCounts(args[0]);

                DisplayText displayFormatter = new DisplayText();
                resultString = displayFormatter.GetFormattedTableString(letterCounts);
            }

            Console.Write(resultString);
        }
    }
}