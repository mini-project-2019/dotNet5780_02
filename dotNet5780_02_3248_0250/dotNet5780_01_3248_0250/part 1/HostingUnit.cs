using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part_1
{
    class HostingUnit
    {
        static private int stSerialKey = 0;

        public int _HostingUnitKey;
        public int HostingUnitKey
        {
            get
            {
                return _HostingUnitKey;
            }
            set
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
            /*
            for (int i = 0; i < duration - 1; i++)
            // The last day is not counted
            {
                if (diary[getNewMonth(day - 1, month - 1, i), getNewDay(day - 1, i)])
                // If there is at least one occupied day then the order rejected
                /* Decreases the parameters in 1 to fix from ranges 
                   of [1, 31], [1, 12] to [0, 30], [0, 11]
                 */
            /*       {
                       Console.WriteLine("Request rejected");
                       return;
                   }
               }

               Console.WriteLine("Request accepted");

               for (int i = 0; i < duration - 1; i++)
               // Signs the new occupied days
               {
                   diary[getNewMonth(day - 1, month - 1, i), getNewDay(day - 1, i)] = true;
               }
               */
            return false;
       }

        private string occupiedDays_ToString()
        {
            /*
             for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (occupancy[i, j])
                        // 
                    {
                        int startMonth = i, startDay = j;
                        while (occupancy[i, j] || // Regular situation
                        
                            /* Makes sure that when two vacations are overlapping 
                               but not cut each other the vacations are considered one vacation
                         */
         /*   (!occupancy[i, j] && occupancy[getNewMonth(j, i, 1), getNewDay(j, 1)]))
                        {
                // Increases the end date of the vacation in 1
                i = getNewMonth(j, i, 1);
                j = getNewDay(j, 1);
            }

            Console.WriteLine("{0}/{1} - {2}/{3}",
                startDay + 1, startMonth + 1, j + 1, i + 1);
            /* Increase the parameters in 1 to fix from ranges 
               of [0, 30], [0, 11] to [1, 31], [1, 12]
             *//*
        }
    }
}*/
             
            return null;
        }

        
        
        public override string ToString()
        {
            return occupiedDays_ToString() + HostingUnitKey; 
        }
    }
}
