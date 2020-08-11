using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterCounter
{
    public class InputValidation
    {
        public static bool IsValidInput(string[] args, ref string errorResult)
        {
            if (args.Count() == 0)
            {
                errorResult = DisplayText.TooFewArgsFormattedError;
                return false;
            }
            else if (args.Count() > 1)
            {
                errorResult = DisplayText.TooManyArgsFormattedError;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}