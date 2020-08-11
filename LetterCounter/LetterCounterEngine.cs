using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterCounter
{
    public class LetterCounterEngine
    {
        public LetterCounts GetLetteCounts(string inputString)
        {
            LetterCounts result = new LetterCounts();

            //Return empty if our input is null.
            if (inputString == null)
                return result;

            //Loop through all chars in string.
            foreach (char c in inputString)
            {
                //Skip the chars that are not a letter.
                if (char.IsLetter(c) == false)
                    continue;

                //Make all chars uppcase to ignore case when comparing.
                var upperC = char.ToUpper(c);

                //If the char is already in the dictionary then add to its count.
                if (result.CountBreakdown.ContainsKey(upperC))
                {
                    result.CountBreakdown[upperC]++;
                }
                //Otherwise create an entry in the dictionary with a count of 1.
                else
                {
                    result.CountBreakdown.Add(upperC, 1);
                }

                //Tick our letter count because if we got to here we know it was a letter.
                result.TotalLetters++;
            }

            return result;
        }
    }
}