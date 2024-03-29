﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part_1
{
    class GuestRequest 
    {
        public const int YEAR = 2020;

        public DateTime EntryDate;
        public DateTime ReleaseDate;
        public bool IsApproved;

        public GuestRequest(int entryDateDay, int entryDateMonth, int duration)
        {
            if (duration < 2)
            {
                throw new ArgumentOutOfRangeException("Duration must be bigger than two");
            }
            EntryDate = new DateTime(YEAR, entryDateMonth, entryDateDay);
            ReleaseDate = EntryDate.AddDays(duration);
        }

        public int getDuration()
        {
            return (int)ReleaseDate.Subtract(EntryDate).TotalDays;
        }

        public override string ToString()
        {
            return "EntryDate date: " + EntryDate +
                   "\nRelease date: " + ReleaseDate + 
                   "\nRequest approved: " + IsApproved +
                   "\n";
        }
    }
}
