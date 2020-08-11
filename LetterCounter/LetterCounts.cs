using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterCounter
{
    public class LetterCounts
    {
        public Dictionary<char, int> CountBreakdown { get; set; }

        public int TotalLetters { get; set; }

        public LetterCounts()
        {
            CountBreakdown = new Dictionary<char, int>();
        }
    }
}