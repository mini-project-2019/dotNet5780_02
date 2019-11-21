using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part_1
{
    class GuestRequest
    {
        public Date Entry;
        public Date Release;
        public bool IsApproved;

        public override string ToString()
        {
            return "Entry date: " +
                   "\nRelease date: " + Release + 
                   "\nRequest approved: " + IsApproved +
                   "\n";
        }
    }
}
