using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterCounter
{
    public class DisplayText
    {
        private const string TooFewArgsError = "Error: Missing input argument. This application requires a single argument.";
        private const string TooManyArgsError = "Error: Too many arguments. This application requires a single argument.";

        public static string TooFewArgsFormattedError
        {
            get { return Environment.NewLine + TooFewArgsError + Environment.NewLine; }
        }

        public static string TooManyArgsFormattedError
        {
            get { return Environment.NewLine + TooManyArgsError + Environment.NewLine; }
        }

        public string GetFormattedTableString(LetterCounts letterCounts)
        {
            StringBuilder stringBuilderResult = new StringBuilder();
            StringBuilder stringBuilderLine = new StringBuilder();
            StringBuilder stringBuilderValues = new StringBuilder();

            stringBuilderResult.Append(Environment.NewLine);

            //Loop through the alphabet
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                int paddingCount = 1; //Use the padding count to adjust the table column size for large numbers

                //If we have this letter in our letter breakdowns the add it to the Values string
                if (letterCounts.CountBreakdown.ContainsKey(letter))
                {
                    stringBuilderValues.Append($" {letterCounts.CountBreakdown[letter]} |");
                    paddingCount = letterCounts.CountBreakdown[letter].ToString().Length;
                }
                //Otherwise just display 0 count
                else
                    stringBuilderValues.Append(" 0 |");

                stringBuilderResult.Append($" {letter}").Append(' ', paddingCount).Append("|"); //Add each letter to the result line
                stringBuilderLine.Append("---").Append('-', paddingCount); // Add a more length to the dividing line
            }

            //Append the strings for the final display result
            stringBuilderResult.Append(Environment.NewLine);
            stringBuilderResult.Append(stringBuilderLine);
            stringBuilderResult.Append(Environment.NewLine);
            stringBuilderResult.Append(stringBuilderValues);
            stringBuilderResult.Append(Environment.NewLine);
            stringBuilderResult.Append(Environment.NewLine);
            stringBuilderResult.Append($"The text has been processed. Total letters counted: {letterCounts.TotalLetters}");
            stringBuilderResult.Append(Environment.NewLine);
            stringBuilderResult.Append(Environment.NewLine);

            return stringBuilderResult.ToString();
        }
    }
}