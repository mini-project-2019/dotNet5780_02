using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part_1
{
    class HostingUnit
    {
        // A static variable that presents the number of total instances of HostingUnit
        static private int stSerialKey = 10000000;

        public static int _HostingUnitKey;
        public int HostingUnitKey
        {
            get
            {
                return _HostingUnitKey;
            }
            private set
            {
                _HostingUnitKey = value;
            }
        }

        private bool[,] diary;

        public HostingUnit()
        {
            HostingUnitKey = stSerialKey++;
            diary = new bool[12,31];
        }

        
        public bool approveRequest(GuestRequest GR)
        {
            
            for (int i = 0; i < GR.getDuration() - 1; i++)
            // Signs nights and not days
            {
                if (diary[GR.EntryDate.AddDays(i).Month - 1, GR.EntryDate.AddDays(i).Day - 1])
                    // If there is at least one occupied day then the order rejected
                    /* Decreases the parameters in 1 to fix from ranges 
                       of [1, 31], [1, 12] to [0, 30], [0, 11]
                    */
                {
                    GR.IsApproved = false;
                    return false;
                }
            }

            for (int i = 0; i < GR.getDuration() - 1; i++)
                // Signs the new occupied days
                /* Decreases the parameters in 1 to fix from ranges 
                   of [1, 31], [1, 12] to [0, 30], [0, 11]
                */
            {
                diary[GR.EntryDate.AddDays(i).Month - 1, GR.EntryDate.AddDays(i).Day - 1] = true;
            }

            GR.IsApproved = true;
            return true; 
        }

        public int GetAnnualBusyDays()
        // I made this method's declaration because I have to use it in Host
        {
            return 0;
        }

        public override string ToString()
        {
            return HostingUnitKey + ": " + occupiedDays_ToString(); 
        }

        public void reset()
            // Complete this function, it should set its diary to be all false
        {
            
        }
        private string occupiedDays_ToString()
        {
            string occupiedDays = "";
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (diary[i, j])
                    {
                        int startMonth = i, startDay = j;
                        while (diary[i, j] || // Regular situation
                            /* Makes sure that when two vacations are overlapping 
                               but not cut each other, the vacations are considered as one vacation
                            */
                            (!diary[i, j] && diary[getNewMonth(j, i, 1), getNewDay(j, 1)]))
                        {
                            // Increases the end date of the vacation in 1
                            i = getNewMonth(j, i, 1);
                            j = getNewDay(j, 1);
                        }

                        occupiedDays += "" + (startDay + 1) + "/" + (startMonth + 1) + 
                                        " - " + 
                                        (j + 1) + "/" + (i + 1) +
                                        ", ";
                        /* Increase the parameters in 1 to fix from ranges 
                           of [0, 30], [0, 11] to [1, 31], [1, 12]
                        */
                    }
                }
            }
            
            // Deletes the last 2 characters - ", "
            return occupiedDays.Substring(0, occupiedDays.Length - 3);
        }
        
        static private int getNewMonth(int day, int month, int duration)
        // Returns the month of the last day of the request in range of [0, 30]
        {
            return month + (day + duration) / 31;
        }

        static private int getNewDay(int day, int duration)
        // Returns the location in month of the last day of the request in range of [0, 11]
        {
            return ((day + duration) % 31);
        }
    }
}
    