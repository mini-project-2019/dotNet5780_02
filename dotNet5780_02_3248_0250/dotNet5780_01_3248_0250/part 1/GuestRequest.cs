using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part_1
{
    class GuestRequest
    {
        public DateTime Entry;
        public DateTime Release;
        public bool IsApproved;

        public int getDuration()
        {
            return (int)Release.Subtract(Entry).TotalDays;
        }
        public override string ToString()
        {
            return "Entry date: " +
                   "\nRelease date: " + Release + 
                   "\nRequest approved: " + IsApproved +
                   "\n";
        }
    }
}
